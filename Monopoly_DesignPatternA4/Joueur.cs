using System;
using System.Collections.Generic;

namespace Monopoly_DesignPatternA4
{
  public class Joueur : IObserver
  {
    #region attributs
    string nom;
    int argent;
    List<Case> mesCases = new List<Case>();
    Case position; 
    int indexPosition; // 0 = case départ --> 39 = rue de la Paix, pas indispensable mais facilite le projet 
    bool enPrison; // si le joueur est en prison ou non
    int nombreTourPrison; // depuis combien de tour il est en prison --> 3 il sort
    int marron; // permet de savoir si le joueur à les 2 cartes marrons pour construire des maisons
    int bleupale; // idem
    int rose; // idem
    int orange; // idem
    int rouge; // idem
    int jaune; // idem
    int vert; // idem
    int bleufonce; // idem
    int gare; // permet de savoir combien de gares à le joueur sans parcourir toutes ses propriétés
    int compagnie; // permet de savoir combien de comagnies à le joueur sans parcourir toutes ses propriétés
    bool elimine; // lorsque le joueur est elimine devient true et permet de le supprimer de la liste des joueurs par la suite  
    #endregion

    #region propriétés
    public string Nom { get { return nom; } }
    public int Argent { get { return argent; } set { argent = value; } }
    public List<Case> MesCases { get { return mesCases; } }
    public Case Position { get { return position; } set { position = value; } }
    public bool EnPrison { get { return enPrison; } set { enPrison = value; } }
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
    public int NombreTourPrison { get { return nombreTourPrison; } }
    public int IndexPosition { get { return indexPosition; } set { indexPosition = value; } }
    public bool Elimine { get { return elimine; } set { elimine = value; } }
    #endregion

    #region constrcteur
    public Joueur(string nom)
    {
      elimine = false;
      this.nom = nom;
      argent = 1500;
      indexPosition = 0;
      position = Plateau.GetPlateau().MesCases[0];
      enPrison = false;
      nombreTourPrison = 0;
    }
    #endregion

    #region methodes

    // enleve de l'argent au joueur.
    // Si il ne peut pas payer invoque la methode gestion de propriétés jusqu'à ce que le joueur ai tout hypothequé et n'est plus de maison à vendre.
    // Dans le cas ou le joueur ne peut plus payer et ne peut plus récupérer d'argent en vendant ou hypothequant invoque la fonction elimination pour l'éliminer
    public void Payer(int montant)
    {
      if (argent - montant >= 0)
      {
        argent -= montant;
      }
      else
      {
        Console.WriteLine("Vous n'avez pas assez d'argent pour payer (" + argent + "M).\nVeuillez enlever des maisons si vous en avez ou hypothequer vos biens si cela est possible.\n Si vous n'avez pas de quoi payer vous avez perdu.");
        bool peutHypothequer = true;
        bool peutVendre = true;
        while ((peutHypothequer == true || peutVendre == true) && (argent - montant < 0))
        {
          peutHypothequer = false;
          peutVendre = false;
          for (int i = 0; i < mesCases.Count; i++)
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
        {
          Elimination(position);
        }
      }
    }

    // si le joueur s'est fait éliminé en tombant sur la propriété d'un adversaire, l'adversaire recoit l'argent du joueur + ses propriétés déshypothequées
    // si le joueur se fait éliminé par la banque (impots taxes chance communauté) dans ce cas ses propriétés sont remises en jeu 
    public void Elimination(Case caseActuelle)
    {
      if (caseActuelle.getFamille() == "autres" || caseActuelle.getProprietaire() == null)
      {
        foreach (Case c in mesCases)
        {
          c.setEstAchetee(false);
          c.setEstHypothequee(false);
          c.setNombreDeMaisons(0);
          c.setProprietaire(null);
        }
      }
      else
      {
        foreach (Case c in mesCases)
        {
          c.setEstHypothequee(false);
          caseActuelle.getProprietaire().Recevoir(c.getPrix());
          caseActuelle.getProprietaire().Acheter(c);
        }
        caseActuelle.getProprietaire().Recevoir(argent);
      }
      elimine = true;
    }

    // methode pour recevoir de l'argent 
    public void Recevoir(int montant)
    {
      argent += montant;
    }

    // methode pour acheter la case sur laquelle le joueur est tombé
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

    // méthode pour hypothequer une propriété
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

    // méthode pour déshypothequer une propriété
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
        Console.WriteLine("Votre carte est déjà déshypothequée.");

    }

    // méthode pour construire une maison/hotel sur une propriété
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

    // méthode pour vendre a moitié prix une maison/hotel sur une propriété
    public void VendreMaisonOuHotel(Case maCase)
    {
      if (maCase.getNombreDeMaisons() > 0)
      {
        argent += maCase.getPrixMaison() / 2;
        maCase.setNombreDeMaisons(maCase.getNombreDeMaisons() - 1);
      }
      else
        Console.WriteLine("Vous n'avez pas de maisons sur cette propriété.");
    }

    // méthode pour gerer ses propriétés : au choix construire/vendre des maisons/hotel, hypothequer et déshypothéquer.
    public void GererProprietes()
    {
      if (mesCases.Count > 0)
      {
        Console.WriteLine("Voici la liste de vos propriétés : ");
        int nbDeProprietes = mesCases.Count;
        int compteur = 1;
        foreach (Case c in mesCases)
        {
          Console.Write(compteur + " : " + c.getNom() + ", est hypothequée : " + c.getEstHypothequee());
          if(c.getFamille() == "marron" || c.getFamille() == "bleupale" || c.getFamille() == "rose" || c.getFamille() == "orange" || c.getFamille() == "rouge" || c.getFamille() == "jaune" || c.getFamille() == "vert" || c.getFamille() == "bleufonce")
          {
            Console.Write(", Nombre de maisons (5 = hôtel) : " + c.getNombreDeMaisons());
          }
          Console.WriteLine();
          compteur++;
        }

        Console.Write("Entrez le numéro indiqué dans la la lite de la propriété que vous souhaitez gérer : ");
        string verifEntry = " ";
        int numero = 0;
        bool isNumber = false;
        while (!isNumber)
        {
          verifEntry = Console.ReadLine();
          isNumber = int.TryParse(verifEntry, out numero);
          if (isNumber == false)
            Console.WriteLine("Veuillez entrer un numéro :");
          else if (numero < 1 || numero > nbDeProprietes)
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
      else
        Console.WriteLine("Vous n'avez pas encore de propriétés\n");
    }

    public override string ToString()
    {
      string myString = "";
      myString = "Nom : " + nom + " / Argent : " + argent + "\n\tMes propriétés :";
      foreach (Case c in mesCases)
        myString += "\n\t" + c;
      return myString;
    }

    // comme dans notre cas le plateau est l'unique subject pouvant activer la fonction update, pour une question de lisibilité et simplicité nous avons directement prit le plateau comme argument et non ISubject subject
    // cette méthode permet d'actualiser les observeurs (joueurs). Elle est appelée à chaque fois qu'un joueur lance les dés et tombe sur une case.
    // propose d'acheter si possible, fait payer si la propriété est achetée, fait payer si la case est les impots ou taxe de luxe, envoie en prison si c'est le cas, donne 400M si c'est la case départ (200 + 200 bonus)
    // si le joueur est en prison augmente le compteur du nombre de tour en prison effectué et le place en visite simple si cela fait 3 tours déjà.
    // fait gagner ou perdre de l'argent si c'est une case chance ou caisse de communauté (elles sont identiques dans notre version de jeu).
    // fait gagner 200M a chaque fois que le joueur passe par la case déprt
    public void Update(Plateau plateau)
    {
      if (plateau.JoueurActuel == this)
      {
        if ((position.getPosition() - plateau.LancerDeDe < 0) && enPrison == false && plateau.State != "Triple Double")
        {
          Recevoir(200);
        }
        if (plateau.State == "Aller en prison" || plateau.State == "Triple double")
        {
          position = plateau.MesCases[10];
          indexPosition = 10; 
          enPrison = true;
          nombreTourPrison = 0;
        }
        else if (plateau.State == "proprietes")
        {

          if (position.getEstAchetee() == false)
          {
            Console.WriteLine("Cette carte est libre. Voici ses caractéristiques :");
            Console.WriteLine(position);
            Console.WriteLine("\nVoulez-vous acheter cette carte ? Entrez Oui ou Non : ");
            string ouiOuNon = "";
            ouiOuNon = Console.ReadLine();
            while (ouiOuNon.ToLower() != "oui" && ouiOuNon.ToLower() != "non")
            {
              Console.WriteLine("Entrez Oui ou Non : ");
              ouiOuNon = Console.ReadLine();
            }
            if (ouiOuNon.ToLower() == "oui")
              Acheter(position);
          }
          else if (position.getEstHypothequee() == false && position.getProprietaire() != this)
          {
            Console.WriteLine("La carte est au joueur " + position.getProprietaire().Nom);
            if (position.getFamille() == "marron" || position.getFamille() == "bleupale" || position.getFamille() == "rose" || position.getFamille() == "orange" || position.getFamille() == "rouge" || position.getFamille() == "jaune" || position.getFamille() == "vert" || position.getFamille() == "bleufonce")
            {
              if (position.getNombreDeMaisons() == 0)
              {
                Console.WriteLine("Vous payer un loyer simple de " + position.getLoyer());
                Payer(position.getLoyer());
                position.getProprietaire().Recevoir(position.getLoyer());
              }
              else if (position.getNombreDeMaisons() == 1)
              {
                Console.WriteLine("Vous payer un loyer 1 maison de " + position.getLoyer1Maison());
                Payer(position.getLoyer1Maison());
                position.getProprietaire().Recevoir(position.getLoyer1Maison());
              }

              else if (position.getNombreDeMaisons() == 2)
              {
                Console.WriteLine("Vous payer un loyer 2 maisons de " + position.getLoyer2Maison());
                Payer(position.getLoyer2Maison());
                position.getProprietaire().Recevoir(position.getLoyer2Maison());
              }

              else if (position.getNombreDeMaisons() == 3)
              {
                Console.WriteLine("Vous payer un loyer 3 maisons de " + position.getLoyer3Maison());
                Payer(position.getLoyer3Maison());
                position.getProprietaire().Recevoir(position.getLoyer3Maison());
              }

              else if (position.getNombreDeMaisons() == 4)
              {
                Console.WriteLine("Vous payer un loyer 4 maisons de " + position.getLoyer4Maison());
                Payer(position.getLoyer4Maison());
                position.getProprietaire().Recevoir(position.getLoyer4Maison());

              }
              else
              {
                Console.WriteLine("Vous payer un loyer hôtel " + position.getHotel());
                Payer(position.getHotel());
                position.getProprietaire().Recevoir(position.getHotel());
              }
            }
            else if (position.getFamille() == "gare")
            {
              Console.Write("Vous payez le loyer pour " + position.getProprietaire().gare + " gares soit ");
              if (position.getProprietaire().gare == 1)
              {
                Console.WriteLine("25M.");
                Payer(25);
                position.getProprietaire().Recevoir(25);

              }
              if (position.getProprietaire().gare == 2)
              {
                Console.WriteLine("50M.");
                Payer(50);
                position.getProprietaire().Recevoir(50);
              }
              if (position.getProprietaire().gare == 3)
              {
                Console.WriteLine("100M.");
                Payer(100);
                position.getProprietaire().Recevoir(100);
              }
              if (position.getProprietaire().gare == 4)
              {
                Console.WriteLine("200M.");
                Payer(200);
                position.getProprietaire().Recevoir(200);
              }
            }
            else
            {
              Console.Write("Vous payez le loyer de " + position.getProprietaire().compagnie + " compagnie donc ");
              if (position.getProprietaire().compagnie == 1)
              {
                Console.WriteLine("4 fois le montant de vos dés (" + plateau.LancerDeDe + ") soit " + plateau.LancerDeDe * 4);
                Payer(plateau.LancerDeDe * 4);
                position.getProprietaire().Recevoir(plateau.LancerDeDe * 4);
              }
              if (position.getProprietaire().compagnie == 2)
              {
                Console.WriteLine("10 fois le montant de vos dés (" + plateau.LancerDeDe + ") soit " + plateau.LancerDeDe * 10);
                Payer(plateau.LancerDeDe * 10);
                position.getProprietaire().Recevoir(plateau.LancerDeDe * 10);
              }
            }
          }
          else
          {
            if(position.getProprietaire() == this)
            {
              Console.WriteLine("Vous êtes chez vous.");
            }
            else
            {
              Console.WriteLine("La carte est hypothequée vous n'avez rien a payer.");
            }
            
          }
            
        }
        else if (plateau.State == "Case Départ")
        {
          Console.WriteLine("Vous recevez 400M.");
          Recevoir(400);
          Payer(200); // car le joueur reçoit également 200 comme il a finit le tour et passe par la case départ
        }
        else if (plateau.State == "Parc Gratuit")
        {
          Console.WriteLine("Vous recevez " + plateau.ParcGrauit + "M.");
          Recevoir(plateau.ParcGrauit);
          plateau.ParcGrauit = 0;
        }
        else if (plateau.State == "Prison" && enPrison == true)
        {
          nombreTourPrison++;
          Console.WriteLine("Ceci est votre " + nombreTourPrison + " tour de prison.");
          if (nombreTourPrison == 3)
          {
            Console.WriteLine("Vous êtes libérés de prison car vous y avez passé 3 tours. Vous pourrez avancer au prochain tour.");
            enPrison = false;
          }
          
        }
        else if (plateau.State == "Impôts")
        {
          Console.WriteLine("Vous payer les impôts 200M.");
          Payer(200);
          plateau.ParcGrauit += 200;
        }
        else if (plateau.State == "Taxe de luxe")
        {
          Console.WriteLine("Vous payer la Taxe de Luxe 200M.");
          Payer(150);
          plateau.ParcGrauit += 150;
        }
        else if (plateau.State == "Caisse de Communauté" || plateau.State == "Chance")
        {
          Random random = new Random();
          int i = random.Next(6);
          if(i == 0)
          {
            Console.WriteLine("Vous avez gagné le concours de beauté. Recevez 10M.\n");
            Recevoir(10);
          }
          else if(i == 1)
          {
            Console.WriteLine("C'est votre anniversaire. Recevez 20M.\n");
            Recevoir(20);
          }
          else if(i == 2)
          {
            Console.WriteLine("Vous avez gagné le prix de mot croisé. Recevez 15M.\n");
            Recevoir(15);
          }
          else if(i == 3)
          {
            Console.WriteLine("Vous avez perdu votre porte-monnaie qui contenaît 10M.\n");
            Payer(10);
            plateau.ParcGrauit += 10;
          }
          else if(i == 4)
          {
            Console.WriteLine("La banque vous a versé trop d'argent la semaine dernière. Remboursez 25M.\n");
            Payer(25);
            plateau.ParcGrauit += 25;
          }
          else if(i == 5)
          {
            Console.WriteLine("La banque vous verse un dividende de 50M.\n");
            Recevoir(50);
          }
        }
        
        
      }
    }
    #endregion

  }
}
