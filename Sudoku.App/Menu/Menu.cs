namespace Sudoku.App.Menu
{
    using System;
    using System.Collections.Generic;

    public class Menu
    {
        public static void StartMenu()
        {
            List<string> options = new List<string>
            {
                "New Game",
                "Exit"
            };

            Pagination menuPagination = new Pagination(options);
            menuPagination.Paginate();

            switch (menuPagination.ReturnResult())
            {
                case "New Game":
                    break;
                case "Exit": Environment.Exit(0);
                    break;
            }
        }
    }
}
