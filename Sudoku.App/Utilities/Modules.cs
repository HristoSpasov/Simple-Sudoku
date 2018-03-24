namespace Sudoku.App.Utilities
{
    using Sudoku.App.Core;
    using Sudoku.App.Entities;
    using Sudoku.App.Factories;

    public sealed class Modules
    {
        private static readonly object Padlock = new object();
        private static ModulesManager instance = null;

        private Modules()
        {
        }

        public static ModulesManager Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (instance == null)
                    {
                        instance = new ModulesManager();
                        instance.Register<Mouse, Mouse>();
                        instance.Register<BoardManager, BoardManager>();
                        instance.Register<SudokuGenerator, SudokuGenerator>();
                        instance.Register<SudokuSolver, SudokuSolver>();
                        instance.Register<AsciiNumberFactory, AsciiNumberFactory>();
                        instance.Register<CommandFactory, CommandFactory>();
                    }

                    return instance;
                }
            }
        }
    }
}
