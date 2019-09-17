using Sokoban.Domain;
using Sokoban.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Controller
    {
        private Maze _maze;
        private InputView _inputView;
        private OutputView _outputView;

        public Controller()
        {
            Parser parser = new Parser();
            _inputView = new InputView();

            _outputView = new OutputView();
            _outputView.displayMenu();

            int number = 0;
            while (true) {
                Console.Write("\b");
                ConsoleKeyInfo input = _inputView.waitForInput();
                if (input.Key != ConsoleKey.S) {
                    int.TryParse(input.KeyChar.ToString() , out number);
                    if (number >= 1 && number <= 4)
                    {
                        break;
                    }
                } else
                {
                    return;
                }
            }

            _maze = parser.parseMaze(number);
            start();
        }

        public void start()
        {
            while(true)
            {
                _outputView.displayMaze(_maze);

                // Schrijf de input functie
                _inputView.waitForInput();
            }
        }

    }
}
