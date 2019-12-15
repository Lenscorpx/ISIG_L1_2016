using System;


namespace ISIG_L1_2016_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestWriteLine();
            //deliberation();
            #region ExempleDeRegion
            //deliberationSimple();
            //JourDeLaSemaine();
            //TestFor5();
            //deliberationSimple2();
            #endregion
            //deliberationSimple3();
            //deliberationSimple4();
            //TestDeliberation();
            //TestPassageParValeurEtParReference();
            //TestParametres(12, 30);
            //TestParametres(1, 2, 3, 4, 5, 30);
            //TestString();
            //NomDeFichier();
            //TestComparaisonDeChaines();
            //TableauUneDimension();
            //TestInitialisationTableau();
            //TableauADeuxDimensions();
            //TableauATroisDimensions2();
            //TestTableau();
            //TableauDeTableau();
            //CalculMoyenneCotes();

            TestArgumentsDeMain(args);
            Console.ReadLine();
        }

        private static void TestWriteLine()
        {
            System.Console.WriteLine("Bonjour tout le monde");

            int j = 3;
            int i = j++;
            Console.Write("Valeur de i :");
            Console.WriteLine(i);
            Console.WriteLine("Valeur de i : {0}", i);
            Console.Write("Valeur de j :");
            Console.WriteLine(j);
            i += j;
            Console.WriteLine("Valeur de i : {0}, valeur de j: {1}", i, j);
            Console.WriteLine(j);
        }

        static void deliberation()
        {
            Console.Write("Saisissez les points de l'étudiant : ");
            string s = Console.ReadLine();

            double point = Convert.ToDouble(s);
            string mention = "";

            if (point < 0) mention = "Le nombre doit être > à 0";
            else if (point < 25)
                mention = "NAF";
            else if (point < 50) mention = "Ajourné";
            else if (point < 70) mention = "Satisfaction";
            else if (point < 80)
            {
                mention = "Distinction";
            }
            else if (point <= 100)
                mention = "Grande distinction";
            else
                mention = "Le nombre doit être inférieur ou égal à 100";
            Console.WriteLine(mention);
        }

        static void deliberationSimple()
        {
            Console.Write("Tapez les points de l'étudiant :");
            double points = double.Parse(Console.ReadLine());
            string mention = (points >= 50 ? "Vous avez réussi" : (points >= 30 ? "Mauvais" : "Piètre"));
            Console.WriteLine(mention);
            /*Equivalent à :
            if (points >= 50) mention = "Vous avez réussi";
            else mention = "Vous avez échoué";
            */
        }
        static void JourDeLaSemaine()
        {

            Console.Write("Saisir un nombre :");
            int jour = int.Parse(Console.ReadLine());
            switch (jour)
            {

                case 1:
                    Console.WriteLine("Lundi");
                    break;
                case 2: Console.WriteLine("Mardi"); break;
                case 3: Console.WriteLine("Mercredi"); break;
                case 4: Console.WriteLine("Jeudi"); break;
                case 5: Console.WriteLine("Vendredi"); break;
                case 6: Console.WriteLine("Samedi"); break;
                case 7: Console.WriteLine("Dimanche"); break;
                default:
                    Console.WriteLine("Le nombre doit être compris entre 1 et 7");
                    break;
            }
        }
        #region Test For
        static void TestFor1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Nombre numero {0}", i + 1);
            }
        }
        static void TestFor2()
        {
            for (int i = 0; i < 10;)
            {
                Console.WriteLine("Nombre numero {0}", ++i);
            }
        }
        static void TestFor3()
        {
            for (int i = 0; ; i++)
            {
                Console.WriteLine("Nombre numero {0}", i + 1);
                if (i == 9)
                    break;
            }
        }
        static void TestFor4()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i % 5 == 0) break;
                Console.WriteLine("Nombre {0} ", i);
            }
        }
        #endregion
        static void TestFor5()
        {
            for (int i = 0; i <= 9; i++)
            {
                if (i % 2 == 0) continue;
                Console.WriteLine("Nombre {0} ", i);
            }
        }

        static void deliberationSimple2()
        {
            double nombre = 0;
            do
            {
                Console.Write("Saisissez les points : ");
                nombre = double.Parse(Console.ReadLine());
                string mention = "";
                if (nombre > 100)
                    Console.WriteLine("Le nombre doit être between 0 and 100");
                else if (nombre >= 50 && nombre <= 100)
                {
                    mention = "Vous avez réussi";
                }
                else if (nombre >= 0)
                {
                    mention = "Vous avez échoué";

                }
                Console.WriteLine(mention);


            }
            while (nombre >= 0);
        }

        static void deliberationSimple3()
        {
            double nombre = 0;
            for (nombre = 0; nombre >= 0;)
            {
                Console.Write("Saisissez les points : ");
                nombre = double.Parse(Console.ReadLine());
                string mention = "";
                if (nombre > 100)
                    Console.WriteLine("Le nombre doit être between 0 and 100");
                else if (nombre >= 50)
                {
                    mention = "Vous avez réussi";
                }
                else if (nombre >= 0)
                {
                    mention = "Vous avez échoué";

                }
                Console.WriteLine(mention);
            }
        }

        static void deliberationSimple4()
        {
            while (true)
            {

                Console.Write("Saisissez les points : ");
                double nombre = double.Parse(Console.ReadLine());
                string mention = "";
                if (nombre > 100)
                    Console.WriteLine("Le nombre doit être between 0 and 100");
                else if (nombre >= 50)
                {
                    mention = "Vous avez réussi";
                }
                else if (nombre >= 0)
                {
                    mention = "Vous avez échoué";
                }
                else break;
                Console.WriteLine(mention);
            }
        }

        static string deliberation(double points)
        {
            string mention = "";
            if (points < 25) mention = "NAF";
            else if (points < 50) mention = "Ajourné";
            else if (points < 70) mention = "Satisfaction";
            else if (points < 80) mention = "Distinction";
            else if (points <= 100) mention = "Grande Distinction";
            else mention = "Valeur incorrecte";

            return mention;
        }
        static void TestDeliberation()
        {
            do
            {
                Console.Write("Saisissez les points de l'étudiant : ");
                string s = Console.ReadLine();
                double points = double.Parse(s);
                if (points < 0) break;
                s = deliberation(points); //Appel de la fonction délibération
                Console.WriteLine(s);
            }
            while (true);
            Console.WriteLine("Fin de la délibération");
        }

        static int calulerDouble(int a)
        {
            a *= 2; //Equivalent à a=a*2
            return a;
        }
        static int calulerDoubleParReference(ref int a)
        {
            a *= 2; //Equivalent à a=a*2
            return a;
        }
        static void TestPassageParValeurEtParReference()
        {
            Console.WriteLine("====Passage par valeur======");
            Console.Write("Tapez un nombre : ");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Valeur de i : {0} ", i);
            Console.WriteLine("Valeur du double de i : {0}", calulerDouble(i));
            Console.WriteLine("Valeur de i : {0} ", i);

            Console.WriteLine("====Passage par reference======");
            Console.WriteLine("Valeur de i : {0} ", i);
            Console.WriteLine("Valeur du double de i : {0}",
                calulerDoubleParReference(ref i));
            Console.WriteLine("Valeur de i : {0} ", i);
        }

        protected static void TestParametres(params int[] nombre)
        {
            for (int i = 0; i < nombre.Length; i++)
                Console.WriteLine("Nombre : " + nombre[i]);
        }

        static void TestString()
        {
            //Console.Write("Tapez une chaine de caractères :");
            //string s = Console.ReadLine();
            //Console.WriteLine("Longueur de la chaine : {0}", s.Length);
            //s = s.Trim(); //Supprime les espaces avant et après la chaine
            //Console.WriteLine(s.Substring(3)); //récupère une partie de la chaine
            //Console.WriteLine(s.Substring(3, 5));
            //Console.WriteLine("Le premier e se trouve à la position {0}", s.IndexOf('e'));
            //Console.WriteLine("Le dernier a se trouve à la position {0}", s.LastIndexOf('a'));

            //Console.Write("Numéro de compte :");
            //string s = Console.ReadLine();
            //Console.WriteLine(s.PadLeft(8, '0'));
            //Console.WriteLine(s.PadRight(8, 'F'));

            Console.WriteLine("Tapez une chaine de caractères :");
            string s = Console.ReadLine();
            string[] tableau = s.Split(' ', ';');
            for (int i = 0; i < tableau.Length; i++)
                Console.WriteLine(tableau[i]);

            Console.WriteLine("-----------------");
            char[] caracteres = s.ToCharArray();
            for (int i = 0; i < caracteres.Length; i++)
                Console.WriteLine(caracteres[i]);
        }

        static void NomDeFichier()
        {
            string s = "C:\\Mes Documents\\Test\\fichier.xls";
            s = @"C:\Mes Documents\Test\fichier.xls";

            int indexDernierAntislash = s.LastIndexOf("\\");
            string repertoire = s.Substring(0, indexDernierAntislash + 1);
            string fichier = s.Substring(indexDernierAntislash + 1);

            Console.WriteLine("Répertoie : {0}", repertoire);
            Console.WriteLine("Fichier : {0}", fichier);

        }

        static void TestComparaisonDeChaines()
        {
            do
            {
                Console.Write("Tapez la 1ere chaine :");
                string chaine1 = Console.ReadLine();
                Console.Write("Tapez la 2eme chaine :");
                string chaine2 = Console.ReadLine();

                int i = string.Compare(chaine1, chaine2, true);


                if (i < 0) Console.WriteLine("{0} < à {1}", chaine1, chaine2);
                else if (i == 0) Console.WriteLine("{0} = à {1}", chaine1, chaine2);
                else Console.WriteLine("{0} > à {1}", chaine1, chaine2);

                Console.WriteLine(chaine1 == chaine2);

                Console.WriteLine("---------------------");
            }
            while (true);
        }

        static void TableauUneDimension()
        {
            int[] tableau = new int[] { 2, 4, 6, 8, 9 };
            for (int i = 0; i < tableau.Length; i++)
                Console.WriteLine("Index {0} : {1}",
                    tableau.Length - 1 - i, tableau[tableau.Length - 1 - i]);
        }

        static void TestInitialisationTableau()
        {
            Console.Write("Nombre d'étudiants : ");
            int nombreEtudiant = int.Parse(Console.ReadLine());

            string[] etudiants = new string[nombreEtudiant];
            for (int i = 0; i < nombreEtudiant; i++)
            {
                Console.Write("Nom de l'étudiant No {0} : ", i + 1);
                string nom = Console.ReadLine();
                etudiants[i] = nom;
            }

            //Affichage
            Console.WriteLine("Liste d'étudiants ");
            Console.WriteLine("==================");

            for (int i = 0; i < etudiants.Length; i++)
                Console.WriteLine("{0}. {1}", i + 1, etudiants[i]);
        }

        static void TableauADeuxDimensions()
        {
            int[,] tableau = new int[,]
            {
                { 10, 12 },
                { 7, 8 },
                { 20, 22 }
            };
            Console.WriteLine("Longueur du tableau : {0} ", tableau.Length);
            Console.WriteLine("Nombre de lignes :{0} ", tableau.GetLength(0));
            Console.WriteLine("Nombre de colonnes :{0} ", tableau.GetLength(1));
            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                for (int j = 0; j < tableau.GetLength(1); j++)
                {
                    Console.WriteLine("Ligne {0}, Colonne {1} : {2}",
                        i + 1,
                        j + 1,
                        tableau[i, j]);
                }
                Console.WriteLine("----------------------");
            }
        }
        static void TableauATroisDimensions()
        {
            int[,,] tableau = new int[,,]
            {
                {
                    {10,11 },
                    {12,13 }, 
                    {14,15 }
                },
                { 
                    {16,17 }, {18,19 }, {20,21 }
                },
                {
                    {22,23 }, {24,25 }, { 26,27}
                }
            };
            Console.WriteLine("Longueur du tableau : {0} ", tableau.Length);
            Console.WriteLine("Dim 1 :{0} ", tableau.GetLength(0));
            Console.WriteLine("Dim 2 :{0} ", tableau.GetLength(1));
            Console.WriteLine("Dim 3 :{0} ", tableau.GetLength(2));
            Console.WriteLine("==================");

            tableau[2, 0, 1] *= 10;
            for(int i=0; i<tableau.GetLength(0); i++)
            {
                for(int j=0; j< tableau.GetLength(1); j++)
                {
                    for(int k=0; k< tableau.GetLength(2); k++)
                    {
                        Console.WriteLine("({0}, {1}, {2}) = {3}", i, j, k,
                            tableau[i, j, k]);
                    }
                    Console.WriteLine("-----------------");
                }
                Console.WriteLine("==================");
            }
        }

        static void TableauATroisDimensions2()
        {
            int[,,] tableau = new int[3,3,2];

            //Initialisation du tableau
            tableau[0, 0, 0] = 10;
            tableau[0, 0, 1] = 11;
            tableau[0, 1, 0] = 12;
            tableau[0, 1, 1] = 13;

            Console.WriteLine("Longueur du tableau : {0} ", tableau.Length);
            Console.WriteLine("Dim 1 :{0} ", tableau.GetLength(0));
            Console.WriteLine("Dim 2 :{0} ", tableau.GetLength(1));
            Console.WriteLine("Dim 3 :{0} ", tableau.GetLength(2));
            Console.WriteLine("==================");

            tableau[2, 0, 1] *= 10;
            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                for (int j = 0; j < tableau.GetLength(1); j++)
                {
                    for (int k = 0; k < tableau.GetLength(2); k++)
                    {
                        Console.WriteLine("({0}, {1}, {2}) = {3}", i, j, k,
                            tableau[i, j, k]);
                    }
                    Console.WriteLine("-----------------");
                }
                Console.WriteLine("==================");
            }
        }

        static void TableauDeTableau()
        {
            int[][] tableau = new int[3][];
            //Initialisation
            tableau[0] = new int[] { 10, 12, 13, 16, 20 };
            tableau[1] = new int[3];
            tableau[2] = new int[2] { 100, 200 };
            //tableau[3] = new int[5]; //Erreur : En dehors des limites du tableau!!!!

            int[] x = tableau[1];
            x[2] = 1300;

            //tableau[1][2] = 1200;
            for (int i= 0; i<tableau.Length; i++) //Parcours le 1er tableau
            {
                for(int j =0; j<tableau[i].Length; j++)
                {
                    Console.WriteLine("({0}, {1}) = {2}", i, j, tableau[i][j]);
                }
                Console.WriteLine("---------------------");
            }
        }
        static void TestTableau()
        {
            /*
  * Ce programme déclare une matrice de 3 lignes et 2 colonnes
  * et en affiche les éléments à la console
  */
            char[,] matrice = new char[3, 2];
            //Affectation des valeurs
            matrice[0, 0] = 'a';
            matrice[0, 1] = 'b';
            matrice[1, 0] = 'm';
            matrice[1, 1] = 'n';
            matrice[2, 0] = 'y';
            matrice[2, 1] = 'z';
            //Affichage des éléments de la matrice
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("({0}, {1})", matrice[i, 0], matrice[i, 1]);
            }
            Console.Read();
        }

        static void CalculMoyenneCotes()
        {
            Console.Write("Nombre d'étudiants : ");
            int nombreEtudiants = int.Parse(Console.ReadLine());
            Console.Write("Nombre de côtes : ");
            int nombreCotes = int.Parse(Console.ReadLine());

            double[][] cotes = new double[nombreEtudiants][];
            for(int i=0; i< nombreEtudiants; i++)
            {
                Console.WriteLine("====Etudiant No {0} : ", i + 1);
                cotes[i] = new double[nombreCotes];
                for(int j =0; j< nombreCotes; j++)
                {
                    Console.Write("Côte No {0} : ", j + 1);
                    cotes[i][j] = double.Parse(Console.ReadLine());
                }
            }

            //Affichage
            Console.WriteLine("===============RESULTATS=========");
            for(int i=0; i< nombreEtudiants; i++)
            {
                Console.Write("====Etudiant No {0} : ", i + 1);
                double moyenne = 0.0;
                for(int j=0; j<cotes[i].Length; j++)
                {
                    moyenne += cotes[i][j];
                    Console.Write("{0}, ", cotes[i][j]);
                }
                moyenne /= cotes[i].Length;
                Console.WriteLine("Moyenne : {0}", moyenne);
            }
        }

        static void TestArgumentsDeMain(string[] args)
        {
            if(args.Length>0)
            {
                string cle = "", valeur = "";
                for(int i=0; i< args.Length; i++)
                {

                    //Console.WriteLine(args[i]);
                    if (args[i].Length >= 2)
                    {
                        valeur = args[i].Substring(2);

                        switch (args[i].Substring(0, 2))
                        {
                            case "-u":
                                cle = "Utilisateur";
                                break;
                            case "-p": cle = "Mot de passe"; break;
                            case "-s": cle = "Serveur"; break;
                            case "-d": cle = "Base de données"; break;

                        }
                        Console.WriteLine("{0}\t: {1}", cle, valeur);
                    }
                }
            }
            Console.WriteLine("--------------------------");
        }
    }
}
