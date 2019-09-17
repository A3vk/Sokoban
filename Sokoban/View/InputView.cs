using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.View
{
    public class InputView
    {
        public ConsoleKeyInfo waitForInput()
        {
            return Console.ReadKey();
        }
    }
}
