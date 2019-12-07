using System;
using Monopoly_DesignPatternA4;

namespace Monopoly_ProjetFinal_DesignPattern
{
  class Program
  {
    static void Main(string[] args)
    {

      Plateau plateau = Plateau.GetPlateau();
      Joueur adri = new Joueur("adrien");
      Joueur nathan = new Joueur("nathan");
      Console.WriteLine("avant achat null");
      Console.WriteLine(plateau.MesCases[1].getProprietaire());
      adri.Acheter(plateau.MesCases[1]);
      adri.Recevoir(60);
      adri.Payer(1499);
      nathan.Acheter(plateau.MesCases[39]);
      Console.WriteLine("apres achat adri");
      Console.WriteLine(plateau.MesCases[1].getProprietaire().Nom);
      
      Console.WriteLine("1");
      foreach (Joueur j in plateau.LesJoueurs)
      {
        Console.WriteLine(j);
      }

      nathan.Recevoir(0);
      Console.WriteLine("2");
      
      adri.Elimination(plateau.MesCases[39]);
      foreach (Joueur j in plateau.LesJoueurs)
      {
        Console.WriteLine(j);
      }
      Console.WriteLine("elimination adri nathan");

      Console.WriteLine(plateau.MesCases[1].getProprietaire());
      /*
      foreach (Case c in adri.MesCases)
      {
        Console.WriteLine(c.ToString());

      }
      */
      Console.ReadLine();


    }
  }
}






