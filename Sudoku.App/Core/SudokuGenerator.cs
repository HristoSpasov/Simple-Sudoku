namespace Sudoku.App.Core
{
    using System;
    using System.IO;
    using System.Linq;
    using Sudoku.App.Constants;
    using Sudoku.App.Utilities;

    public class SudokuGenerator
    {
        public SudokuGenerator()
        {
        }

        public int[][] GenerateNewSukoku()
        {
            int[][] grid = new int[SudokuConstants.Size][];

            string allPatternsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Files\Patterns\"));
            string[] patterns = Directory.GetFiles(allPatternsPath);

            int patternId = this.getRandomId(patterns.Length);
            string patternPath = Path.GetFullPath(Path.Combine(allPatternsPath, patterns[patternId]));

            patternPath = CurrentSourceFile.Instance(patternPath);

            using (StreamReader reader = new StreamReader(patternPath))
            {
                int gridLineCounter = 0;

                while (!reader.EndOfStream)
                {
                    int[] lineArgs = reader.ReadLine()
                        .Split(SudokuConstants.Delimiter)
                        .Select(int.Parse)
                        .ToArray();

                    grid[gridLineCounter] = lineArgs;

                    gridLineCounter++;
                }
            }

            return grid;
        }

        private int getRandomId(int length)
        {
            Random rnd = new Random();
            int randomNum = rnd.Next(0, length);

            return randomNum;
        }
    }
}
