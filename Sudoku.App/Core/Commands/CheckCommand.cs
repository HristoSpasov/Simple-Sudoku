namespace Sudoku.App.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sudoku.App.Entities;
    using Sudoku.App.Interfaces;

    public class CheckCommand : ICommand
    {
        private readonly SudokuGenerator generator;
        private readonly SudokuSolver solver;

        public CheckCommand(SudokuGenerator generator, SudokuSolver solver)
        {
            this.generator = generator;
            this.solver = solver;
        }

        public void Execute(HashSet<Field> fields)
        {
            int[][] grid = this.generator.GenerateNewSukoku();
            this.solver.SolveSudoku(grid);
            int[][] solvedGrid = this.solver.GetGrid;

            if (this.isCorrect(grid, fields))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Sorry!");
            }

            Environment.Exit(0);
        }

        private bool isCorrect(int[][] grid, HashSet<Field> fields)
        {
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    Field field = fields.SingleOrDefault(f => f.BoardRow == row && f.BoardCol == col);

                    if (field == null)
                    {
                        throw new ArgumentNullException("Field does not exist!");
                    }

                    if (grid[row][col] != field.Value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
