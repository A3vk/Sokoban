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
        private int _currentMaze;
        private Parser _parser;

        public Controller()
        {
            _parser = new Parser();
            _inputView = new InputView();

            _outputView = new OutputView();
            _outputView.displayMenu();

            while (true) {
                Console.Write("\b");
                ConsoleKeyInfo input = _inputView.waitForInput();
                if (input.Key != ConsoleKey.S) {
                    int number = 0;
                    int.TryParse(input.KeyChar.ToString() , out number);
                    if (number >= 1 && number <= 4)
                    {
                        _currentMaze = number;
                        break;
                    }
                } else
                {
                    return;
                }
            }

            _maze = _parser.parseMaze(_currentMaze);
            start();
        }

        public void start()
        {
            while(true)
            {
                _outputView.displayMaze(_maze);

                // Schrijf de input functie
                ConsoleKeyInfo input = _inputView.waitForInput();

                switch (input.Key)
                {
                    case ConsoleKey.S:
                        return;
                    case ConsoleKey.R:
                        _maze = _parser.parseMaze(_currentMaze);
                        break;
                    case ConsoleKey.UpArrow:
                        _maze.Forklift.Move(Dir.UP);
                        break;
                    case ConsoleKey.RightArrow:
                        _maze.Forklift.Move(Dir.RIGHT);
                        break;
                    case ConsoleKey.DownArrow:
                        _maze.Forklift.Move(Dir.DOWN);
                        break;
                    case ConsoleKey.LeftArrow:
                        _maze.Forklift.Move(Dir.LEFT);
                        break;
                }
            }
        }

    }
}
