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
        public Maze Maze { get; set; }
        public InputView InputView { get; set; }
        public OutputView OutputView { get; set; }
        public int CurrentMaze { get; set; }
        public Parser Parser { get; set; }

        public Controller()
        {
            Parser = new Parser();
            InputView = new InputView();

            OutputView = new OutputView();
            OutputView.DisplayMenu();

            while (true) {
                ConsoleKeyInfo input = InputView.WaitForInput();
                if (input.Key != ConsoleKey.S) {
                    int.TryParse(input.KeyChar.ToString(), out int number);
                    if (number >= 1 && number <= 6)
                    {
                        CurrentMaze = number;
                        break;
                    }
                } else
                {
                    return;
                }
            }

            Maze = Parser.ParseMaze(CurrentMaze);
            Start();
        }

        private void Start()
        {
            while(true)
            {
                DisplayMaze();

                ConsoleKeyInfo input = InputView.WaitForInput();

                switch (input.Key)
                {
                    case ConsoleKey.S:
                        return;
                    case ConsoleKey.R:
                        Maze = Parser.ParseMaze(CurrentMaze);
                        break;
                    case ConsoleKey.UpArrow:
                        Maze.Forklift.Move(Dir.UP);
                        Maze.Employee.DoSomething();
                        break;
                    case ConsoleKey.RightArrow:
                        Maze.Forklift.Move(Dir.RIGHT);
                        Maze.Employee.DoSomething();
                        break;
                    case ConsoleKey.DownArrow:
                        Maze.Forklift.Move(Dir.DOWN);
                        Maze.Employee.DoSomething();
                        break;
                    case ConsoleKey.LeftArrow:
                        Maze.Forklift.Move(Dir.LEFT);
                        Maze.Employee.DoSomething();
                        break;
                }

                if(CheckWin())
                {
                    break;
                }
            }

            OutputView.DisplayVictory();
            Console.ReadKey();
        }

        private bool CheckWin()
        {
            bool win = true;

            foreach (Crate crate in Maze.Crates)
            {
                if(!crate.Location.IsDestination)
                {
                    win = false;
                }
            }

            return win;
        }

        private void DisplayMaze()
        {
            String output = "";

            Tile head = Maze.Head;

            Tile currentTile = head;

            while (head != null)
            {
                while (currentTile != null)
                {
                    output += currentTile.Description;
                    currentTile = currentTile.East;
                }

                output += "\n";
                head = head.South;
                currentTile = head;
            }

            OutputView.DisplayMaze(output);
        }

    }
}
