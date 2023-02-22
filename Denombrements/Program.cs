/**
 * titre: calcule de denombrements
 * auteur: Naama
 * date de creation: 22/02/2023
 * date derniere modification: 22/02/2023
 * */

using System;


namespace Denombrements
{
    class Program
    {
        /// <summary>
        /// Calcul du produit de plusieurs entiers successifs, de valeurDepart a valeurArrivee
        /// </summary>
        /// <param name="valeurDepart">valeur de depart du calcul</param>
        /// <param name="valeurArrivee">valeur d'arrivee du calcul</param>
        /// <returns>resultat du produit ou 0 si depassement de capacite</returns>
        static long ProduitEntiers(int valeurDepart, int valeurArrivee)
        {
            long produit = 1;
            for (int k = valeurDepart; k <= valeurArrivee; k++)
            {
                produit *= k;
            }
            return produit;
        }

        /// <summary>
        /// Menu permettant de faire, plusieurs fois, 3 calculs : permutation, arrangement, combinaison
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string choix = "1";
            while (choix != "0")
            {
                Console.WriteLine("Permutation ...................... 1");
                Console.WriteLine("Arrangement ...................... 2");
                Console.WriteLine("Combinaison ...................... 3");
                Console.WriteLine("Quitter .......................... 0");
                Console.Write("Choix :                            ");
                choix = Console.ReadLine();
                // choix correct excluant le choix de quitter
                if (choix == "1" || choix == "2" || choix == "3")
                {
                    try
                    {
                        Console.Write("nombre total d'elements a gerer = ");
                        int nbTotal = int.Parse(Console.ReadLine());
                        // choix : permutation
                        if (choix == "1")
                        {
                            long permutation = ProduitEntiers(1, nbTotal);
                            Console.WriteLine(nbTotal + "!=" + permutation);
                        }
                        else
                        {
                            Console.Write("nombre d'elements dans le sous ensemble = ");
                            int nbSousEnsemble = int.Parse(Console.ReadLine());
                            //calcul de l'arrangement qui sert aussi au calcul de la combinaison
                            long arrangement = ProduitEntiers(nbTotal - nbSousEnsemble + 1, nbTotal);
                            // choix : arrangement
                            if (choix == "2")
                            {
                                Console.WriteLine("A(" + nbTotal + "/" + nbSousEnsemble + ") = " + arrangement);
                            }
                            // choix : combinaison
                            else
                            {
                                long combinaison = arrangement / ProduitEntiers(1, nbSousEnsemble);
                                Console.WriteLine("C(" + nbTotal + "/" + nbSousEnsemble + ") = " + combinaison);
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Calcul impossible : valeur(s) insorrecte(s) ou trop grande(s).");
                    }
                }

            }
        }
    }
}
