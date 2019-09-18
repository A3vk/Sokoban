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

        private readonly string[] _names = { "doolhof1.txt", "doolhof2.txt", "doolhof3.txt", "doolhof4.txt" };

        private Tile[] _heads;
        private List<char[]> _lines;

        // TODO: Herschrijven
        public Maze ParseMaze(int number)
        {
            string[] inputLines = System.IO.File.ReadAllLines(@"../../Maze/" + _names[number - 1]);
            _lines = new List<char[]>();

            foreach (var line in inputLines)
            {
                _lines.Add(line.ToCharArray());
            }

            _heads = new Tile[_lines.Count];

            _maze = new Maze();
            ConnectHorizontal();
            ConnectVertical();

            return _maze;
        }

        public void ConnectHorizontal()
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
                            temp = new Wall(false);
                            break;
                        case '.':
                            temp = new Floor(false);
                            break;
                        case 'x':
                            temp = new Floor(true);
                            break;
                        case 'o':
                            Floor crateFloor = new Floor(false);
                            Crate crate = new Crate(crateFloor);
                            crateFloor.Crate = crate;
                            _maze.Crates.Add(crate);
                            temp = crateFloor;
                            break;
                        case '@':
                            Floor forkliftFloor = new Floor(false);
                            Forklift forklift = new Forklift(forkliftFloor);
                            forkliftFloor.Forklift = forklift;
                            _maze.Forklift = forklift;
                            temp = forkliftFloor;
                            break;
                        default:
                            temp = new Wall(true);
                            break;
                    }

                    if (inner == 0)
                    {
                        _heads[outer] = temp;
                    }
                    else
                    {
                        _heads[outer].AddEast(temp);
                    }
                }
            }
        }

        public void ConnectVertical()
        {
            _maze.Head = _heads[0];
            while(_heads[0].East != null)
            {
                for (int i = 1; i < _heads.Length; i++)
                {
                    _heads[0].AddSouth(_heads[i]);
                    _heads[i] = _heads[i].East;
                }

                _heads[0] = _heads[0].East;
            }
        }
    }
}
