using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.View
{
    public class OutputView
    {

        public void printMenu ()
        {

            Console.WriteLine(" ____________________________________________________ \n" +
                              "|                                                    |\n" +
                              "| Welkom bij Sokoban                                 |\n" +
                              "|                                                    |\n" +
                              "| Betekenis van de symbolen   |   Doel van het spel  |\n" +
                              "|                             |                      |\n" +
                              "| Spatie : Outerspace         |   Duw met de truck   |\n" +
                              "|      █ : Muur               |   de krat(ten)       |\n" +
                              "|      . : Vloer              |   naar de bestemming |\n" +
                              "|      O : Krat               |                      |\n" +
                              "|      0 : Krat op bestemming |                      |\n" +
                              "|      X : Bestemming         |                      |\n" +
                              "|      @ : Truck              |                      |\n" +
                              "|____________________________________________________|\n" +
                              "                                                      \n" +
                              "                                                      \n" +
                              "> Kies een doolhof ( 1 - 4 ), s = Stop                  ");
        }                     
    }
}
