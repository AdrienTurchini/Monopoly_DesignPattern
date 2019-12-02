using System;
namespace Monopoly_DesignPatternA4
{
  public class Plateau
  {
    // variable locale static qui permet de referencer l'instance de ma classe soit le plateau
    private static Plateau monPlateau = null;
    private static readonly object myLock = new object();

    // constructeur privé afin que d'autres classes ne puissent instancier un autre plateau que le plateau unique
    private Plateau()
    {
      Autres caseDepart = new Autres("Case départ", null, null, true, false, false, false, false, false, false, false);
      Proporiete belleville = new Proporiete(caseDepart, null, "Boulevard De Belleville", 60, 30, 50, 2, 10, 30, 90, 160, 250);
      caseDepart.Suivante = belleville;
      Autres commu1 = new Autres("Caisse de Communauté", belleville, null, false, true, false, false, false, false, false, false);
      belleville.Suivante = commu1;
      Proporiete lecourbe = new Proporiete(commu1, null, "Rue Lecourbe", 60, 30, 50, 4, 20, 60, 180, 320, 450);
      commu1.Suivante = lecourbe;
      Autres impots = new Autres("Impôts sur le revenu", lecourbe, null, false, false, false, false, false, false, true, false);
      lecourbe.Suivante = impots;
      Proporiete gareMontparnasse = new Proporiete(true, false, impots, null, "Gare Montparnasse", 200, 100);
      impots.Suivante = gareMontparnasse;
      Proporiete rueDeVaugirad = new Proporiete(gareMontparnasse, null, "Rue de Vaugirad", 100, 50, 50, 6, 30, 90, 270, 400, 550);
      gareMontparnasse.Suivante = rueDeVaugirad;
      Autres chance1 = new Autres("Chance", rueDeVaugirad, null, false, true, true, false, false, false, false,false);
      rueDeVaugirad.Suivante = chance1;
      Proporiete rueDeCourcelle = new Proporiete(chance1, null, "Rue de Courcelle", 100, 50, 50, 6, 30, 90, 270, 400, 550);
      chance1.Suivante = rueDeCourcelle;
      Proporiete avenueDeLaRepublique = new Proporiete(rueDeCourcelle, null, "Avenue de la République", 120,60, 50, 8, 40, 100, 350, 400, 600);
      rueDeCourcelle.Suivante = avenueDeLaRepublique;
      Autres prison = new Autres("Prison", avenueDeLaRepublique, null, false, false, false, true, false, false, false, false);
      avenueDeLaRepublique.Suivante = prison;
      Proporiete boulevardDeLaVillette = new Proporiete(prison, null, "Boulevard de la Villette", 140, 70, 100, 10, 50, 150, 425, 625, 750);
      prison.Suivante = boulevardDeLaVillette;
      Proporiete compagnieElectricite = new Proporiete(false, true, boulevardDeLaVillette, null, "Compagnie de distribution d'électricité", 150, 75);
      boulevardDeLaVillette.Suivante = compagnieElectricite;
      Proporiete avenueDeNeuilly = new Proporiete(boulevardDeLaVillette, null, "Avenue de Neuilly", 140, 70, 100, 10, 50, 150, 450, 625, 750);
      compagnieElectricite.Suivante = boulevardDeLaVillette;
      Proporiete rueDeParadis = new Proporiete(boulevardDeLaVillette, null, "Rue de Paradis", 160, 80, 100, 12, 60, 180, 500, 700, 900);
      boulevardDeLaVillette.Suivante = rueDeParadis;
      Proporiete gareDeLyon = new Proporiete(true, false, rueDeParadis, null, "Gare de Lyon", 200, 100);
      rueDeParadis.Suivante = gareDeLyon;
      Proporiete avenueMozart = new Proporiete(gareDeLyon, null, "Avenue Mozart", 180, 90, 100, 14, 70, 200, 550, 750, 950);
      gareDeLyon.Suivante = avenueMozart;
      Autres commu2 = new Autres("Caisse de Communauté", avenueMozart, null, false, true, false, false, false, false, false, false);
      avenueMozart.Suivante = commu2;
      Proporiete boulevardSaintMichel = new Proporiete(commu2, null, "Boulevard Saint-Michel", 180, 90, 100, 14, 70, 200, 550, 750, 950);
      commu2.Suivante = boulevardSaintMichel;
      Proporiete placePigalle = new Proporiete(boulevardSaintMichel, null, "Place Pigalle", 200, 100, 100, 16, 80, 220, 600, 800, 1000);
      boulevardSaintMichel.Suivante = placePigalle;
      Autres parcGratuit = new Autres("Parc Gratuit", placePigalle, null, false, false, false, false, false, true, false, false);
      placePigalle.Suivante = parcGratuit;
      Proporiete avenueMatignon = new Proporiete(parcGratuit, null, "Avenue Matignon", 220, 110, 150, 18, 90, 250, 700, 875, 1050);
      parcGratuit.Suivante = avenueMatignon;
      Autres chance2 = new Autres("Chance", avenueMatignon, null, false, false, true, false, false, false, false, false);
      avenueMatignon.Suivante = chance2;
      Proporiete boulevardMalherbes = new Proporiete(avenueMatignon, null, "Boulevard Malherbes", 220, 110, 150, 18, 90, 250, 700, 875, 1050);
      chance2.Suivante = boulevardMalherbes;
      Proporiete avenueHenriMartin = new Proporiete(boulevardMalherbes, null, "Avenue Henri-Martin", 240, 120, 150, 20, 100, 300, 750, 925, 1100);
      boulevardMalherbes.Suivante = avenueHenriMartin;
      Proporiete gareDuNord = new Proporiete(true, false, avenueHenriMartin, null, "Gare du Nord", 200, 100);
      avenueHenriMartin.Suivante = gareDuNord;
      Proporiete faubourgSaintHonore = new Proporiete(gareDuNord, null, "Faubourg Saint-Honoré", 260, 130, 150, 22, 110, 330, 800, 975, 1150);
      gareDuNord.Suivante = faubourgSaintHonore;
      Proporiete placeDelaBourse = new Proporiete(faubourgSaintHonore, null, "Place de la Bourse", 260, 130, 150, 22, 110, 330, 800, 975, 1150);
      faubourgSaintHonore.Suivante = placeDelaBourse;
      Proporiete compagnieEau = new Proporiete(false, true, placeDelaBourse, null, "Compagnie de distribution des eau", 150, 75);
      placeDelaBourse.Suivante = compagnieEau;
      Proporiete rueLaFayette = new Proporiete(compagnieEau, null, "Rue La Fayette", 280, 140, 150, 24, 120, 360, 850, 1025, 1200);
      compagnieEau.Suivante = rueLaFayette;
      Autres allerEnPrison = new Autres("Aller en prison", rueLaFayette, null, false, false, false, false, true, false, false, false);
      rueLaFayette.Suivante = allerEnPrison;
      Proporiete avenueDeBreteuil = new Proporiete(allerEnPrison, null, "Avenue de Breteuil", 300, 150, 200, 26, 130, 390, 900, 1100, 1275);
      allerEnPrison.Suivante = avenueDeBreteuil;
      Proporiete avenueFoch = new Proporiete(avenueDeBreteuil, null, "Avenue Foch", 300, 150, 200, 26, 130, 390, 900, 1100, 1275);
      avenueDeBreteuil.Suivante = avenueFoch;
      Autres commu3 = new Autres("Caisse de Communauté", avenueFoch, null, false, true, false, false, false, false, false, false);
      avenueFoch.Suivante = commu3;
      Proporiete boulevardDesCapucines = new Proporiete(commu3, null, "Boulevard des Capucines", 320, 160, 200, 28, 150, 450, 1000, 1200, 1400);
      commu3.Suivante = boulevardDesCapucines;
      Proporiete gareSaintLazare = new Proporiete(true, false, boulevardDesCapucines, null, "Gare Saint-Lazare", 200, 100);
      boulevardDesCapucines.Suivante = gareSaintLazare;
      Autres chance3 = new Autres("Chance", gareSaintLazare, null, false, false, true, false, false, false, false, false);
      gareSaintLazare.Suivante = chance3;
      Proporiete avenueDesChampsElysees = new Proporiete(chance3, null, "Avenue des Champs-Elysees", 350, 175, 200, 35, 175, 500, 1100, 1300, 1500);
      chance3.Suivante = avenueDesChampsElysees;
      Autres taxeDeLuxe = new Autres("Taxe de luxe", avenueDesChampsElysees, null, false, false, false, false, false, false, false, true);
      avenueDesChampsElysees.Suivante = taxeDeLuxe;
      Proporiete rueDeLaPaix = new Proporiete(taxeDeLuxe, caseDepart, "Rue de la Paix", 400, 200, 200, 50, 200, 600, 1400 ,1700, 2000);
      taxeDeLuxe.Suivante = rueDeLaPaix;
      caseDepart.Precedente = rueDeLaPaix;
    }

    public Plateau GetPlateau()
    {
      // lock permet d'empêcher plusieurs threads différents d'utiliser plusieurs une instance de notre plateau sencé être unique en même temps et d'assurer d'en avoir un seul.
      lock ((myLock))
      {
        if (monPlateau == null) // si mon plateau n'existe pas encore on appelle le constructeur privé depuis la classe plateau qui créé un plateau.
          monPlateau = new Plateau();
        return monPlateau; // on retourne le plateau existant soit un nouveau plateau si celui-ci n'existait pas ou le plateau existant le cas contraire.
      }
    }
  }
}
