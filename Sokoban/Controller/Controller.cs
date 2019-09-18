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
        private readonly InputView _inputView;
        private readonly OutputView _outputView;
        private readonly int _currentMaze;
        private readonly Parser _parser;

        public Controller()
        {
            _parser = new Parser();
            _inputView = new InputView();

            _outputView = new OutputView();
            _outputView.DisplayMenu();

            while (true) {
                ConsoleKeyInfo input = _inputView.WaitForInput();
                if (input.Key != ConsoleKey.S) {
                    int.TryParse(input.KeyChar.ToString(), out int number);
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

            _maze = _parser.ParseMaze(_currentMaze);
            Start();
        }

        public void Start()
        {
            while(true)
            {
                _outputView.DisplayMaze(_maze);

                // Schrijf de input functie
                ConsoleKeyInfo input = _inputView.WaitForInput();

                switch (input.Key)
                {
                    case ConsoleKey.S:
                        return;
                    case ConsoleKey.R:
                        _maze = _parser.ParseMaze(_currentMaze);
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

                if(CheckWin())
                {
                    break;
                }
            }

            _outputView.DisplayVictory();
            Console.ReadKey();
        }

        public bool CheckWin()
        {
            bool win = true;

            foreach (Crate crate in _maze.Crates)
            {
                if(!crate.Location.IsDestination)
                {
                    win = false;
                }
            }

            return win;
        }

    }
}
