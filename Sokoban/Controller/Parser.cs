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

        private Tile[] _head;
        private List<char[]> _lines;

        // TODO: Herschrijven
        public void parseMaze(int number)
        {
            string[] inputLines = System.IO.File.ReadAllLines(@"../../Maze/" + _names[number - 1]);
            _lines = new List<char[]>();

            foreach (var line in inputLines)
            {
                _lines.Add(line.ToCharArray());
            }

            _head = new Tile[_lines.Count];
            
            
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
                            temp = new Floor();
                            break;
                        case '@':
                            temp = new Floor();
                            break;
                        default:
                            temp = new VoidTile();
                            break;
                    }

                    if (inner == 0)
                    {
                        _head[outer] = temp;
                    }
                    else
                    {
                        _head[outer].addEast(temp);
                    }
                }
            }
        }

        public void connectVertical()
        {
            for (int outer = 0; outer < _head.Length; outer++)
            {
                char[] currentLine = _lines[outer];
                for (int inner = 0; inner < currentLine.Length; inner++)
                {

                }
            }
        }
    }
}
