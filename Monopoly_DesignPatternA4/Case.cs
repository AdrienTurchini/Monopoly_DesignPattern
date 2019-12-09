using System;
namespace Monopoly_DesignPatternA4
{
  public abstract class Case
  {
    public abstract int getPosition();
    public abstract string getNom();
    public abstract int getPrix();
    public abstract int getHypotheque();
    public abstract int getPrixMaison();
    public abstract int getLoyer();
    public abstract int getLoyer1Maison();
    public abstract int getLoyer2Maison();
    public abstract int getLoyer3Maison();
    public abstract int getLoyer4Maison();
    public abstract int getHotel();
    public abstract int getNombreDeMaisons();

    public abstract bool getEstAchetee();
    public abstract void setEstAchetee(bool value);
    public abstract bool getEstHypothequee();
    public abstract void setEstHypothequee(bool value);
    public abstract void setNombreDeMaisons(int nombreDeMaisons);
    public abstract string getFamille();
    public abstract Joueur getProprietaire();
    public abstract void setProprietaire(Joueur joueur);




  }
}
