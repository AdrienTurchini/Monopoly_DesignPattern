using System;
using System.Collections.Generic;
using System.Threading;

namespace Monopoly_DesignPatternA4
{
  public interface IObserver
  {

    void Update(Plateau plateau);
  }

  public interface ISubject
  {
    void NouveauJoueur(Joueur observer); // seule la classe Joueur implémente l'interface d'où le replacement de IObserver par Joueur pour des questions de simplicité
    void JoueurElimine(Joueur observer); // si d'autres classes implémentaient l'interface il n'aurait pas été possible de faire cel bien évidemment
    void Notify();
  }
}
