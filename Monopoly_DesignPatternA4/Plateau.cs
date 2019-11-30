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
    }
  

    public static Plateau GetPlateau()
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
