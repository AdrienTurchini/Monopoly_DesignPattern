using System;
namespace Monopoly_DesignPatternA4
{
  public class Autres : Case //Case départ, Parc gratuit, visite prison, aller en prison, caisse de communauté, chance, taxe de luxe
  {

    #region attributs
    private string nom;
    private string famille;
    int position;

    #endregion

    #region constructeur
    public Autres(int position, string nom)
    {
      this.position = position;
      this.nom = nom;
      famille = "autres";
    }
    #endregion

    // la classe possède des méthodes qui lui sont inutiles mais qui permettent d'utiliser ces fonctions sur les classes pour lesquelles elles sont utiles directement dans une liste de Case sans caster la case en question en propriété par exemple. 
    #region proprietes
    public override int getPosition()
    {
      return position;
    }
    public override Joueur getProprietaire()
    {
      return null;
    }
    public override void setProprietaire(Joueur joueur) { }
    override
    public string getNom()
    {
      return nom;
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
    public override string ToString()
    {
      return "Nom : " + nom;
    }
    public override bool getEstAchetee()
    {
      return false;
    }

    public override void setEstAchetee(bool value)
    {
      // fonction inutile
    }
    public override bool getEstHypothequee()
    {
      return false;
    }
    public override void setEstHypothequee(bool value)
    {
      // fonction inutile
    }
    public override int getNombreDeMaisons()
    {
      return -1;
    }

    public override void setNombreDeMaisons(int nombreDeMaisons)
    {
      // fonction inutile
    }

    public override string getFamille()
    {
      return famille;
    }

    #endregion
  }

}
