﻿namespace Sudoku.App.Core
{
    using System;
    using Sudoku.App.Constants;
    using Sudoku.App.Entities;
    using Sudoku.App.Factories;
    using Sudoku.App.Interfaces;
    using Sudoku.App.Menu;
    using Sudoku.App.Utilities;

    public class Engine
    {
        private readonly ModulesManager modulesManager;
        private readonly BoardManager boardManager;
        private readonly Mouse mouse;

        public Engine(ModulesManager modulesManager)
        {
            this.modulesManager = modulesManager;
            this.boardManager = modulesManager.GetService<BoardManager>();
            this.mouse = modulesManager.GetService<Mouse>();
        }

        public void Run()
        {
            this.runMainMenu();

            int[][] generatedSudoku = this.generateSudoku();

            this.boardManager.GenerateBoard();
            this.boardManager.InitializeFields(generatedSudoku);
            this.boardManager.DrawFieldsContentAndUpdateBoard();
            this.boardManager.InitializeButtons();

            while (true)
            {
                ConsoleManager.DefaultColors();
                ConsoleKeyInfo pressedKey = ConsoleManager.ReadKey();
                ConsoleManager.SetCursorPosition(this.mouse.PositionX, this.mouse.PositionY);

                int oldPositionX = this.mouse.PositionX;
                int oldPositionY = this.mouse.PositionY;
                char charToRefreshAfterMove = this.boardManager.GetCharByPosition(this.mouse.PositionX, this.mouse.PositionY);
                ConsoleManager.WriteSingleChar();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow: this.mouse.PositionY--;
                        break;
                    case ConsoleKey.DownArrow: this.mouse.PositionY++;
                        break;
                    case ConsoleKey.LeftArrow: this.mouse.PositionX--;
                        break;
                    case ConsoleKey.RightArrow: this.mouse.PositionX++;
                        break;
                    case ConsoleKey.Enter: this.resolveOperation(this.mouse.PositionY, this.mouse.PositionX);
                        break;
                    default:
                        break;
                }

                ConsoleManager.SetCursorPosition(oldPositionX, oldPositionY);
                ConsoleManager.WriteSingleChar(charToRefreshAfterMove);
                ConsoleManager.SetCursorPosition(this.mouse.PositionX, this.mouse.PositionY);
                Console.ForegroundColor = MouseConstants.MouseDefaultColor;
                ConsoleManager.WriteSingleChar(MouseConstants.MouseSymbol);
            }
        }

        private int[][] generateSudoku()
        {
            SudokuGenerator generator = this.modulesManager.GetService<SudokuGenerator>();
            int[][] generatedSudoku = generator.GenerateNewSukoku();

            return generatedSudoku;
        }

        private void runMainMenu()
        {
            ConsoleManager.SetTheConsoleForTheGame();
            MainMenu mainMenu = this.modulesManager.GetService<MainMenu>();
            mainMenu.StartMenu();
            Console.Clear();
        }

        private void resolveOperation(int mouseRow, int mouseCol)
        {
            Field fieldMatch = this.boardManager.SearchForField(mouseCol, mouseRow);
            Button buttonMatch = this.boardManager.SearchForButton(mouseCol, mouseRow);

            if (fieldMatch != null)
            {
                ConsoleManager.SetCursorPosition(BoardConstants.InformationCol, BoardConstants.InformationRow);
                ConsoleManager.SetColor(BoardConstants.DefaultPromptColor);
                ConsoleManager.Write(BoardConstants.PromptUserForNumberInput);

                ConsoleKeyInfo pressedKey = ConsoleManager.ReadKey();

                AsciiNumberFactory asciiNumberFactory = this.modulesManager.GetService<AsciiNumberFactory>();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        fieldMatch.Value = 0;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(0);
                        break;
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        fieldMatch.Value = 1;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(1);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        fieldMatch.Value = 2;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(2);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        fieldMatch.Value = 3;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(3);
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        fieldMatch.Value = 4;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(4);
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        fieldMatch.Value = 5;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(5);
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        fieldMatch.Value = 6;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(6);
                        break;
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        fieldMatch.Value = 7;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(7);
                        break;
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.D8:
                        fieldMatch.Value = 8;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(8);
                        break;
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.D9:
                        fieldMatch.Value = 9;
                        fieldMatch.Content = asciiNumberFactory.GetNumberAscii(9);
                        break;
                    default:
                        break;
                }

                ConsoleManager.DefaultColors();
                this.boardManager.UpdateField(fieldMatch);

                ConsoleManager.SetCursorPosition(BoardConstants.InformationCol, BoardConstants.InformationRow);
                ConsoleManager.Clear(BoardConstants.PromptUserForNumberInput.Length);
            }
            else if (buttonMatch != null)
            {
                string commandName = buttonMatch.Id;

                CommandFactory commandFactory = this.modulesManager.GetService<CommandFactory>();
                ICommand cmd = commandFactory.GetCommand(commandName);

                cmd.Execute(this.boardManager.Fields);
            }

            ConsoleManager.SetCursorPosition(mouseCol, mouseRow);
        }
    }
}
