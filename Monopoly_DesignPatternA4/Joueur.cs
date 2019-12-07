using System;
using System.Collections.Generic;

namespace Monopoly_DesignPatternA4
{
  public class Joueur
  {
    #region attributs
    string nom;
    int argent;
    List<Case> mesCases;
    int position; // 0 = case départ --> 39 = rue de la Paix
    bool enPrison;
    int nombreDoubles;
    int marron;
    int bleupale;
    int rose;
    int orange;
    int rouge;
    int jaune;
    int vert;
    int bleufonce;
    int gare;
    int compagnie;
    #endregion

    #region propriétés
    public string Nom { get { return nom; } }
    public int Argent { get { return argent; } set { argent = value; } }
    public List<Case> MesCases { get { return mesCases; } }
    public int Position { get { return position; } set { position = value; } }
    public bool EnPrison { get { return enPrison; } set { enPrison = value; } }
    public int NombreDoubles { get { return nombreDoubles; } set { nombreDoubles = value; } }
    public int Marron { get { return marron; } }
    public int Bleupale { get { return bleupale; } }
    public int Rose { get { return rose; } }
    public int Orange { get { return orange; } }
    public int Rouge { get { return rouge; } }
    public int Jaune { get { return jaune; } }
    public int Vert { get { return vert; } }
    public int Bleufonce { get { return bleufonce; } }
    public int Gare { get { return gare; } }
    public int Compagnie { get { return compagnie; } }
    #endregion

    #region constrcteur
    public Joueur(string nom)
    {
      this.nom = nom;
      argent = 1500;
      position = 0;
      enPrison = false;
      nombreDoubles = 0;
      List<Case> tempCase = new List<Case> { };
      mesCases = tempCase;
      Plateau.NouveauJoueur(this);


    }
    #endregion


    #region methodes

    public void Payer(int montant)
    {
      if(argent - montant >= 0)
      {
        argent -= montant;
      }
      else
      {
        Console.WriteLine("Vous n'avez pas assez d'argent pour payer (" + argent + "M).\nVeuillez enlever des maisons si vous en avez ou hypothequer vos biens si cela est possible.\n Si vous n'avez pas de quoi payer vous avez perdu.");
        bool peutHypothequer = true;
        bool peutVendre = true;
        while((peutHypothequer == true || peutVendre == true) && (argent - montant < 0))
        {
          peutHypothequer = false;
          peutVendre = false;
          for(int i = 0; i < mesCases.Count; i++)
          {
            if (mesCases[i].getEstHypothequee() == false)
              peutHypothequer = true;
            if (mesCases[i].getNombreDeMaisons() >= 1)
              peutVendre = true;
          }
          if (peutHypothequer == true || peutVendre == true)
            GererProprietes();
        }
        if (argent - montant >= 0)
          argent -= montant;
        else
          Console.WriteLine("Vous êtes éliminés.");
      }
      
    }

    public void AjouterJoueurPlateau()
    {

    }
    public void Elimination(Case caseActuelle)
    {
      if(caseActuelle.getFamille() == "autres" || caseActuelle.getProprietaire() == null)
      {
        foreach(Case c in mesCases)
        {
          c.setEstAchetee(false);
          c.setEstHypothequee(false);
          c.setNombreDeMaisons(0);
          c.setProprietaire(null);
        }
      }
      else
      {
        foreach(Case c in mesCases)
        {
          c.setEstHypothequee(false);
          caseActuelle.getProprietaire().Recevoir(c.getPrix());
          caseActuelle.getProprietaire().Acheter(c);
        }
        caseActuelle.getProprietaire().Recevoir(argent);
      }
      Plateau.JoueurElimine(this);
    }

    public void Recevoir(int montant)
    {
      argent += montant;
    }

    public void Acheter(Case caseActuelle)
    {
      if (argent - caseActuelle.getPrix() >= 0 && caseActuelle.getPrix() > 0) 
      {
        argent -= caseActuelle.getPrix();
        caseActuelle.setEstAchetee(true);
        mesCases.Add(caseActuelle);
        caseActuelle.setProprietaire(this);

        if (caseActuelle.getFamille() == "compagnie")
          compagnie++;
        if (caseActuelle.getFamille() == "gare")
          gare++;
        if (caseActuelle.getFamille() == "marron")
          marron++;
        if (caseActuelle.getFamille() == "bleupale")
          bleupale++;
        if (caseActuelle.getFamille() == "rose")
          rose++;
        if (caseActuelle.getFamille() == "orange")
          orange++;
        if (caseActuelle.getFamille() == "rouge")
          rouge++;
        if (caseActuelle.getFamille() == "jaune")
          jaune++;
        if (caseActuelle.getFamille() == "vert")
          vert++;
        if (caseActuelle.getFamille() == "bleufonce")
          bleufonce++;
      }
      else
        Console.WriteLine("Vous n'avez pas assez d'argent");
      
    }

    public void Hypothequer(Case maCase)
    {
      if (maCase.getEstHypothequee() == false)
      {
        argent += maCase.getHypotheque();
        maCase.setEstHypothequee(true);
        if (maCase.getFamille() == "compagnie")
          compagnie--;
        if (maCase.getFamille() == "gare")
          gare--;
        if (maCase.getFamille() == "marron")
          marron--;
        if (maCase.getFamille() == "bleupale")
          bleupale--;
        if (maCase.getFamille() == "rose")
          rose--;
        if (maCase.getFamille() == "orange")
          orange--;
        if (maCase.getFamille() == "rouge")
          rouge--;
        if (maCase.getFamille() == "jaune")
          jaune--;
        if (maCase.getFamille() == "vert")
          vert--;
        if (maCase.getFamille() == "bleufonce")
          bleufonce--;
      }
      else
        Console.WriteLine("Votre carte est déjà hypothequée.");
    }

    public void DesHypothequer(Case maCase)
    {
      if (maCase.getEstHypothequee() == true)
      {
        if ((argent - maCase.getHypotheque()) >= 0)
        {
          argent -= maCase.getHypotheque();
          maCase.setEstHypothequee(false);
          if (maCase.getFamille() == "compagnie")
            compagnie++;
          if (maCase.getFamille() == "gare")
            gare++;
          if (maCase.getFamille() == "marron")
            marron++;
          if (maCase.getFamille() == "bleupale")
            bleupale++;
          if (maCase.getFamille() == "rose")
            rose++;
          if (maCase.getFamille() == "orange")
            orange++;
          if (maCase.getFamille() == "rouge")
            rouge++;
          if (maCase.getFamille() == "jaune")
            jaune++;
          if (maCase.getFamille() == "vert")
            vert++;
          if (maCase.getFamille() == "bleufonce")
            bleufonce++;
        }
        else
          Console.WriteLine("Vous n'avez pas assez d'argent.");
      }
      else
        Console.WriteLine("Votre carte est déjà déshypotheuée.");
      
    }

    public void ConstruireMaisonOuHotel(Case maCase)
    {
      if ((argent - maCase.getPrixMaison()) >= 0)
      {
        if (maCase.getFamille() == "compagnie")
          Console.WriteLine("Vous ne pouvez pas construire sur une comapgnie.");
        else if (maCase.getFamille() == "gare")
          Console.WriteLine("Vous ne pouvez pas construire sur une gare.");
        else if (maCase.getFamille() == "marron" && marron != 2)
          Console.WriteLine("Vous n'avez pas toutes les cartes de la même famille où l'une d'elle est hypothequée.");
        else if (maCase.getFamille() == "bleupale" && bleupale != 3)
          Console.WriteLine("Vous n'avez pas toutes les cartes de la même famille où l'une d'elle est hypothequée.");
        else if (maCase.getFamille() == "rose" && rose != 3)
          Console.WriteLine("Vous n'avez pas toutes les cartes de la même famille où l'une d'elle est hypothequée.");
        else if (maCase.getFamille() == "orange" && orange != 3)
          Console.WriteLine("Vous n'avez pas toutes les cartes de la même famille où l'une d'elle est hypothequée.");
        else if (maCase.getFamille() == "rouge" && rouge != 3)
          Console.WriteLine("Vous n'avez pas toutes les cartes de la même famille où l'une d'elle est hypothequée.");
        else if (maCase.getFamille() == "jaune" && jaune != 3)
          Console.WriteLine("Vous n'avez pas toutes les cartes de la même famille où l'une d'elle est hypothequée.");
        else if (maCase.getFamille() == "vert" && vert != 3)
          Console.WriteLine("Vous n'avez pas toutes les cartes de la même famille où l'une d'elle est hypothequée.");
        else if (maCase.getFamille() == "bleufonce" && bleufonce != 2)
          Console.WriteLine("Vous n'avez pas toutes les cartes de la même famille où l'une d'elle est hypothequée.");
        else if (maCase.getNombreDeMaisons() < 5)
        {
          argent -= maCase.getPrixMaison();
          maCase.setNombreDeMaisons(maCase.getNombreDeMaisons() + 1);
        }
        else
          Console.WriteLine("Vous avez déjà un hôtel sur votre propriété.");
      }
      else
        Console.WriteLine("Vous n'avez pas assez d'argent.");
    }

    public void VendreMaisonOuHotel(Case maCase)
    {
      if (maCase.getNombreDeMaisons() > 0)
      {
        argent += maCase.getPrixMaison()/2;
        maCase.setNombreDeMaisons(maCase.getNombreDeMaisons() - 1);
      }
      else
        Console.WriteLine("Vous n'avez pas de maisons sur cette propriété.");
    }

    public void GererProprietes()
    {
      Console.WriteLine("Voici la liste de vos propriétés : ");
      int nbDeProprietes = mesCases.Count;
      int compteur = 1;
      foreach (Case c in mesCases)
      {
        Console.WriteLine(compteur + " : "+ c.getNom() + ", est hypothequée : " + c.getEstHypothequee() + ", Nombre de maisons (5 = hôtel) : " + c.getNombreDeMaisons());
        compteur++;
      }
        
      Console.Write("Entrez le numéro indiqué dans la la lite de la propriété que vous souhaitez gérer : ");
      string verifEntry = " ";
      int numero = 0;
      bool isNumber = false;
      while(!isNumber)
      {
        verifEntry = Console.ReadLine();
        isNumber = int.TryParse(verifEntry, out numero);
        if (isNumber == false)
          Console.WriteLine("Veuillez entrer un numéro :");
        else if(numero < 1 || numero > nbDeProprietes)
        {
          Console.WriteLine("Veuillez entrer le numéro indiqué au début de la ligne de chaque propriété : ");
          isNumber = false;
        }
      }

      Console.WriteLine("Vous avez " + argent + "M");
      Console.Write("\nTapez 1 pour Construire des maisons, 2 pour Vendre des maisons, 3 pour hypothequer, 4 pour déshypothequer, 5 pour quitter : ");
      Console.WriteLine();
      string choice = "";
      choice = Console.ReadLine();
      while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
      {
        Console.Write("Tapez 1 pour Construire des maisons, 2 pour Vendre des maisons, 3 pour hypothequer, 4 pour déshypothequer, 5 pour quitter : ");
        choice = Console.ReadLine();
        Console.WriteLine();
      }
      switch (choice)
      {
        case "1":
          ConstruireMaisonOuHotel(mesCases[numero - 1]);
          break;
        case "2":
          VendreMaisonOuHotel(mesCases[numero - 1]);
          break;
        case "3":
          Hypothequer(mesCases[numero - 1]);
          break;
        case "4":
          DesHypothequer(mesCases[numero - 1]);
          break;
        case "5":
          break;
      }
    }

    public override string ToString()
    {
      string myString = "";
      myString = "Nom : " + nom + " / Argent : " + argent + "\n\tMes propriétés :";
      foreach (Case c in mesCases)
        myString += "\n\t" + c;
      return myString;
    }

    #endregion


  }
}