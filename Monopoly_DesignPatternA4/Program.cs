using System;
using Monopoly_DesignPatternA4;

namespace Monopoly_ProjetFinal_DesignPattern
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Bienvenue dans ce jeu du Monopoly sur ordinateur créé par Nathan et Adrien.");
      Plateau plateau = Plateau.GetPlateau();

      Console.Write("Entrez le nombre de joueurs : ");
      int nbJoueurs = int.Parse(Console.ReadLine());
      Console.WriteLine();
      String[] nomJoueurs = new String[nbJoueurs];
      Joueur[] joueur = new Joueur[nbJoueurs];
      for(int i = 1; i <= nbJoueurs; i++)
      {
        string nom;
        Console.Write("Entrez le nom du joueur " + i + " : ");
        nom = Console.ReadLine();
        joueur[i - 1] = new Joueur(nom);
        plateau.NouveauJoueur(joueur[i - 1]);
        Console.WriteLine();
      }

      Console.WriteLine("\nAppuyer sur Entrer pour commencer la partie.\n");
      Console.ReadLine();
      Console.Clear();

     
      
      while(plateau.LesJoueurs.Count > 1)
      {
        foreach(Joueur j in plateau.LesJoueurs)
        {
          plateau.NombreDeDoubles = 0;
          plateau.JoueurActuel = j;
          plateau.Rejouer = true;
          while(plateau.Rejouer == true)
          {
            Console.Clear();
            Console.WriteLine("C'est au tour de " + j.Nom);
            Console.WriteLine("Vous avez actuellement " + j.Argent + "M.\n");
            Console.Write("Tapez 1 pour gérer vos propriétés ou autre chose pour lancer les dés : ");
            string gererProprio = Console.ReadLine();
            while(gererProprio == "1")
            {
              if (gererProprio == "1")
                j.GererProprietes();
              Console.Write("Tapez 1 pour gérer vos propriétés ou autre chose pour lancer les dés : ");
              gererProprio = Console.ReadLine();

            }

            plateau.LanceLesDes();
            if(j.EnPrison == true)
            {
              plateau.State = "Prison";
            }
            else
            {
              j.IndexPosition += plateau.LancerDeDe;
              if (j.EnPrison == false)
              {
                if (j.IndexPosition > 39)
                {
                  j.Position = plateau.MesCases[j.IndexPosition - 40];
                  j.IndexPosition -= 40;
                }
                else
                  j.Position = plateau.MesCases[j.IndexPosition];
                if (j.Position.getFamille() == "autres")
                {
                  plateau.State = j.Position.getNom();
                }
                else
                  plateau.State = "proprietes";
                Console.WriteLine("Vous êtes tombés sur la case : " + j.Position.getNom());
              }
            }
            plateau.Notify();
            
          }

          
          Console.WriteLine("Vous avez " + j.Argent + "M.");
          
         
          Console.WriteLine("\nAppuyez sur Entrer pour finir votre tour.\n");
          Console.ReadLine();
          Console.Clear();
        }
        if (plateau.JoueurActuel.Elimine == true)
          plateau.JoueurElimine(plateau.JoueurActuel);
      }

      Console.WriteLine(plateau.LesJoueurs[0].Nom + " a gagné la partie.");


      Console.ReadLine();


    }
  }
}






