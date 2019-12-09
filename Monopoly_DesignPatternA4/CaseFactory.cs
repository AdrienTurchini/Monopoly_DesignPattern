using System;

namespace Monopoly_DesignPatternA4
{
    public class CaseFactory
    {
    public static Case getCase(int position, string type, string nom) // gare, comagnie et autres
        {
            if ("gare".Equals(type))
            {
                return new Gare(position,nom);
            }
            else if ("compagnie".Equals(type))
            {
                return new Compagnie(position,nom);
            }
            else
            {
                return new Autres(position,nom);
            }
        }

        public static Case getCase(int position,string type, string famille, string nom, int prix, int valeurHypotheque, int prixMaison, int loyerSimple, int loyer1Maison, int loyer2Maisons, int loyer3Maisons, int loyer4Maisons, int loyerHotel)
        {
            return new Proporiete(position,famille, nom, prix, valeurHypotheque, prixMaison, loyerSimple, loyer1Maison, loyer2Maisons, loyer3Maisons, loyer4Maisons, loyerHotel);
            
        }
    }
}
