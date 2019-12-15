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
    private bool estAchetee;
    private bool estHypothequee;
    private int nombreDeMaisons; // 5 = hotel
    private string famille;
    private Joueur proprietaire;
    int position;


    #endregion

    #region Constructeurs
    public Proporiete(int position, string famille, string nom, int prix, int valeurHypotheque, int prixMaison, int loyerSimple, int loyer1Maison, int loyer2Maisons, int loyer3Maisons, int loyer4Maisons, int loyerHotel)
    {
      this.position = position;
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
      estAchetee = false;
      nombreDeMaisons = 0;
      this.famille = famille;
      proprietaire = null;
    }
    #endregion

    #region propriétés
    public override int getPosition()
    {
      return position;
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
    public bool getEstAchetee()
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
      return nombreDeMaisons;
    }

    public override void setNombreDeMaisons(int nombreDeMaisons)
    {
      this.nombreDeMaisons = nombreDeMaisons;
    }

    public override string getFamille()
    {
      return famille;
    }

    public override Joueur getProprietaire()
    {
      return proprietaire;
    }

    public override void setProprietaire(Joueur joueur)
    {
      proprietaire = joueur;
    }

    #endregion

    #region methodes
    public override string ToString()
    {
      string myString;
      myString = "Nom : " + nom + " Prix : " + prix + " Valeur hypothèque : " + valeurHypotheque;

      myString += " prix d'une maison : " + prixMaison + " loyer simple : " + loyerSimple + " loyer 1 maison : " + loyer1Maison + " loyer 2 maisons : " + loyer2Maisons + " loyer 3 maisons : " + loyer3Maisons + " loyer 4 maisons : " + loyer4Maisons + " loyer hotel : " + loyerHotel;
      return myString;
    }


    #endregion
  }
}
