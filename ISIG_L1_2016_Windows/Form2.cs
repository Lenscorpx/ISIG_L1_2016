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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Button b = new Button();  
            b.Text = "Mon nouveau bouton";
            b.Size = new Size(150, 40);
            b.BackColor = Color.Yellow;

            this.Controls.Add(b);
        }
    }
}
