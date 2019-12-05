using System;
using Monopoly_DesignPatternA4;

namespace Monopoly_ProjetFinal_DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Plateau plateau = Plateau.GetPlateau();

            foreach (Case c in plateau.MesCases)
            {
                Console.WriteLine(c.ToString());

            }

            Console.ReadLine();

        
        }
    }
}






