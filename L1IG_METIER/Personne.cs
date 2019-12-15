using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L1IG_METIER
{
    public class Personne
    {
        private int id;
        private string nom, prenom;
        private DateTime dateNaissance;
        private Sexe sexe;
        private EtatCivil etatCivil;
       
        /* Accesseur à la façon JAVA
        public string getNom()
        {
            return nom;
        }
        public void setNom(string nom)
        {
            this.nom = nom;
        }
        */
        /// <summary>
        /// Cette propriété stock le nom de la personne
        /// Le nom doit commencer par une lettre 
        /// et ne contenir que des lettres, des espaces et l'apostrophe
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set
            {
                VerifierNom(value);
                nom = value;
            }
        }

        /// <summary>
        /// Vérifie si la valeur passee en paramètre respecte les conditions d'un nom
        /// </summary>
        /// <param name="value">Un nom ou prénom passé en paramètre</param>
        private void VerifierNom(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                char[] caracteres = value.ToCharArray();
                //Commence par une lettre
                if (!char.IsLetter(caracteres[0]))
                    throw new Exception("Le premier caractère doit être une lettre");
                //Vérifie si lettre, espace ou apostrophe
                for (int i = 0; i < caracteres.Length; i++)
                {
                    if (!char.IsLetter(caracteres[i]))
                    {
                        if (caracteres[i] != ' ' && caracteres[i] != '\'')
                        {
                            throw new Exception("Ne doit contenir que des lettres, des espaces et des apostrophes");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Cette propriété stock le prénom de la personne
        /// Le prénom doit commencer par une lettre 
        /// et ne contenir que des lettres, des espaces et l'apostrophe
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set
            {
                VerifierNom(value);
                prenom = value;
            }
        }
        /// <summary>
        /// La date de naissance ne doit pas être 
        /// supérieure à la date courante
        /// </summary>
        public DateTime DateNaissance
        {
            get
            {
                return dateNaissance;
            }
            set
            {
                if (DateTime.Compare(value, DateTime.Now) > 0)
                    throw new Exception(
@"La date de naissance doit être inférieure 
ou égale à la date d'aujourd'hui");
                else
                    dateNaissance = value;
            }
        }

        public int Age
        {
            get
            {
                TimeSpan ts = DateTime.Now.Subtract(dateNaissance);
                int age = ts.Days / 365;
                return age;
            }
        }

        public Sexe Sexe
        {
            get
            {
                return sexe;
            }

            set
            {
                sexe = value;
            }
        }

        public EtatCivil EtatCivil
        {
            get
            {
                return etatCivil;
            }

            set
            {
                etatCivil = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        //Redéfinition de la méthode ToString
        public override string ToString()
        {
            string s = "";
            if(!string.IsNullOrEmpty(nom)) s += "Nom : " + this.nom;
            if (!string.IsNullOrEmpty(prenom)) s += "\nPrénom : " + this.prenom;
            s += "\nSexe : " + this.sexe;
            s += "\nDate de naissance : " + dateNaissance;
            s += "\nAge : " + Age;
            s += "\nEtat Civil : " + etatCivil;
            return s;
        }

        public void Enregistrer()
        {
            if (string.IsNullOrEmpty(nom)) throw new Exception("Le nom est obligatoire");
            if (id <= 0) throw new Exception("Le Id doit etre superieur a 0");
            DAO.EnregistrerPersonne(this);
        }
        public void Supprimer()
        {
            DAO.SupprimerPersonne(this);
        }
    }
}
