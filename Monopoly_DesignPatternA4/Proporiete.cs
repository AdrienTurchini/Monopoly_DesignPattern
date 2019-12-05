using System;
namespace Monopoly_DesignPatternA4
{
    public class Proporiete : Case
    {
        #region Attributs

        private string nom;
        private int prix;
        private int valeurHypotheque;
        private int prixMaison;
        private int loyerSimple;
        private int loyer1Maison;
        private int loyer2Maisons;
        private int loyer3Maisons;
        private int loyer4Maisons;
        private int loyerHotel;


        #endregion

        #region Constructeurs

        // Constructeur rue
        public Proporiete(string nom, int prix, int valeurHypotheque, int prixMaison, int loyerSimple, int loyer1Maison, int loyer2Maisons, int loyer3Maisons, int loyer4Maisons, int loyerHotel)
        {
            this.nom = nom;
            this.prix = prix;
            this.valeurHypotheque = valeurHypotheque;
            this.prixMaison = prixMaison;
            this.loyerSimple = loyerSimple;
            this.loyer1Maison = loyer1Maison;
            this.loyer2Maisons = loyer2Maisons;
            this.loyer3Maisons = loyer3Maisons;
            this.loyer4Maisons = loyer4Maisons;
            this.loyerHotel = loyerHotel;
        }
        override
        public string getNom()
        {
            return this.nom;
        }
        override
        public int getPrix()
        {
            return this.prix;
        }
        override
        public int getHypotheque()
        {
            return this.valeurHypotheque;
        }
        override
        public int getPrixMaison()
        {
            return this.prixMaison;
        }
        override
        public int getLoyer()
        {
            return this.loyerSimple;
        }
        override
        public int getLoyer1Maison()
        {
            return this.loyer1Maison;
        }
        override
        public int getLoyer2Maison()
        {
            return this.loyer2Maisons;
        }
        override
        public int getLoyer3Maison()
        {
            return this.loyer3Maisons;
        }
        override
        public int getLoyer4Maison()
        {
            return this.loyer4Maisons;
        }
        override
        public int getHotel()
        {
            return this.loyerHotel;
        }
        override
        public bool getEstGare()
        {
            return false;
        }
        override
        public bool getEstCompagnie()
        {
            return false;
        }







        /*

        // Constructeur gare ou compagnie
        public Proporiete(bool estGare, bool estCompagnie, string nom, int prix, int valeurHypotheque)
        {
            this.nom = nom;
            this.prix = prix;
            this.valeurHypotheque = valeurHypotheque;
            estHypothequee = false;
            estAchetee = false;
            proprietaire = null;
            this.estGare = estGare;
            this.estCompagnie = estCompagnie;

            if (estGare == true && estCompagnie == false)
            {
                loyer1gare = 25;
                loyer2gares = 50;
                loyer3gares = 100;
                loyer4gares = 200;
            }
            else if (estCompagnie == true && estGare == false)
            {
                coefficientLoyer1Carte = 4;
                coefficientLoyer2Cartes = 10;
            }
            else
            {

                Console.Write("Problème dans l'instanciation d'une gare ou d'une compagnie.\n Veuillez préciser si la carte est une gare en entrant g ou une compagnie en entrant c : ");
                string gareOuCompagnie = Console.ReadLine();
                Console.WriteLine();
                while (gareOuCompagnie != "g" || gareOuCompagnie != "c")
                {
                    Console.Write("Entrez 'g' si la carte est une gare ou 'c' si la carte est une compagnie");
                    gareOuCompagnie = Console.ReadLine();
                    Console.WriteLine();
                }
            }
        }


        #endregion

        #region Propriétés
        public override string Nom { get { return nom; } }
        public int Prix { get { return prix; } }
        public bool EstAchetee { get { return estAchetee; } set { estAchetee = value; } }
        public Joueur Proprietaire { get { return proprietaire; } set { proprietaire = value; } }
        public bool EstGare { get { return estGare; } }
        public bool EstCompagnie { get { return estCompagnie; } }
        public bool EstHypothequee { get { return estHypothequee; } set { estHypothequee = value; } }
        public int PrixMaison { get { return prixMaison; } }
        public int LoyerSimple { get { return loyerSimple; } }
        public int Loyer1Maison { get { return loyer1Maison; } }
        public int Loyer2Maisons { get { return loyer2Maisons; } }
        public int Loyer3Maisons { get { return loyer3Maisons; } }
        public int Loyer4Maisons { get { return loyer4Maisons; } }
        public int LoyerHotel { get { return loyerHotel; } }
        public bool PossedeUneMaison { get { return possedeUneMaison; } set { possedeUneMaison = value; } }
        public bool PossedeUnHotel { get { return possedeUnHotel; } set { possedeUnHotel = value; } }
        public int NbMaisons { get { return nbMaisons; } set { nbMaisons = value; } }
        public int CoefficientLoyer1Carte { get { return coefficientLoyer1Carte; } }
        public int CoefficientLoyer2Cartes { get { return coefficientLoyer2Cartes; } }
        public int Loyer1Gare { get { return loyer1gare; } }
        public int Loyer2Gares { get { return loyer2gares; } }
        public int Loyer3Gares { get { return loyer3gares; } }
        public int Loyer4Gares { get { return loyer4gares; } }
        #endregion

        #region Méthodes
        */
        public override string ToString()
        {
            string myString;
            myString = "Nom : " + nom + " prix : " + prix + " valeur hypothèque : " + valeurHypotheque;

            myString += " prix d'une maison : " + prixMaison + " loyer simple : " + loyerSimple + " loyer 1 maison : " + loyer1Maison + " loyer 2 maisons : " + loyer2Maisons + " loyer 3 maisons : " + loyer3Maisons + " loyer 4 maisons : " + loyer4Maisons + " loyer hotel : " + loyerHotel;
            return myString;
        }


        #endregion
    }
}
