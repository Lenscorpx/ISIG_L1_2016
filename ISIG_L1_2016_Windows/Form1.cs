using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISIG_L1_2016_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Key down");
            Console.WriteLine("Key down");
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Key press");
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Key up");
        }
    }
}
