using System;
using Monopoly_DesignPatternA4;

namespace Monopoly_ProjetFinal_DesignPattern
{
  class Program
  {
    static void Main(string[] args)
    {
      // Début du programme, on selectionne le nombre de joueurs et on entre leurs noms 

      Console.WriteLine("Bienvenue dans ce jeu du Monopoly sur ordinateur créé par Nathan et Adrien.");
      Plateau plateau = Plateau.GetPlateau();

      Console.Write("Entrez le nombre de joueurs : ");
      int nbJoueurs = int.Parse(Console.ReadLine());
      Console.WriteLine();
      String[] nomJoueurs = new String[nbJoueurs];
      Joueur[] joueur = new Joueur[nbJoueurs];
      for (int i = 1; i <= nbJoueurs; i++)
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


      // le jeu, tout se répète tant qu'il y a plusieurs joueurs en jeu. Sinon la partie est finie le dernier joueur étant le gagnant
      while (plateau.LesJoueurs.Count > 1)
      {
        // on initialise le nombre de tour a 0 au début du tour, le joueur j devient le joueur actuel et rejouer = true (devient faut quand le joueur ne fait pas de double où si il est en prison et qu'il faut un double)
        foreach (Joueur j in plateau.LesJoueurs)
        {
          plateau.NombreDeDoubles = 0;
          plateau.JoueurActuel = j;
          plateau.Rejouer = true;
          while (plateau.Rejouer == true)
          {
            
            Console.Clear();
            Console.WriteLine("C'est au tour de " + j.Nom);
            Console.WriteLine("Vous êtes sur " + j.Position.getNom());
            Console.WriteLine("Vous avez actuellement " + j.Argent + "M.\n");

            // propose de gérer les propriétés en début de tour.
            Console.Write("Tapez 1 pour gérer vos propriétés ou autre chose pour lancer les dés : ");
            string gererProprio = Console.ReadLine();
            while (gererProprio == "1")
            {
              if (gererProprio == "1")
                j.GererProprietes();
              Console.Write("Tapez 1 pour gérer vos propriétés ou autre chose pour lancer les dés : ");
              gererProprio = Console.ReadLine();
            }

            Console.WriteLine();

            // lancer de dé.
            plateau.LanceLesDes();

            // si il est en prison stat = prison donc le joueur n'avance pas
            if (j.EnPrison == true)
            {
              plateau.State = "Prison";
            }
            else if(plateau.State == "Triple double") 
            {
              // le joueur va aller en prison donc rien ne se passe
            }
            // sinon, le joueur avance et state prend la valeur de la case sur laquelle est tombé le joueur, la fonction notify est appelée puis la fonction update pour les joueurs.
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
                Console.WriteLine("Vous êtes tombés sur la case : " + j.Position.getNom() + "\n");
              }
            }
            plateau.Notify();
            Console.WriteLine("Vous avez " + j.Argent + "M.");
            Console.WriteLine("\nAppuyez sur Entrer pour finir votre tour.\n");
            Console.ReadLine();
          }
          Console.Clear();
        }
        // si le joueur a été éliminé pendant son tour, il 
        if (plateau.JoueurActuel.Elimine == true)
          plateau.JoueurElimine(plateau.JoueurActuel);
      }
      // il n'y a plus qu'un seul joueur il a gagné la partie.
      Console.WriteLine(plateau.LesJoueurs[0].Nom + " a gagné la partie.");
      Console.ReadLine();


    }
  }
}






