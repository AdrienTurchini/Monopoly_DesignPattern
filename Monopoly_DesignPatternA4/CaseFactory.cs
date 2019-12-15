using System;

namespace Monopoly_DesignPatternA4
{
  public class CaseFactory
  {
    // selon le nombre de paramètres entrés renvoie vers le constructeur des propriétés ou selon le type rentré vers le constructeur de gare, comapgnie ou autre 
    public static Case getCase(int position, string type, string nom) // gare, comagnie et autres
    {
      if ("gare".Equals(type))
      {
        return new Gare(position, nom);
      }
      else if ("compagnie".Equals(type))
      {
        return new Compagnie(position, nom);
      }
      else
      {
        return new Autres(position, nom);
      }
    }

    // renvoie vers le constructeur des propriétés
    public static Case getCase(int position, string type, string famille, string nom, int prix, int valeurHypotheque, int prixMaison, int loyerSimple, int loyer1Maison, int loyer2Maisons, int loyer3Maisons, int loyer4Maisons, int loyerHotel)
    {
      return new Proporiete(position, famille, nom, prix, valeurHypotheque, prixMaison, loyerSimple, loyer1Maison, loyer2Maisons, loyer3Maisons, loyer4Maisons, loyerHotel);
    }
  }
}
