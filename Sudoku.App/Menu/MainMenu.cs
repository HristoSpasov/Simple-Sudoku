namespace Sudoku.App.Menu
{
    using System;
    using System.Collections.Generic;
    using Sudoku.App.Utilities;

    public class MainMenu
    {
        private readonly List<string> options;
        private readonly Pagination menuPagination;

        public MainMenu(Pagination menuPagination)
        {
            this.options = MainMenuOptions.Instance;
            this.menuPagination = menuPagination;
        }

        public void StartMenu()
        {
            this.menuPagination.Paginate(this.options);

            switch (this.menuPagination.ReturnResult())
            {
                case "New Game":
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
