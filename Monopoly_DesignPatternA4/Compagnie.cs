using System;
namespace Monopoly_DesignPatternA4
{
  public class Compagnie : Case
  {


    private string nom;
    private int prix;
    private int valeurHypotheque;
    private bool estAchetee;
    private bool estHypothequee;






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
    public override bool getEstAchetee()
    {
      return estAchetee;
    }

    public override void setEstAchetee(bool value)
    {
      estAchetee = value;
    }
    public override bool getEstHypothequee()
    {
      return estHypothequee;
    }
    public override void setEstHypothequee(bool value)
    {
      estHypothequee = value;
    }
    public override int getNombreDeMaisons()
    {
      return -1;
    }

<<<<<<< HEAD
    public override void setNombreDeMaisons(int nombreDeMaisons)
    {
      // fonction inutile mais obligatoire
=======
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
        public override string ToString()
        {
            return "Nom : " + nom + "Prix" + prix + " valeur hypothèque : " + valeurHypotheque;
        }
>>>>>>> 3848d6b73ce14f2e13af766dcbd2845bd3a77b52
    }
  }
}
