namespace Sudoku.App.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Sudoku.App.Entities;
    using Sudoku.App.Interfaces;

    public class ExitCommand : ICommand
    {
        public ExitCommand()
        {
        }

        public void Execute(HashSet<Field> fields)
        {
            ConsoleManager.SetCursorPosition(0, 0);
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
