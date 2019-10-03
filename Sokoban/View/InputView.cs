using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.View
{
    public class InputView
    {
        //Misschien herschrijven
        public ConsoleKeyInfo WaitForInput()
        {
            return Console.ReadKey(true);
        }
    }
}
