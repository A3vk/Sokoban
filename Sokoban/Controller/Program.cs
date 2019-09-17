using Sokoban.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Program
    {

        static void Main(string[] args)
        {
            OutputView output = new OutputView();
            output.printMenu();
            Console.ReadLine();
        }
    }
}
