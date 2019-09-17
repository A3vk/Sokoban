using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Program
    {
        Controller _controller;

        static void Main(string[] args)
        {
            Parser parser = new Parser();
            parser.parseMaze(1);
            
            Console.ReadLine();
        }
    }
}
