using System;
namespace Monopoly_DesignPatternA4
{
    public class Autres : Case //Case départ, Parc gratuit, visite prison, aller en prison, caisse de communauté, chance, taxe
    {


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


        public Autres(string nom)
        {
            this.nom = nom;
        }
        override
        public string getNom()
        {
            return this.nom;
        }
        override
        public int getPrix()
        {
            return -1;
        }
        override
        public int getHypotheque()
        {
            return -1;
        }
        override
        public int getPrixMaison()
        {
            return -1;
        }
        override
        public int getLoyer()
        {
            return -1;
        }
        override
        public int getLoyer1Maison()
        {
            return -1;
        }
        override
        public int getLoyer2Maison()
        {
            return -1;
        }
        override
        public int getLoyer3Maison()
        {
            return -1;
        }
        override
        public int getLoyer4Maison()
        {
            return -1;
        }
        override
        public int getHotel()
        {
            return -1;
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
        public override string ToString()
        {
            return "Nom : " + nom;
        }
    }

}
