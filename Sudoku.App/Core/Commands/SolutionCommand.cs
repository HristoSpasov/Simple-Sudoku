namespace Sudoku.App.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Sudoku.App.Constants;
    using Sudoku.App.Entities;
    using Sudoku.App.Interfaces;

    public class SolutionCommand : ICommand
    {
        private readonly SudokuGenerator generator;
        private readonly SudokuSolver solver;
        private readonly BoardManager boardManager;

        public SolutionCommand(SudokuGenerator generator, SudokuSolver solver, BoardManager boardManager)
        {
            this.generator = generator;
            this.solver = solver;
            this.boardManager = boardManager;
        }

        public void Execute(HashSet<Field> fields)
        {
            int[][] initialGrid = this.generator.GenerateNewSukoku();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            bool a = this.solver.SolveSudoku(initialGrid);
            watch.Stop();
            int[][] solvedGrid = this.solver.GetGrid;

            Console.Clear();
            this.boardManager.GenerateBoard();
            this.boardManager.InitializeFields(solvedGrid);
            this.boardManager.DrawFieldsContentAndUpdateBoard();

            ConsoleManager.SetCursorPosition(BoardConstants.InformationCol, BoardConstants.InformationRow);
            ConsoleManager.SetColor(BoardConstants.DefaultPromptColor);
            ConsoleManager.Write($"Time: {watch.ElapsedMilliseconds}ms; Recursive calls: {this.solver.Backtrack} Press any key...");
            Console.ReadKey();
            Console.Clear();
            ConsoleManager.SetCursorPosition(0, 0);
            Console.Clear();

            Environment.Exit(0);
        }
    }
}
