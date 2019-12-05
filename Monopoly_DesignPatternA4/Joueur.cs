using System;
using System.Collections.Generic;

namespace Monopoly_DesignPatternA4
{
  public class Joueur
  {
    string nom;
    int argent;
    List<Case> mesCases;
    int position; // 0 = case départ --> 39 = rue de la Paix
    bool enPrison;
    int nombreDeDoublesAffilé;


    public Joueur(string nom)
    {
      this.nom = nom;
      argent = 1500;
      position = 0;
      enPrison = false;
      nombreDeDoublesAffilé = 0;
    }

    public void Payer(int montant)
    {
      argent -= montant;
    }

    public void Recevoir(int montant)
    {
      argent += montant;
    }

    public void Acheter(Case caseActuelle)
    {
      argent -= caseActuelle.getPrix();
      caseActuelle.setEstAchetee(true);
      mesCases.Add(caseActuelle);
    }

    public void Hypothequer(Case maCase)
    {
      argent += maCase.getHypotheque();
      maCase.setEstHypothequee(true);
    }

    public void DesHypothequer(Case maCase)
    {
      argent -= maCase.getHypotheque();
      maCase.setEstHypothequee(false);
    }

    public void ConstruireMaisonOuHotel(Case maCase)
    {
      if (maCase.getNombreDeMaisons() <= 4)
      {
        argent -= maCase.getPrixMaison();
        maCase.setNombreDeMaisons(maCase.getNombreDeMaisons() + 1);
      }
      else
        Console.WriteLine("Vous avez déjà un hôtel sur votre propriété.");
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
      // gestion 
    }
  }
}
