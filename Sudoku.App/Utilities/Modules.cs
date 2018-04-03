namespace Sudoku.App.Utilities
{
    using System;
    using Sudoku.App.Core;
    using Sudoku.App.Entities;
    using Sudoku.App.Factories;

    public sealed class Modules
    {
        private static readonly Lazy<ModulesManager> ModulesManager = new Lazy<ModulesManager>(() => createManager());

        private Modules()
        {
        }

        public static ModulesManager Instance
        {
            get
            {
                return ModulesManager.Value;
            }
        }

        private static ModulesManager createManager()
        {
            ModulesManager manager = new ModulesManager();

            manager.Register<Mouse, Mouse>();
            manager.Register<BoardManager, BoardManager>();
            manager.Register<SudokuGenerator, SudokuGenerator>();
            manager.Register<SudokuSolver, SudokuSolver>();
            manager.Register<AsciiNumberFactory, AsciiNumberFactory>();
            manager.Register<CommandFactory, CommandFactory>();

            return manager;
        }
    }
}
