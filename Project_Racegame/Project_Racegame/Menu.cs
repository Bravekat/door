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
    public partial class Menu : Form
    {
        
        public bool[] zombie = {false, false, false, false, false, false, false, false};
        public bool[] map = {false, false, false, false, false, false, false, false};
        //imageList1.Images[  ];
        public Menu()
        {
            InitializeComponent();            
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FormClosing += delegate { this.Show(); };
            form.Show();            
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void player1left_Click(object sender, EventArgs e)
        {

        }

        private void player1right_Click(object sender, EventArgs e)
        {

        }
    }
}