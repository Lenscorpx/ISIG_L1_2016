using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace L1IG_METIER
{
    public static class DAO
    {
        static SqlConnection conn;
        private static List<Personne> maliste;
        public static void Initialisation(String NomDuServeur, String BaseDeDonnee, String NomUtilisateur, String MotDePasse)
        {
            String connectionStr = String.Format("server={0};database={1};user={2};pwd={3}",NomDuServeur,BaseDeDonnee,NomUtilisateur,MotDePasse);
            conn = new SqlConnection(connectionStr);
        }
        internal static void EnregistrerPersonne(Personne p)
        {
            // Ouverture de la connection
            if (conn.State != ConnectionState.Open) conn.Open();
            //Creation et initialisation de l'objet command
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"IF EXISTS(SELECT id FROM personne WHERE id = @id)
                              UPDATE personne SET nom=@nom, prenom=@prenom, date_naissance=@date_naissance,
                              sexe=@sexe, etat_civil=@etat_civil WHERE id=@id ELSE INSERT INTO 
                              personne(id, nom,prenom,date_naissance,sexe,etat_civil)
                              VALUES(@id, @nom,@prenom,@date_naissance,@sexe,@etat_civil)";
            //SqlParameter param = new SqlParameter("@id",p.Id);
            //cmd.Parameters.Add(param);
            cmd.Parameters.Add(new SqlParameter("@id", p.Id));
            cmd.Parameters.Add(new SqlParameter("@nom", p.Nom));
            cmd.Parameters.Add(new SqlParameter("@prenom", p.Prenom));
            cmd.Parameters.Add(new SqlParameter("@date_naissance", p.DateNaissance));
            cmd.Parameters.Add(new SqlParameter("@sexe", p.Sexe.ToString()));
            cmd.Parameters.Add(new SqlParameter("@etat_civil", p.EtatCivil.ToString()));
            // Execution de la requette
            cmd.ExecuteNonQuery();
            //Fermeture de la connection
            conn.Close();
        }
        internal static void SupprimerPersonne(Personne p)
        {
            // Ouverture de la connection
            if (conn.State != ConnectionState.Open) conn.Open();
            //Creation et initialisation de l'objet command
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"DELETE FROM personne WHERE id=@id";
            //SqlParameter param = new SqlParameter("@id",p.Id);
            //cmd.Parameters.Add(param);
            cmd.Parameters.Add(new SqlParameter("@id", p.Id));
            // Execution de la requette
            cmd.ExecuteNonQuery();
            //Fermeture de la connection
            conn.Close();
        }

        public static List<Personne> Personnes
        {
            get
            {
                if (maliste == null)
                {
                    maliste = new List<Personne>();
                    if (conn.State != ConnectionState.Open) conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM personne ORDER BY id";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Personne p = new Personne();
                        p.Id = Convert.ToInt32(dr["id"]);
                        p.Nom = dr["nom"].ToString();
                        p.Prenom = dr["prenom"].ToString();
                        if (dr["date_naissance"]!=DBNull.Value)
                            p.DateNaissance =Convert.ToDateTime(dr["date_naissance"]);
                        p.Sexe = (Sexe)Enum.Parse(typeof(Sexe), dr["sexe"].ToString(),true);
                        p.EtatCivil = (EtatCivil)Enum.Parse(typeof(EtatCivil), dr["etat_civil"].ToString(),true);

                        maliste.Add(p);
                    }
                    dr.Close();
                    conn.Close();
                    cmd.Dispose();
                }
                return maliste;
            }
        }
    }
}
