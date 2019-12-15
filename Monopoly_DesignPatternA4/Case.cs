using System;
namespace Monopoly_DesignPatternA4
{
  public abstract class Case
  {
    // Toutes les cartes, propriétés, chances, case départ etc. sont des cases.
    // La classe abstraite case possède toutes les fonctions nécéssaire au fonctionnement du jeux comme obtenir le nombre de maisons
    // cela signifie que une gare par exemple aura également ces fonctions qui ne lui sont pas utiles et qui renvoient une valeur défaut.
    // cela permet d'utiliser ces méthodes directement sur une liste de case sans devoir caster la case en question selon ce que c'est et rend le programme plus facile même si c'est moins "beau"

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
