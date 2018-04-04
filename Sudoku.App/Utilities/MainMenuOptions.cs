namespace Sudoku.App.Utilities
{
    using System;
    using System.Collections.Generic;

    public sealed class MainMenuOptions
    {
        private static readonly Lazy<List<string>> MenuOptions = new Lazy<List<string>>(() => createMenuOptions());

        private MainMenuOptions()
        {
        }

        public static List<string> Instance
        {
            get
            {
                return MenuOptions.Value;
            }
        }

        private static List<string> createMenuOptions()
        {
            List<string> options = new List<string>
            {
                "New Game",
                "Exit"
            };

            return options;
        }
    }
}
