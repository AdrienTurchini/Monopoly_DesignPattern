using System;
namespace Monopoly_DesignPatternA4
{
  public abstract class Case
  {
    #region attributs
    public abstract string Nom { get; }
    public abstract Case Precedente { get; set; }
    public abstract Case Suivante { get; set; }
    #endregion

    #region methodes
    abstract public string Action();
    #endregion
  }
}
