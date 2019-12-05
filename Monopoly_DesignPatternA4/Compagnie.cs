using System;
namespace Monopoly_DesignPatternA4
{
    public class Compagnie : Case
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






        // Constructeur rue
        public Compagnie(string nom)
        {
            this.nom = nom;
            prix = 150;
            valeurHypotheque = 75;
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
            return true;
        }
    }
}
