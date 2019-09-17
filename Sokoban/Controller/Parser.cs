using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Domain;

namespace Sokoban
{
    class Parser
    {
        private Maze _maze;

        private string[] _names = { "doolhof1.txt", "doolhof2.txt", "doolhof3.txt", "doolhof4txt" };

        public void parseMaze(int number)
        {
            string[] inputLines = System.IO.File.ReadAllLines(@"../../Maze/" + _names[number - 1]);
            List<char[]> lines = new List<char[]>();

            foreach (var line in inputLines)
            {
                lines.Add(line.ToCharArray());
            }

            Tile[] head = new Tile[lines.Count];
            
            for (int outer = 0; outer < lines.Count; outer++)
            {
                char[] currentLine = lines[outer];
                for (int inner = 0; inner < currentLine.Length; inner++)
                {
                    Tile temp;
                    switch (currentLine[inner])
                    {
                        case '#':
                            temp = new Wall();
                            break;
                        case '.':
                            temp = new Floor();
                            break;
                        case 'x':
                            temp = new Destination();
                            break;
                        case 'o':
                            Floor floor = new Floor();
                            Crate crate = new Crate(floor);
                            floor.setCrate(crate);
                            _maze.addCrate(crate);
                            temp = floor;
                            break;
                        case '@':
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
