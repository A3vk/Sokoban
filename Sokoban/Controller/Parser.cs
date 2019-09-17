using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Maze/" + _names[number - 1]);
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }
        }
    }
}
