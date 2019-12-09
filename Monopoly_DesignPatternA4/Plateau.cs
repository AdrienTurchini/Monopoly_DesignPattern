using System;
using System.Collections.Generic;

namespace Monopoly_DesignPatternA4
{
  public class Plateau : ISubject
  {
    #region attributs
    // variable locale static qui permet de referencer l'instance de ma classe soit le plateau
    private static Plateau monPlateau = null;
    private static readonly object myLock = new object();
    private List<Case> mesCases = new List<Case>();
    private List<Joueur> lesJoueurs = new List<Joueur>(); // list of subscribers (observers of the subject)
    private string state; // subject state
    private Joueur joueurActuel;
    int nombreDeDoubles;
    bool rejouer;
    int lancerDeDe;
    int parcgratuit;
    #endregion

    #region constructeur
    // constructeur privé afin qu'une autre classe ne puisse pas instancier un plateau de jeu sans passer par la fonction publique
    //qui verifie qu'il n'y a qu'une seule instance (singleton)
    private Plateau()
    {
      rejouer = false;
      nombreDeDoubles = 0;
      int position = 0;
      state = "";
      // Construction des cartes du plateau de jeu
      Case caseDepart = CaseFactory.getCase(position, "autres", "Case Départ"); ;
      //Autres caseDepart = new Autres("Case départ");
      mesCases.Add(caseDepart);
      position++;
      Case belleville = CaseFactory.getCase(position, "propriete", "marron", "Boulevard De Belleville", 60, 30, 50, 2, 10, 30, 90, 160, 250);
      //Proporiete belleville = new Proporiete("Boulevard De Belleville", 60, 30, 50, 2, 10, 30, 90, 160, 250);
      mesCases.Add(belleville);
      position++;

      //caseDepart.Suivante = belleville;
      Case commu1 = CaseFactory.getCase(position, "autres", "Caisse de Communauté");
      mesCases.Add(commu1);
      position++;

      Case lecourbe = CaseFactory.getCase(position, "propriete", "marron", "Rue Lecourbe", 60, 30, 50, 4, 20, 60, 180, 320, 450);
      mesCases.Add(lecourbe);
      position++;

      Case impot = CaseFactory.getCase(position, "autres", "Impôts");
      mesCases.Add(impot);
      position++;

      Case gareMontparnasse = CaseFactory.getCase(position, "gare", "Gare Montparnasse");
      mesCases.Add(gareMontparnasse);
      position++;

      Case vaugirard = CaseFactory.getCase(position, "propriete", "bleupale", "Rue de Vaugirard", 100, 50, 50, 6, 30, 90, 270, 400, 550);
      mesCases.Add(vaugirard);
      position++;

      Case chance1 = CaseFactory.getCase(position, "autres", "Chance");
      mesCases.Add(chance1);
      position++;

      Case courcelle = CaseFactory.getCase(position, "propriete", "bleupale", "Rue de Courcelle", 100, 50, 50, 6, 30, 90, 270, 400, 550);
      mesCases.Add(courcelle);
      position++;

      Case republique = CaseFactory.getCase(position, "propriete", "bleupale", "Avenue de la République", 120, 60, 50, 8, 40, 100, 350, 400, 600);
      mesCases.Add(republique);
      position++;

      Case prison = CaseFactory.getCase(position, "autres", "prison");
      mesCases.Add(prison);
      position++;

      Case villette = CaseFactory.getCase(position, "autres", "rose", "Boulevard de la Villette", 140, 70, 100, 10, 50, 150, 425, 625, 750);
      mesCases.Add(villette);
      position++;

      Case compagnieElectricite = CaseFactory.getCase(position, "compagnie", "Compagnie de Distribution d'electricite");
      mesCases.Add(compagnieElectricite);
      position++;

      Case neuilly = CaseFactory.getCase(position, "propriete", "rose", "Avenue de Neuilly", 140, 70, 100, 10, 50, 150, 425, 625, 750);
      mesCases.Add(neuilly);
      position++;

      Case paradis = CaseFactory.getCase(position, "propriete", "rose", "Rue du Paradis", 160, 80, 100, 12, 60, 180, 500, 700, 900);
      mesCases.Add(paradis);
      position++;

      Case gareLyon = CaseFactory.getCase(position, "gare", "Gare de Lyon");
      mesCases.Add(gareLyon);
      position++;

      Case mozart = CaseFactory.getCase(position, "propriete", "orange", "Avenue Mozart", 180, 90, 100, 14, 70, 200, 550, 750, 950);
      mesCases.Add(mozart);
      position++;

      Case commu2 = CaseFactory.getCase(position, "autres", "Caisse de Communauté");
      mesCases.Add(commu2);
      position++;

      Case saintMichel = CaseFactory.getCase(position, "propriete", "orange", "Boulevard Saint-Michel", 180, 90, 100, 14, 70, 200, 550, 750, 950);
      mesCases.Add(saintMichel);
      position++;

      Case pigalle = CaseFactory.getCase(position, "propriete", "orange", "Place Pigalle", 200, 100, 100, 16, 80, 220, 600, 800, 1000);
      mesCases.Add(pigalle);
      position++;

      Case parcGratuit = CaseFactory.getCase(position, "autres", "Parc Gratuit");
      mesCases.Add(parcGratuit);
      position++;

      Case matignon = CaseFactory.getCase(position, "propriete", "rouge", "Avenue Matignon", 220, 110, 150, 18, 90, 250, 700, 875, 1050);
      mesCases.Add(matignon);
      position++;

      Case chance2 = CaseFactory.getCase(position, "autres", "Chance");
      mesCases.Add(chance2);
      position++;

      Case malesherbes = CaseFactory.getCase(position, "propriete", "rouge", "Boulevard Malesherbes", 220, 110, 150, 18, 90, 250, 700, 875, 1050);
      mesCases.Add(malesherbes);
      position++;

      Case henriMartin = CaseFactory.getCase(position, "propriete", "rouge", "Avenue Henri-Martin", 240, 120, 150, 20, 100, 300, 750, 925, 1100);
      mesCases.Add(henriMartin);
      position++;

      Case gareDuNord = CaseFactory.getCase(position, "gare", "Gare du Nord");
      mesCases.Add(gareDuNord);
      position++;

      Case saintHonore = CaseFactory.getCase(position, "propriete", "jaune", "Faubourg Saint-Honoré", 260, 130, 150, 22, 110, 330, 800, 975, 1150);
      mesCases.Add(saintHonore);
      position++;

      Case bourse = CaseFactory.getCase(position, "propriete", "jaune", "Place de la Bourse", 260, 130, 150, 22, 110, 330, 800, 975, 1150);
      mesCases.Add(bourse);
      position++;

      Case compagnieEau = CaseFactory.getCase(position, "compagnie", "Compagnie de Distribution des Eaux");
      mesCases.Add(compagnieEau);
      position++;

      Case fayette = CaseFactory.getCase(position, "propriete", "jaune", "Rue la Fayette", 280, 140, 150, 24, 120, 360, 850, 1025, 1200);
      mesCases.Add(fayette);
      position++;

      Case allerPrison = CaseFactory.getCase(position, "autres", "Aller en prison");
      mesCases.Add(allerPrison);
      position++;

      Case breteuil = CaseFactory.getCase(position, "propriete", "vert", "Avenue de Breteuil", 300, 150, 200, 26, 130, 390, 900, 1100, 1275);
      mesCases.Add(breteuil);
      position++;

      Case foch = CaseFactory.getCase(position, "propriete", "vert", "Avenue Foch", 300, 150, 200, 26, 130, 390, 900, 1100, 1275);
      mesCases.Add(foch);
      position++;

      Case commu3 = CaseFactory.getCase(position, "autres", "Caisse de Communauté");
      mesCases.Add(commu3);
      position++;

      Case capucines = CaseFactory.getCase(position, "propriete", "vert", "Boulevard des Capucines", 320, 160, 200, 28, 150, 450, 1000, 1200, 1400);
      mesCases.Add(capucines);
      position++;

      Case gareSaintLazare = CaseFactory.getCase(position, "gare", "Gare Saint-Lazare");
      mesCases.Add(gareSaintLazare);
      position++;

      Case chance3 = CaseFactory.getCase(position, "autres", "Chance");
      mesCases.Add(chance3);
      position++;

      Case champElysee = CaseFactory.getCase(position, "propriete", "bleufonce", "Avenue des Champs-Elysées", 350, 175, 200, 35, 175, 500, 1100, 1300, 1500);
      mesCases.Add(champElysee);
      position++;

      Case taxe = CaseFactory.getCase(position, "autres", "Taxe de luxe");
      mesCases.Add(taxe);
      position++;

      Case paix = CaseFactory.getCase(position, "propriete", "bleufonce", "Rue de la Paix", 400, 200, 200, 50, 200, 600, 1400, 1700, 2000);
      mesCases.Add(paix);
    }
    #endregion

    #region proprietes
    public List<Case> MesCases { get { return mesCases; } }
    public List<Joueur> LesJoueurs { get { return lesJoueurs; } set { lesJoueurs = value; } }
    public string State { get { return state; } set { state = value; } }
    public Joueur JoueurActuel { get { return joueurActuel; } set { joueurActuel = value; } }
    public int NombreDeDoubles { get { return nombreDeDoubles; } set { nombreDeDoubles = value; } }
    public int ParcGrauit { get { return parcgratuit; } set { parcgratuit = value; } }
    public int LancerDeDe { get { return lancerDeDe; } set { lancerDeDe = value; } }
    public bool Rejouer { get { return rejouer; } set { rejouer = value; } }
    #endregion

    #region methodes
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

    Random aleatoire = new Random();
    public void LanceLesDes()
    {
      
      int de1;
      int de2;
      
      de1 = aleatoire.Next(1,7);
      de2 = aleatoire.Next(1,7);
      Console.WriteLine("Vous avez fait : " + de1 + " et " + de2);
      lancerDeDe = de1 + de2;
      if (de1 == de2)
      {
        if(joueurActuel.EnPrison == false)
        {
          Console.WriteLine("Vous avez fait un double ! Vous pouvez relancer les dés à la fin de votre tour.\n");
          nombreDeDoubles++;
          rejouer = true;
        }
        else
        {
          joueurActuel.EnPrison = false;
          Console.WriteLine("Vous êtes libérés de prison. Vous pourrez avancer au prochain tour.\n");
          rejouer = false;
        }
        
        if(nombreDeDoubles == 3)
        {
          Console.WriteLine("Trois double d'affilés !! Vous allez en prison sans passer par la case départ.\n");
          state = "Triple double";
          rejouer = false;
          Notify();
        }
      }
      else
      {
        nombreDeDoubles = 0;
        rejouer = false;
      }
    }

    


    // Fonction Detach du subject dans le pattern observer, nous avons remplacé l'argument IObserver joueur par Joueur joueur car seule la classe Joueur implémente l'interface 
    public void JoueurElimine(Joueur joueur)
    {
      Console.WriteLine(joueur.Nom + " est éliminé du jeu");
      lesJoueurs.Remove(joueur);
    }

    // Fonction Attach du subject dans le pattern observer, nous avons remplacé l'argument IObserver joueur par Joueur joueur car seule la classe Joueur implémente l'interface 
    public void NouveauJoueur(Joueur joueur)
    {
      Console.WriteLine("Bienvenue à " + joueur.Nom);
      lesJoueurs.Add(joueur);
    }

    public void Notify()
    {
      foreach (Joueur j in lesJoueurs)
      {
        j.Update(this);
      }
    }
    #endregion
  }
}
