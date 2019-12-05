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
      //Autres commu1 = new Autres("Caisse de Communauté");
      //mesCasesTemp.Add(commu1);

      //belleville.Suivante = commu1;
      //Proporiete lecourbe = new Proporiete("Rue Lecourbe", 60, 30, 50, 4, 20, 60, 180, 320, 450);
      //mesCasesTemp.Add(lecourbe);
      /*
      commu1.Suivante = lecourbe;
      Autres impots = new Autres("Impôts sur le revenu", lecourbe, null);
      mesCasesTemp.Add(impots);

      lecourbe.Suivante = impots;
      Proporiete montparnasse = new Proporiete(true, false, impots, null, "Gare Montparnasse", 200, 100);
      mesCasesTemp.Add(montparnasse);

      impots.Suivante = montparnasse;
      Proporiete vaugirard = new Proporiete(montparnasse, null, "Rue de Vaugirad", 100, 50, 50, 6, 30, 90, 270, 400, 550);
      mesCasesTemp.Add(vaugirard);

      montparnasse.Suivante = vaugirard;
      Autres chance1 = new Autres("Chance", vaugirard, null);
      mesCasesTemp.Add(chance1);

      vaugirard.Suivante = chance1;
      Proporiete courcelle = new Proporiete(chance1, null, "Rue de Courcelle", 100, 50, 50, 6, 30, 90, 270, 400, 550);
      mesCasesTemp.Add(courcelle);

      chance1.Suivante = courcelle;
      Proporiete republique = new Proporiete(courcelle, null, "Avenue de la République", 120,60, 50, 8, 40, 100, 350, 400, 600);
      mesCasesTemp.Add(republique);

      courcelle.Suivante = republique;
      Autres prison = new Autres("Prison", republique, null);
      mesCasesTemp.Add(prison);

      republique.Suivante = prison;
      Proporiete villette = new Proporiete(prison, null, "Boulevard de la Villette", 140, 70, 100, 10, 50, 150, 425, 625, 750);
      mesCasesTemp.Add(villette);

      prison.Suivante = villette;
      Proporiete electricité = new Proporiete(false, true, villette, null, "Compagnie de distribution d'électricité", 150, 75);
      mesCasesTemp.Add(electricité);

      villette.Suivante = electricité;
      Proporiete neuilly = new Proporiete(electricité, null, "Avenue de Neuilly", 140, 70, 100, 10, 50, 150, 425, 625, 750);
      mesCasesTemp.Add(neuilly);

      electricité.Suivante = neuilly;
      Proporiete paradis = new Proporiete(neuilly, null, "Rue du Paradis", 160, 80, 100, 12, 60, 180, 500, 700, 900);
      mesCasesTemp.Add(paradis);

      neuilly.Suivante = paradis;
      Proporiete lyon = new Proporiete(true, false, paradis, null, "Gare de Lyon", 200, 100);
      mesCasesTemp.Add(lyon);

      paradis.Suivante = lyon;
      Proporiete mozart = new Proporiete(lyon, null, "Avenue Mozart",180, 90, 100, 14, 70, 200, 550, 750, 950);
      mesCasesTemp.Add(mozart);

      lyon.Suivante = mozart;
      Autres commu2 = new Autres("Caisse de Communauté", mozart, null);
      mesCasesTemp.Add(commu2);

      mozart.Suivante = commu2;
      Proporiete saintmichel = new Proporiete(commu2, null, "Boulevard Saint-Michel", 180, 90, 100, 14, 70, 200, 550, 750, 950);
      mesCasesTemp.Add(saintmichel);

      commu2.Suivante = saintmichel;
      Proporiete pigalle = new Proporiete(saintmichel, null, "Place Pigalle", 200, 100, 100, 16, 80, 220, 600, 800, 1000);
      mesCasesTemp.Add(pigalle);

      saintmichel.Suivante = pigalle;
      Autres parcgratuit = new Autres("Parc Gratuit", pigalle, null);
      mesCasesTemp.Add(parcgratuit);

      pigalle.Suivante = parcgratuit;
      Proporiete matignon = new Proporiete(parcgratuit, null, "Avenue Matignon", 220, 110, 150, 18, 90, 250, 700, 875, 1050);
      mesCasesTemp.Add(matignon);

      parcgratuit.Suivante = matignon;
      Autres chance2 = new Autres("Chance", matignon, null);
      mesCasesTemp.Add(chance2);

      matignon.Suivante = chance2;
      Proporiete malsherbes = new Proporiete(chance2, null, "Boulevard Malsherbes", 220, 110, 150, 18, 90, 250, 700, 875, 1050);
      mesCasesTemp.Add(malsherbes);

      chance2.Suivante = malsherbes;
      Proporiete henrimartin = new Proporiete(malsherbes, null, "Avenue Henri-Martin", 240, 120, 150, 20, 100, 300, 750, 925, 1100);
      mesCasesTemp.Add(henrimartin);

      malsherbes.Suivante = henrimartin;
      Proporiete nord = new Proporiete(true, false, henrimartin, null, "Gare du Nord", 200, 100);
      mesCasesTemp.Add(nord);

      henrimartin.Suivante = nord;
      Proporiete sainthonore = new Proporiete(nord, null, "Faubourg Saint-Honoré", 260, 130, 150, 22, 110, 330, 800, 975, 1150);
      mesCasesTemp.Add(sainthonore);

      nord.Suivante = sainthonore;
      Proporiete bourse = new Proporiete(sainthonore, null, "Place de la Bourse", 260, 130, 150, 22, 110, 330, 800, 975, 1150);
      mesCasesTemp.Add(bourse);

      sainthonore.Suivante = bourse;
      Proporiete eau = new Proporiete(false, true, sainthonore, null, "Compagnie de distribution des eaux", 150, 75);
      mesCasesTemp.Add(eau);

      bourse.Suivante = eau;
      Proporiete lafayette = new Proporiete(sainthonore, null, "Rue la Fayette", 280, 140, 150, 24, 120, 360, 850, 1025, 1200);
      mesCasesTemp.Add(lafayette);

      eau.Suivante = lafayette;
      Autres allerEnPrison = new Autres("Aller en Prison", lafayette, null);
      mesCasesTemp.Add(allerEnPrison);

      lafayette.Suivante = allerEnPrison;
      Proporiete breteuil = new Proporiete(allerEnPrison, null, "Avenue de Breteuil", 300, 150, 200, 26, 130, 390, 900, 1100, 1275);
      mesCasesTemp.Add(breteuil);

      allerEnPrison.Suivante = breteuil;
      Proporiete foch = new Proporiete(breteuil, null, "Avenue Foch", 300, 150, 200, 26, 130, 390, 900, 1100, 1275);
      mesCasesTemp.Add(foch);

      breteuil.Suivante = foch;
      Autres commu3 = new Autres("Caisse de Communauté", foch, null);
      mesCasesTemp.Add(commu3);

      foch.Suivante = commu3;
      Proporiete capucines = new Proporiete(commu3, null, "Boulevard des Capucines", 320, 160, 200, 28, 150, 450, 1000, 1200, 1400);
      mesCasesTemp.Add(capucines);

      commu3.Suivante = capucines;
      Proporiete saintlaz = new Proporiete(true, false, capucines, null, "Gare Saint-Lazare", 200, 100);
      mesCasesTemp.Add(saintlaz);

      capucines.Suivante = saintlaz;
      Autres chance3 = new Autres("Chance", capucines, null);
      mesCasesTemp.Add(chance3);

      saintlaz.Suivante = chance3;
      Proporiete champs = new Proporiete(chance3, null, "Avenue des Champs-Elysées", 350, 175, 200, 35, 175, 500, 1100, 1300, 1500);
      mesCasesTemp.Add(champs);

      chance3.Suivante = champs;
      Autres taxe = new Autres("Taxe de Luxe", champs, null);
      mesCasesTemp.Add(taxe);

      champs.Suivante = taxe;
      Proporiete paix = new Proporiete(taxe, null, "Rue de la Paix", 400, 200, 200, 50, 200, 600, 1400, 1700, 2000);
      mesCasesTemp.Add(paix);

      taxe.Suivante = paix;
      paix.Suivante = caseDepart;*/
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
