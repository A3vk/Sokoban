using Sokoban.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.View
{
    public class OutputView
    {
        private readonly Dictionary<Type, char> charDictonary;

        public OutputView()
        {
            charDictonary = new Dictionary<Type, char>
            {
                { typeof(Wall), '█' },
                { typeof(Floor), '.' }
            };
        }
        
        public void DisplayMaze(Maze maze)
        {
            Console.Clear();
            Console.WriteLine("┌───────────┐\n" +
                              "│  Sokoban  │\n" +
                              "└───────────┘\n" +
                              "──────────────────────────────────────────────────────────────────");

            Tile head = maze.Head;

            Tile currentHead = head;

            while (head != null)
            {
                while(currentHead != null)
                {
                    char c = charDictonary[currentHead.GetType()];

                    if (currentHead is Floor floor)
                    {
                        if (floor.IsDestination)
                        {
                            c = 'X';
                        }

                        if (floor.Forklift != null)
                        {
                            c = '@';
                        }
                        else if (floor.Crate != null)
                        {
                            if (floor.IsDestination)
                            {
                                c = '0';
                            }
                            else
                            {
                                c = 'O';
                            }
                        }
                    }
                    else if (currentHead is Wall wall)
                    {
                        if (wall.IsVoid)
                            c = ' ';
                    }

                    Console.Write(c);
                    currentHead = currentHead.East;
                }

                Console.WriteLine();
                head = head.South;
                currentHead = head;
            }

            Console.WriteLine("──────────────────────────────────────────────────────────────────\n" +
                              "> Gebruik de pijltjestoetsen ( s = stop, r = reset )");
        }

        public void DisplayMenu ()
        {
            
            Console.WriteLine("┌────────────────────────────────────────────────────┐\n" +
                              "│                                                    │\n" +
                              "│ Welkom bij Sokoban                                 │\n" +
                              "│                                                    │\n" +
                              "│ Betekenis van de symbolen   │   Doel van het spel  │\n" +
                              "│                             │                      │\n" +
                              "│ Spatie : Outerspace         │   Duw met de truck   │\n" +
                              "│      █ : Muur               │   de krat(ten)       │\n" +
                              "│      . : Vloer              │   naar de bestemming │\n" +
                              "│      O : Krat               │                      │\n" +
                              "│      0 : Krat op bestemming │                      │\n" +
                              "│      X : Bestemming         │                      │\n" +
                              "│      @ : Truck              │                      │\n" +
                              "└────────────────────────────────────────────────────┘\n" +
                              "\n" +
                              "\n" +
                              "> Kies een doolhof ( 1 - 4 ), s = Stop");
        }
        
        public void DisplayVictory()
        {
            Console.Clear();
            Console.WriteLine("Je hebt gewonnen!");
        }
    }
}
