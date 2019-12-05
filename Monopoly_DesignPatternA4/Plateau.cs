using System;
using System.Collections.Generic;

namespace Monopoly_DesignPatternA4
{
  public class Plateau
  {
    // variable locale static qui permet de referencer l'instance de ma classe soit le plateau
    private static Plateau monPlateau = null;
    private static readonly object myLock = new object();
    public List<Case> mesCases;

    // constructeur privé afin qu'une autre classe ne puisse pas instancier un plateau de jeu sans passer par la fonction publique
    //qui verifie qu'il n'y a qu'une seule instance (singleton)
    private Plateau()
    {
      List<Case> mesCasesTemp = new List<Case>();
      // Construction des cartes du plateau de jeu
      Case caseDepart = CaseFactory.getCase("Autres", "Case depart");
      //Autres caseDepart = new Autres("Case départ");
      mesCasesTemp.Add(caseDepart);
      Case belleville = CaseFactory.getCase("propriete", "Boulevard De Belleville", 60, 30, 50, 2, 10, 30, 90, 160, 250);
      //Proporiete belleville = new Proporiete("Boulevard De Belleville", 60, 30, 50, 2, 10, 30, 90, 160, 250);
      mesCasesTemp.Add(belleville);

            //caseDepart.Suivante = belleville;
            Case commu1 = CaseFactory.getCase("autres", "Caise de Communauté");
            mesCasesTemp.Add(commu1);

            Case lecourbe = CaseFactory.getCase("propriete", "Rue Lecourbe", 60, 30, 50, 4, 20, 60, 180, 320, 450);
            mesCasesTemp.Add(lecourbe);

            Case impot = CaseFactory.getCase("autres", "impot");
            mesCasesTemp.Add(impot);

            Case gareMontparnasse = CaseFactory.getCase("gare", "Gare Montparnasse");
            mesCasesTemp.Add(gareMontparnasse);

            Case vaugirard = CaseFactory.getCase("propriete", "Rue de Vaugirard", 100, 50, 50, 6, 30, 90, 270, 400, 550);
            mesCasesTemp.Add(vaugirard);

            Case chance1 = CaseFactory.getCase("autres", "Chance");
            mesCasesTemp.Add(chance1);

            Case courcelle = CaseFactory.getCase("propriete", "Rue de Courcelle", 100, 50, 50, 6, 30, 90, 270, 400, 550);
            mesCasesTemp.Add(courcelle);

            Case republique = CaseFactory.getCase("propriete", "Avenue de la République", 120, 60, 50, 8, 40, 100, 350, 400, 600);
            mesCasesTemp.Add(republique);

            Case prison = CaseFactory.getCase("autres", "prison");
            mesCasesTemp.Add(prison);

            Case villette = CaseFactory.getCase("autres", "Boulevard de la Villette", 140, 70, 100, 10, 50, 150, 425, 625, 750);
            mesCasesTemp.Add(villette);

            Case compagnieElectricite = CaseFactory.getCase("compagnie", "Compagnie de Distribution d'electricite");
            mesCasesTemp.Add(compagnieElectricite);

            Case neuilly = CaseFactory.getCase("propriete", "Avenue de Neuilly", 140, 70, 100, 10, 50, 150, 425, 625, 750);
            mesCasesTemp.Add(neuilly);

            Case paradis = CaseFactory.getCase("propriete", "Rue du Paradis", 160, 80, 100, 12, 60, 180, 500, 700, 900);
            mesCasesTemp.Add(paradis);

            Case gareLyon = CaseFactory.getCase("gare", "Gare de Lyon");
            mesCasesTemp.Add(gareLyon);

            Case mozart = CaseFactory.getCase("propriete", "Avenue Mozart", 180, 90, 100, 14, 70, 200, 550, 750, 950);
            mesCasesTemp.Add(mozart);

            Case commu2 = CaseFactory.getCase("autres", "Caisse de Communauté");
            mesCasesTemp.Add(commu2);

            Case saintMichel = CaseFactory.getCase("propriete", "Boulevard Saint-Michel", 180, 90, 100, 14, 70, 200, 550, 750, 950);
            mesCasesTemp.Add(saintMichel);

            Case pigalle = CaseFactory.getCase("propriete", "Place Pigalle", 200, 100, 100, 16, 80, 220, 600, 800, 1000);
            mesCasesTemp.Add(pigalle);

            Case parcGratuit = CaseFactory.getCase("autres", "Parc Gratuit");
            mesCasesTemp.Add(parcGratuit);

            Case matignon = CaseFactory.getCase("Propriete", "Avenue Matignon", 220, 110, 150, 18, 90, 250, 700, 875, 1050);
            mesCasesTemp.Add(matignon);

            Case chance2 = CaseFactory.getCase("autres", "Chance");
            mesCasesTemp.Add(chance2);

            Case malesherbes = CaseFactory.getCase("propriete", "Boulevard Malesherbes", 220, 110, 150, 18, 90, 250, 700, 875, 1050);
            mesCasesTemp.Add(malesherbes);

            Case henriMartin = CaseFactory.getCase("propriete", "Avenue Henri-Martin", 240, 120, 150, 20, 100, 300, 750, 925, 1100);
            mesCasesTemp.Add(henriMartin);

            Case gareDuNord = CaseFactory.getCase("gare", "Gare du Nord");
            mesCasesTemp.Add(gareDuNord);

            Case saintHonore = CaseFactory.getCase("propriete", "Faubourg Saint-Honoré", 260, 130, 150, 22, 110, 330, 800, 975, 1150);
            mesCasesTemp.Add(saintHonore);

            Case bourse = CaseFactory.getCase("propriete", "Place de la Bourse", 260, 130, 150, 22, 110, 330, 800, 975, 1150);
            mesCasesTemp.Add(bourse);

            Case compagnieEau = CaseFactory.getCase("compagnie", "Compagnie de Distribution des Eaux");
            mesCasesTemp.Add(compagnieEau);

            Case fayette = CaseFactory.getCase("propriete", "Rue la Fayette", 280, 140, 150, 24, 120, 360, 850, 1025, 1200);
            mesCasesTemp.Add(fayette);

            Case allerPrison = CaseFactory.getCase("autres", "Aller en prison");
            mesCasesTemp.Add(allerPrison);

            Case breteuil = CaseFactory.getCase("propriete", "Avenue de Breteuil", 300, 150, 200, 26, 130, 390, 900, 1100, 1275);
            mesCasesTemp.Add(breteuil);

            Case foch = CaseFactory.getCase("propriete", "Avenue Foch", 300, 150, 200, 26, 130, 390, 900, 1100, 1275);
            mesCasesTemp.Add(foch);

            Case commu3 = CaseFactory.getCase("autres", "Caisse de Communauté");
            mesCasesTemp.Add(commu3);

            Case capucines = CaseFactory.getCase("propriete", "Boulevard des Capucines", 320, 160, 200, 28, 150, 450, 1000, 1200, 1400);
            mesCasesTemp.Add(capucines);

            Case gareSaintLazare = CaseFactory.getCase("gare", "Gare Saint-Lazare");
            mesCasesTemp.Add(gareSaintLazare);

            Case chance3 = CaseFactory.getCase("autres", "Chance");
            mesCasesTemp.Add(chance3);

            Case champElysee = CaseFactory.getCase("propriete", "Avenue des Champs-Elysées", 350, 175, 200, 35, 175, 500, 1100, 1300, 1500);
            mesCasesTemp.Add(champElysee);

            Case taxe = CaseFactory.getCase("autres", "Taxe de luxe");
            mesCasesTemp.Add(taxe);

            Case paix = CaseFactory.getCase("propriete", "Rue de la Paix", 400, 200, 200, 50, 200, 600, 1400, 1700, 2000);
            mesCasesTemp.Add(paix);

            mesCases = mesCasesTemp;
      
    }



    public static Plateau GetPlateau()
    {
      // lock permet d'empêcher plusieurs threads différents d'utiliser plusieurs une instance de notre plateau sencé être unique en même temps
      //et d'assurer d'en avoir un seul.
      lock ((myLock))
      {
        if (monPlateau == null) // si mon plateau n'existe pas encore on appelle le constructeur privé depuis la classe plateau qui créé un plateau.
          monPlateau = new Plateau();
        return monPlateau; // on retourne le plateau existant soit un nouveau plateau si celui-ci n'existait pas ou le plateau existant le cas contraire.
      }
    }
  }
}
