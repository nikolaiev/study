using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab2_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void myProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myProgressBar1.Round = !myProgressBar1.Round;
        }

        private void myProgressBar1_OnRoundIs(object sender, MyControl.MyEventArgs e)
        {
            MessageBox.Show("Progress bar round Action");
        }
    }
}
