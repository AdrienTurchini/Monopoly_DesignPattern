using System;
namespace Monopoly_DesignPatternA4
{
    public abstract class Case
    {
        
        public abstract String getNom();
        public abstract int getPrix();
        public abstract int getHypotheque();
        public abstract int getPrixMaison();
        public abstract int getLoyer();
        public abstract int getLoyer1Maison();
        public abstract int getLoyer2Maison();
        public abstract int getLoyer3Maison();
        public abstract int getLoyer4Maison();
        public abstract int getHotel();

        public abstract bool getEstGare();
        public abstract bool getEstCompagnie();
        


    }
}
