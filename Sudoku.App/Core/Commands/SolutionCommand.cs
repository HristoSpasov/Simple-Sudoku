namespace Sudoku.App.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
            bool a = this.solver.SolveSudoku(initialGrid);
            watch.Stop();
            int[][] solvedGrid = this.solver.GetGrid;

            Console.Clear();
            this.boardManager.GenerateBoard();
            this.boardManager.InitializeFields(solvedGrid);
            this.boardManager.DrawFieldsContentAndUpdateBoard();

            //// Console.WriteLine(this.solver.Backtrack);
            //// Console.WriteLine(watch.ElapsedMilliseconds);

            Environment.Exit(0);
        }
    }
}
