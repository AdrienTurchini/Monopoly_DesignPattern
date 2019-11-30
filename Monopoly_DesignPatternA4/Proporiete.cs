using System;
namespace Monopoly_DesignPatternA4
{
  public class Proporiete : Case
  {
    #region Attributs
    Case precedente;
    Case suivante;

    string nom;
    int prix;
    int valeurHypotheque;

    bool estAchetee;
    Joueur proprietaire;

    bool estGare;
    bool estCompagnie;

    bool estHypothequee;

    // estRue = true;
    int prixMaison;
    int loyerSimple;
    int loyer1Maison;
    int loyer2Maisons;
    int loyer3Maisons;
    int loyer4Maisons;
    int loyerHotel;
    bool possedeUneMaison;
    bool possedeUnHotel;
    int nbMaisons;

    // estCompagnie = true;
    int coefficientLoyer1Carte;
    int coefficientLoyer2Cartes;

    //estGare = true;
    int loyer1gare;
    int loyer2gares;
    int loyer3gares;
    int loyer4gares;
    #endregion

    #region Constructeurs

    // Constructeur rue
    public Proporiete(Case precedente, Case suivante, string nom, int prix, int valeurHypotheque, int prixMaison, int loyerSimple, int loyer1Maison, int loyer2Maisons, int loyer3Maisons, int loyer4Maisons, int loyerHotel)
    {
      this.precedente = precedente;
      this.suivante = suivante;
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

      estHypothequee = false;
      estAchetee = false;
      proprietaire = null;
      possedeUneMaison = false;
      possedeUnHotel = true;
      nbMaisons = 0;
    }

    // Constructeur gare ou compagnie
    public Proporiete(bool estGare, bool estCompagnie, Case precedente, Case suivante, string nom, int prix, int valeurHypotheque)
    {
      this.precedente = precedente;
      this.suivante = suivante;
      this.nom = nom;
      this.prix = prix;
      this.valeurHypotheque = valeurHypotheque;
      estHypothequee = false;
      estAchetee = false;
      proprietaire = null;
      this.estGare = estGare;
      this.estCompagnie = estCompagnie;

      if(estGare == true && estCompagnie == false)
      {
        loyer1gare = 25;
        loyer2gares = 50;
        loyer3gares = 100;
        loyer4gares = 200;
      }
      else if(estCompagnie == true && estGare == false)
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
    public override Case Precedente { get { return precedente; } set { precedente = value; } }
    public override Case Suivante { get { return suivante; } set { suivante = value; } }
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
    public bool PossedeUneMaison { get { return possedeUneMaison; }set { possedeUneMaison = value; } }
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

    public override string ToString()
    {
      string myString;
      myString = "Nom : " + nom + " prix : " + prix + " valeur hypothèque : " + valeurHypotheque + " est Acheté : " + estAchetee + " propiétaire de la carte : " + proprietaire + " est hypothequée : " + estHypothequee;
      if (estGare == true)
        myString += " loyer 1 gare : " + loyer1gare + " loyer 2 gares : " + loyer2gares + " loyer 3 gares : " + loyer3gares + " loyer 4 gares : " + loyer4gares;
      else if (estCompagnie == true)
        myString += " coefficient Loyer 1 compagnie : " + coefficientLoyer1Carte + " coefficient loyer 2 compagnie : " + coefficientLoyer2Cartes;
      else
        myString += " prix d'une maison : " + prixMaison + " loyer simple : " + loyerSimple + " loyer 1 maison : " + Loyer1Maison + " loyer 2 maisons : " + loyer2Maisons + " loyer 3 maisons : " + loyer3Maisons + " loyer 4 maisons : " + loyer4Maisons + " loyer hotel : " + loyerHotel + "possède une maison : " + possedeUneMaison + " possede un hotel : " + possedeUnHotel + " nombre de maisons sur la propriétés : " + nbMaisons;
      return myString;
    }


    #endregion
  }
}
