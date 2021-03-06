﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Racegame
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Bitmap colorMap;
        Car car1;
        Car car2;

        public Form1()
        {
            InitializeComponent();
            BackgroundImage = Properties.Resources.Ztracks1;
            colorMap = Properties.Resources.Ztracks1_colormap;
            car1 = new Car(1, 30, 500, 32, 46);
            car2 = new Car(2, 70, 500, 32, 46);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if(car1.wins == true || car2.wins == true)
            {
                if (car1.wins == true)
                {
                    Image p1wins = Properties.Resources.Zombie1Wins;
                    e.Graphics.DrawImage(p1wins, 100, 300, 824, 104);
                }
                if (car2.wins == true)
                {
                    Image p2wins = Properties.Resources.Zombie2Wins;
                    e.Graphics.DrawImage(p2wins, 100, 300, 824, 104);
                }
            }
            // snelheid p1
            Image voeten = Properties.Resources.voetjes;
            if (car1.speed == 4)
            {
                e.Graphics.DrawImage(voeten, 150, 600, 65, 49);
                e.Graphics.DrawImage(voeten, 215, 600, 65, 49);
                e.Graphics.DrawImage(voeten, 280, 600, 65, 49);
                e.Graphics.DrawImage(voeten, 345, 600, 65, 49);
            }
            if (car1.speed == 3)
            {
                e.Graphics.DrawImage(voeten, 150, 600, 65, 49);
                e.Graphics.DrawImage(voeten, 215, 600, 65, 49);
                e.Graphics.DrawImage(voeten, 280, 600, 65, 49);
            }
            if (car1.speed == 2)
            {
                e.Graphics.DrawImage(voeten, 150, 600, 65, 49);
                e.Graphics.DrawImage(voeten, 215, 600, 65, 49);
            }
            if (car1.speed == 1)
            {
                e.Graphics.DrawImage(voeten, 150, 600, 65, 49);
            }
            
            imageList1.Draw(e.Graphics, new Point((int)car1.carTransform.position.posX, (int)car1.carTransform.position.posY), car1.spritenumber);
            imageList1.Draw(e.Graphics, new Point((int)car2.carTransform.position.posX, (int)car2.carTransform.position.posY), car2.spritenumber);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            car1.ColorCollision(colorMap, label3, label5, label7);
            car2.ColorCollision(colorMap, label4, label6, label8);

            car1.spritenumber = car1.FrameSelection(car1.spritenumber);
            car2.spritenumber = car2.FrameSelection(car2.spritenumber);

            this.label1.Text = "ENERGIE p1: " + Math.Round(car1.energie) + "%";
            this.label2.Text = "ENERGIE p2: " + Math.Round(car2.energie) + "%";

            if (car1.down == false && car1.up == false)
            {
                car1.snelheid = 0;
            }
            if (car2.down == false && car2.up == false)
            {
                car2.snelheid = 0;
            }

            if (car1.up == true)
            {
                car1.carTransform.Move(car1.movespeedforward);
                car1.snelheid = car1.movespeedforward;
                if (car1.right == true)
                {
                    car1.carTransform.Move(car1.movespeedup, car1.rotatespeed);
                }
                if (car1.left == true)
                {
                    car1.carTransform.Move(car1.movespeedup, -car1.rotatespeed);
                }
            }
            if (car1.down == true)
            {
                car1.carTransform.Move(-car1.movespeedbackward);
                car1.snelheid = car1.movespeedbackward;
                if (car1.right == true)
                {
                    car1.carTransform.Move(-car1.movespeeddown, -car1.rotatespeed);
                }
                if (car1.left == true)
                {
                    car1.carTransform.Move(-car1.movespeeddown, car1.rotatespeed);
                }
            }

            if (car2.up == true)
            {
                car2.carTransform.Move(car2.movespeedforward);
                car2.snelheid = car2.movespeedforward;
                if (car2.right == true)
                {
                    car2.carTransform.Move(car2.movespeedup, car2.rotatespeed);
                }
                if (car2.left == true)
                {
                    car2.carTransform.Move(car2.movespeedup, -car2.rotatespeed);
                }
            }
            if (car2.down == true)
            {
                car2.carTransform.Move(-car2.movespeedbackward);
                car2.snelheid = car2.movespeedbackward;
                if (car2.right == true)
                {
                    car2.carTransform.Move(-car2.movespeeddown, -car2.rotatespeed);
                }
                if (car2.left == true)
                {
                    car2.carTransform.Move(-car2.movespeeddown, car2.rotatespeed);
                }
            }
            Invalidate();

            double circlex = car1.carTransform.position.posX - car2.carTransform.position.posX;
            double circley = car1.carTransform.position.posY - car2.carTransform.position.posY;
            double distance = Math.Sqrt(Math.Pow(circlex, 2) + Math.Pow(circley, 2));
            if (distance < 20)
            {
                car1.carTransform.position.posX += (car1.carTransform.position.posX - car2.carTransform.position.posX) * (Math.Abs(car2.movespeedup) / 9 + 0.4f) / 4;
                car1.carTransform.position.posY += (car1.carTransform.position.posY - car2.carTransform.position.posY) * (Math.Abs(car2.movespeedup) / 9 + 0.4f) / 4;
                car2.carTransform.position.posX += (car2.carTransform.position.posX - car1.carTransform.position.posX) * (Math.Abs(car1.movespeedup) / 9 + 0.4f) / 4;
                car2.carTransform.position.posY += (car2.carTransform.position.posY - car1.carTransform.position.posY) * (Math.Abs(car1.movespeedup) / 9 + 0.4f) / 4;

            }
            
            if (car1.ronde == 3 || car2.ronde == 3)
            {
                if (car1.ronde == 3)
                {
                    car1.wins = true;//player1 wins
                }
                if (car2.ronde == 3)
                {
                    car2.wins = true;//player2 wins
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            car1.KeyPress(e);
            car2.KeyPress(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            car1.KeyRelease(e);
            car2.KeyRelease(e);
        }
    }
}
