using System;
namespace Monopoly_DesignPatternA4
{
  public class Gare : Case
  {
    #region attributs
    private string nom;
    private int prix;
    private int valeurHypotheque;
    private bool estAchetee;
    private bool estHypothequee;
    private string famille;
    private Joueur proprietaire;
    int position;
    #endregion

    #region conctructeur
    public Gare(int position, string nom)
    {
      estAchetee = false;
      this.position = position;
      this.nom = nom;
      prix = 200;
      valeurHypotheque = 100;
      famille = "gare";
      proprietaire = null;
    }
    #endregion

    #region proprietes
    public override int getPosition()
    {
      return position;
    }
    public override Joueur getProprietaire()
    {
      return proprietaire;
    }
    public override void setProprietaire(Joueur joueur)
    {
      proprietaire = joueur;
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

    public override void setNombreDeMaisons(int nombreDeMaisons)
    {
      // inutile mais fonction obligatoire
    }

    public override string getFamille()
    {
      return famille;
    }
    #endregion

    #region methodes
    public override string ToString()
    {
      return "Nom : " + nom + " Prix : " + prix + ", Valeur hypothèque : " + valeurHypotheque + " / Loyer 1 gare = 25, Loyer 2 gares = 50, Loyer 3 gares = 100, Loyer 4 gares = 200.";
    }
    #endregion
  }
}


