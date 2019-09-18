﻿using Sokoban.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.View
{
    public class OutputView
    {
        Dictionary<Type, char> charDictonary;

        public OutputView()
        {
            charDictonary = new Dictionary<Type, char>();
            charDictonary.Add(typeof(Wall), '█');
            charDictonary.Add(typeof(Floor), '.');
            charDictonary.Add(typeof(Destination), 'X');
            charDictonary.Add(typeof(VoidTile), ' ');
        }
        
        public void displayMaze(Maze maze)
        {
            Console.Clear();
            Console.WriteLine("┌───────────┐\n" +
                              "│  Sokoban  │\n" +
                              "└───────────┘\n" +
                              "─────────────────────────────────────────────────────────────────");

            Tile head = maze.Head;

            Tile currentHead = head;

            while (head != null)
            {
                while(currentHead != null)
                {
                    char c = charDictonary[currentHead.GetType()];

                    if(currentHead is Floor)
                    {
                        Floor floor = (Floor)currentHead;
                        if(floor.Forklift != null)
                        {
                            c = '@';
                        } else if(floor.Crate != null)
                        {
                            if(floor.GetType() == typeof(Destination))
                            {
                                c = '0';
                            } else
                            {
                                c = 'O';
                            }
                        }
                    }

                    Console.Write(c);
                    currentHead = currentHead.East;
                }

                Console.WriteLine();
                head = head.South;
                currentHead = head;
            }

            Console.WriteLine("─────────────────────────────────────────────────────────────────\n" +
                              "> Gebruik de pijltjestoetsen ( s = stop, r = reset )");
        }

        public void displayMenu ()
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
        
        public void displayVictory()
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────────────────────────────┐\n" +
                              "│           __     _____ ____ _____ ___  ______   __            │\n" +
                              "│           \\ \\   / /_ _/ ___|_   _/ _ \\|  _ \\ \\ / /            │\n" +
                              "│            \\ \\ / / | | |     | || | | | |_) \\ V /             │\n" +
                              "│             \\ V /  | | |___  | || |_| |  _ < | |              │\n" +
                              "│              \\_/  |___\\____| |_| \\___/|_| \\_\\|_|              │\n" +
                              "│                                                               │\n" +
                              "└───────────────────────────────────────────────────────────────┘");
        }
    }
}
