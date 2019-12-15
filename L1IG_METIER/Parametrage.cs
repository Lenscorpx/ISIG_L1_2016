using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel; //Pour métadonnées des accesseurs
using System.IO; //Pour la manipulation des fichiers

namespace L1IG_METIER
{
    public class Parametrage
    {
        Color couleurDeFond, couleurPolice;
        Font police;

        [Description("Séléctionnez une couleur qui sera utilisée en arrière plan")]
        public Color CouleurDeFond
        {
            get
            {
                return couleurDeFond;
            }

            set
            {
                couleurDeFond = value;
            }
        }

        [Description("Définissez une couleur de texte")]
        public Color CouleurPolice
        {
            get
            {
                return couleurPolice;
            }

            set
            {
                couleurPolice = value;
            }
        }

        //[Browsable(false)]

        public Font Police
        {
            get
            {
                return police;
            }

            set
            {
                police = value;
            }
        }
        //Constructeur
        public Parametrage()
        {
            string nomPolice = "Book Antiqua";
            float taillePolice = 10;

            int cf = Color.AliceBlue.ToArgb();
            int cp = Color.Blue.ToArgb();

            if (File.Exists("Settings.cfg"))
            {
                using (StreamReader sr = new StreamReader("Settings.cfg"))
                {

                    while (!sr.EndOfStream)
                    {
                        string[] tableau = sr.ReadLine().Split(':');
                        if (tableau.Length == 2)
                        {
                            switch (tableau[0])
                            {
                                case "NOM_POLICE":
                                    nomPolice = tableau[1];
                                    break;
                                case "TAILLE_POLICE":
                                    taillePolice = float.Parse(tableau[1]);
                                    break;
                                case "COULEUR_FOND":
                                    cf = int.Parse(tableau[1]);
                                    break;
                                case "COULEUR_POLICE":
                                    cp = int.Parse(tableau[1]);
                                    break;

                            }
                        }
                    }
                    sr.Close();
                    sr.Dispose();
                }
            }
            police = new Font(new FontFamily(nomPolice), taillePolice);
            couleurDeFond = Color.FromArgb(cf);
            couleurPolice = Color.FromArgb(cp);
        }
        //Méthodes
        public void Enregistrer()
        {
            using (StreamWriter sw = new StreamWriter("Settings.cfg"))
            {
                sw.WriteLine("NOM_POLICE:" + Police.FontFamily.Name);
                sw.WriteLine("TAILLE_POLICE:" + Police.Size);
                sw.WriteLine("COULEUR_FOND:" + CouleurDeFond.ToArgb());
                sw.WriteLine("COULEUR_POLICE:" + CouleurPolice.ToArgb());
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }

    }
}
