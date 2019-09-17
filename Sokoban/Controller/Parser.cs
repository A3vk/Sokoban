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

        private string[] _names = { "doolhof1.txt", "doolhof2.txt", "doolhof3.txt", "doolhof4.txt" };

        private Tile[] _heads;
        private List<char[]> _lines;

        // TODO: Herschrijven
        public Maze parseMaze(int number)
        {
            string[] inputLines = System.IO.File.ReadAllLines(@"../../Maze/" + _names[number - 1]);
            _lines = new List<char[]>();

            foreach (var line in inputLines)
            {
                _lines.Add(line.ToCharArray());
            }

            _heads = new Tile[_lines.Count];

            _maze = new Maze();
            connectHorizontal();
            connectVertical();

            return _maze;
        }

        public void connectHorizontal()
        {
            for (int outer = 0; outer < _lines.Count; outer++)
            {
                char[] currentLine = _lines[outer];
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
                            Floor crateFloor = new Floor();
                            Crate crate = new Crate(crateFloor);
                            crateFloor.Crate = crate;
                            _maze.Crates.Add(crate);
                            temp = crateFloor;
                            break;
                        case '@':
                            Floor forkliftFloor = new Floor();
                            Forklift forklift = new Forklift(forkliftFloor);
                            forkliftFloor.Forklift = forklift;
                            _maze.Forklift = forklift;
                            temp = forkliftFloor;
                            break;
                        default:
                            temp = new VoidTile();
                            break;
                    }

                    if (inner == 0)
                    {
                        _heads[outer] = temp;
                    }
                    else
                    {
                        _heads[outer].addEast(temp);
                    }
                }
            }
        }

        public void connectVertical()
        {
            _maze.Head = _heads[0];
            while(_heads[0].East != null)
            {
                for (int i = 1; i < _heads.Length; i++)
                {
                    _heads[0].addSouth(_heads[i]);
                    _heads[i] = _heads[i].East;
                }

                _heads[0] = _heads[0].East;
            }
        }
    }
}
