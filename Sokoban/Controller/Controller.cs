﻿using Sokoban.Domain;
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
        private Parser _parser;
        private Maze _maze;
        private InputView _inputView;
        private OutputView _outputView;

        public Controller()
        {
            Parser parser = new Parser();
            _maze = parser.parseMaze(1);

            _outputView = new OutputView();
            _outputView.displayMenu();

            Console.ReadLine();
        }
    }
}
