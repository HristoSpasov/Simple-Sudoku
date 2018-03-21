namespace Sudoku.App.Core
{
    using Sudoku.App.Constants;

    public class SudokuSolver
    {
        private int[][] grid;
        private int backtrack;

        public SudokuSolver()
        {
            this.grid = null;
            this.backtrack = 0;
        }

        public int[][] GetGrid
        {
            get
            {
                return this.grid;
            }
        }

        public int Backtrack
        {
            get
            {
                return this.backtrack;
            }
        }

        public bool SolveSudoku(int[][] grid)
        {
            if (this.grid == null)
            {
                this.grid = grid;
            }

            for (int row = 0; row < SudokuConstants.Size; row++)
            {
                for (int col = 0; col < SudokuConstants.Size; col++)
                {
                    if (this.grid[row][col] == 0)
                    {
                        for (int num = SudokuConstants.MinNum; num <= SudokuConstants.MaxNum; num++)
                        {
                            if (this.isSafe(row, col, num))
                            {
                                this.grid[row][col] = num;

                                if (this.SolveSudoku(grid))
                                {
                                    return true;
                                }

                                this.grid[row][col] = 0;
                            }
                        }

                        this.backtrack++;
                        return false;
                    }
                }
            }

            return true;
        }

        private bool usedInBox(int row, int col, int num)
        {
            int boxStartRow = row - (row % SudokuConstants.BoxSize);
            int boxStartCol = col - (col % SudokuConstants.BoxSize);

            for (int r = 0; r < SudokuConstants.BoxSize; r++)
            {
                for (int c = 0; c < SudokuConstants.BoxSize; c++)
                {
                    if (this.grid[r + boxStartRow][c + boxStartCol] == num)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool usedInCol(int col, int num)
        {
            for (int r = 0; r < this.grid[col].Length; r++)
            {
                if (this.grid[r][col] == num)
                {
                    return true;
                }
            }

            return false;
        }

        private bool usedInRow(int row, int num)
        {
            for (int c = 0; c < this.grid.Length; c++)
            {
                if (this.grid[row][c] == num)
                {
                    return true;
                }
            }

            return false;
        }

        private bool isSafe(int row, int col, int num)
        {
            return !this.usedInRow(row, num) && !this.usedInCol(col, num) && !this.usedInBox(row, col, num);
        }
    }
}