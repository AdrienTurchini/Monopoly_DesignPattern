using System;
namespace Monopoly_DesignPatternA4
{
  public class Autres : Case
  {
    string nom;
    Case precedente;
    Case suivante;

    bool estCaseDepart;
    bool estCaisseCommunaute;
    bool estChance;
    bool estPrison;
    bool estAllerEnPrison;
    bool estParcGratuit;
    bool estImpot;
    bool estTaxe;

    static int taxe;
    static int impots;
    static int caseDepart;
    int parcGratuit;
    


   

    public Autres(string nom, Case precedente, Case suivante, bool estCaseDepart, bool estCaisseCommunaute, bool estChance, bool estPrison, bool estAllerEnPrison, bool estParcGratuit, bool estImpot, bool estTaxe)
    {
      this.nom = nom;
      this.precedente = precedente;
      this.suivante = suivante;

      if(estCaseDepart == true && (estCaisseCommunaute == true || estChance == true || estPrison == true || estAllerEnPrison == true || estParcGratuit == true || estImpot == true || estTaxe == true))
      {
        ProblemeConstrurctionInstance();
      }
      if (estCaisseCommunaute == true && (estCaseDepart == true || estChance == true || estPrison == true || estAllerEnPrison == true || estParcGratuit == true || estImpot == true || estTaxe == true))
      {
        ProblemeConstrurctionInstance();
      }
      if (estChance == true && (estCaisseCommunaute == true || estCaseDepart == true || estPrison == true || estAllerEnPrison == true || estParcGratuit == true || estImpot == true || estTaxe == true))
      {
        ProblemeConstrurctionInstance();
      }
      if (estPrison == true && (estCaisseCommunaute == true || estChance == true || estCaseDepart == true || estAllerEnPrison == true || estParcGratuit == true || estImpot == true || estTaxe == true))
      {
        ProblemeConstrurctionInstance();
      }
      if (estAllerEnPrison == true && (estCaisseCommunaute == true || estChance == true || estPrison == true || estCaseDepart == true || estParcGratuit == true || estImpot == true || estTaxe == true))
      {
        ProblemeConstrurctionInstance();
      }
      if (estParcGratuit == true && (estCaisseCommunaute == true || estChance == true || estPrison == true || estAllerEnPrison == true || estCaseDepart == true || estImpot == true || estTaxe == true))
      {
        ProblemeConstrurctionInstance();
      }
      if (estImpot == true && (estCaisseCommunaute == true || estChance == true || estPrison == true || estAllerEnPrison == true || estParcGratuit == true || estCaseDepart == true || estTaxe == true))
      {
        ProblemeConstrurctionInstance();
      }
      if (estTaxe == true && (estCaisseCommunaute == true || estChance == true || estPrison == true || estAllerEnPrison == true || estParcGratuit == true || estImpot == true) || estCaseDepart == true)
      {
        ProblemeConstrurctionInstance();
      }

      if (estCaseDepart)
        caseDepart = 200;
      if (estParcGratuit)
        parcGratuit = 0;
      if (estImpot)
        impots = 200;
      if (estTaxe)
        taxe = 100;
    }

    public override string Nom { get { return nom; } }
    public override Case Precedente { get { return precedente; } set { precedente = value; } }
    public override Case Suivante { get { return suivante; } set { suivante = value; } }

    // permet d'être sur qu'une carte ne peut pas être une chance, communauté, parc gratuit, case départ, aller en prison, prison, impots ou taxe
    private void ProblemeConstrurctionInstance()
    {
      Console.Write("Probleme : entrer depart pour case départ, cc pour caisse de communaute, chance pour chance, prison pour prison, allerprison pour aller en prison, gratuit pour parc gratuit, impots pout impots ou taxe pour taxe : ");
      string input = Console.ReadLine();
      Console.WriteLine();
      while (input != "depart" || input != "cc" || input != "chance" || input != "prison" || input != "allerprison" || input != "gratuit" || input != "impots" || input != "taxe")
      {
        input = Console.ReadLine();
      }
      if (input == "depart")
      {
        this.estCaseDepart = true;
        this.estAllerEnPrison = false;
        this.estCaisseCommunaute = false;
        this.estChance = false;
        this.estParcGratuit = false;
        this.estPrison = false;
        this.estImpot = false;
      }
      else if(input == "cc")
      {
        this.estCaseDepart = false;
        this.estAllerEnPrison = false;
        this.estCaisseCommunaute = true;
        this.estChance = false;
        this.estParcGratuit = false;
        this.estPrison = false;
        this.estImpot = false;
      }
      else if(input == "chance")
      {
        this.estCaseDepart = false;
        this.estAllerEnPrison = false;
        this.estCaisseCommunaute = false;
        this.estChance = true;
        this.estParcGratuit = false;
        this.estPrison = false;
        this.estImpot = false;
      }
      else if(input == "prison")
      {
        this.estCaseDepart = false;
        this.estAllerEnPrison = false;
        this.estCaisseCommunaute = false;
        this.estChance = false;
        this.estParcGratuit = false;
        this.estPrison = true;
        this.estImpot = false;
      }
      else if(input == "allerprison")
      {
        this.estCaseDepart = false;
        this.estAllerEnPrison = true;
        this.estCaisseCommunaute = false;
        this.estChance = false;
        this.estParcGratuit = false;
        this.estPrison = false;
        this.estImpot = false;
      }
      else if(input == "gratuit")
      {
        this.estCaseDepart = false;
        this.estAllerEnPrison = false;
        this.estCaisseCommunaute = false;
        this.estChance = false;
        this.estParcGratuit = true;
        this.estPrison = false;
        this.estImpot = false;
      }
      else if(input == "impots")
      {
        this.estCaseDepart = false;
        this.estAllerEnPrison = false;
        this.estCaisseCommunaute = false;
        this.estChance = false;
        this.estParcGratuit = false;
        this.estPrison = false;
        this.estImpot = true;
      }
      else
      {
        this.estCaseDepart = false;
        this.estAllerEnPrison = false;
        this.estCaisseCommunaute = false;
        this.estChance = false;
        this.estParcGratuit = false;
        this.estPrison = false;
        this.estImpot = false;
        this.estTaxe = true;
      }
    }
  }
}
