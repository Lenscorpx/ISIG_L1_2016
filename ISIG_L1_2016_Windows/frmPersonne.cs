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
    public partial class frmPersonne : Form
    {
        Personne p;
        //List<Personne> personnes = new List<Personne>();
        BindingSource bs = new BindingSource();
        Parametrage parametres = new Parametrage();

        public frmPersonne()
        {
            InitializeComponent();
        }

        private void frmPersonne_Load(object sender, EventArgs e)
        {
            try
            {
                //p = new Personne();
                //p.Nom = "50 BALAGIZI";
                //p.Prenom = "Oscar";
                //p.Sexe = Sexe.Masculin;
                //p.DateNaissance = new DateTime(2000, 12, 25);
                //p.EtatCivil = EtatCivil.Célibataire;
                //initialisation de la classe DAO
                DAO.Initialisation("NTMOSES", "ISIG_L1_2016", "sa", "15101989");
                //propertyGrid1.SelectedObject = p;

                //Sexe
                cmbSexe.Items.Add(Sexe.Féminin);
                cmbSexe.Items.Add(Sexe.Masculin);
                //Etat civil
                Array etat = Enum.GetValues(typeof(EtatCivil));
                for (int i = 0; i < etat.Length; i++)
                    cmbEtatCivil.Items.Add(etat.GetValue(i));
                //cmbEtatCivil.Items.Add(EtatCivil.Célibataire);
                //cmbEtatCivil.Items.Add(EtatCivil.Marié);
                //cmbEtatCivil.Items.Add(EtatCivil.Divorcé);
                //cmbEtatCivil.Items.Add(EtatCivil.Veuf);
                //Initialisation de la source de données
                bs.DataSource = DAO.Personnes;
                dataGridView1.DataSource = bs;
                bindingNavigator1.BindingSource = bs;
                bs.CurrentChanged += Bs_CurrentChanged;

                //Apparence
                Parametrer();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Parametrer()
        {
            this.Font = parametres.Police;
            this.BackColor = parametres.CouleurDeFond;
            this.ForeColor = parametres.CouleurPolice;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = bs.Current;

            SetBinding(txtNom, "Text", "Nom");
            SetBinding(txtPrenom, "Text", "Prenom");
            SetBinding(txtDateNaissance, "Text", "DateNaissance");
            SetBinding(cmbEtatCivil, "SelectedItem", "EtatCivil");
            SetBinding(cmbSexe, "SelectedItem", "Sexe");
            SetBinding(Txt_Id, "Text", "Id");
        }

        private void SetBinding(Control c, string proprieteControl, string accesseurPersonne)
        {

            Binding b = new Binding(proprieteControl, bs.Current, accesseurPersonne, 
                true, DataSourceUpdateMode.OnValidation);
            b.BindingComplete += B_BindingComplete;
            c.DataBindings.Clear();
            c.DataBindings.Add(b);
        }

        private void B_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.Cancel)
            {
                MessageBox.Show(e.ErrorText, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(bs.Current.ToString());

            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            p = new Personne();
            DAO.Personnes.Add(p);
            propertyGrid1.SelectedObject = p;
        }

        private void btnParametrage_Click(object sender, EventArgs e)
        {
            frmParametrage frm = new frmParametrage(parametres);
            frm.ShowDialog();
            parametres.Enregistrer();

            Parametrer();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (bs.Current is Personne)
                {
                    Personne p = (Personne)bs.Current;
                    if (sender == btn_Enregistrer)
                        p.Enregistrer();
                    else
                    {
                        DialogResult alt = MessageBox.Show("Etes-vous sure ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (alt == DialogResult.Yes)
                        {
                            p.Supprimer();
                            bs.RemoveCurrent();
                        }                            
                    }                    
                    //((Personne)bs.Current).Enregistrer();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Une erreur s'est produite", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
