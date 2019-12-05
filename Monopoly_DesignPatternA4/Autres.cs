using System;
namespace Monopoly_DesignPatternA4
{
    public class Autres : Case
    {


        private string nom;
        private int prix;
        private int valeurHypotheque;



    // Constructeur gare
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
            return false;
        }
        public override string ToString()
        {
            return "nom : " + nom;
        }
    public override bool getEstAchetee()
    {
      return false;
    }

    public override void setEstAchetee(bool value)
    {
      // fonction inutile mais obligatoire
    }
    public override bool getEstHypothequee()
    {
      return false;
    }
    public override void setEstHypothequee(bool value)
    {
      // fonction inutile mais obligatoire
    }
    public override int getNombreDeMaisons()
    {
      return -1;
    }

    public override void setNombreDeMaisons(int nombreDeMaisons)
    {
      // fonction inutile mais obligatoire
    }
  }

}
