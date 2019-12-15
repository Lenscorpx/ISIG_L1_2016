using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using L1IG_METIER;
using System.Windows.Forms;

namespace ISIG_L1_2016_Windows
{
    public partial class frmParametrage : Form
    {
        public frmParametrage(Parametrage parametres)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = parametres;
        }
    }
}
