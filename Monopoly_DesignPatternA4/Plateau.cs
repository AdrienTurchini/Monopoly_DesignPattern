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
