namespace Sudoku.App.Menu
{
    using System;
    using System.Collections.Generic;
    using Sudoku.App.Core;

    public class Pagination
    {
        private List<string> options;
        private string selected;
        private int startIndex = 0;

        public Pagination(List<string> options)
        {
            this.options = options;
        }

        public void Paginate()
        {
            Console.Clear();

            int pointer = this.startIndex;
            string key = string.Empty;

            while (key != "Enter")
            {
                ConsoleManager.DefaultColors();
                Console.Clear();

                for (int i = 0; i < (Console.WindowHeight - this.options.Count) / 2; i++)
                {
                    Console.WriteLine();
                }

                for (int i = 0; i < this.options.Count; i++)
                {
                    ConsoleManager.DefaultColors();

                    if (pointer == this.options.IndexOf(this.options[i]))
                    {
                        ConsoleManager.SelectedOptionColor();
                    }

                    Console.WriteLine(new string(' ', (Console.WindowWidth - this.options[i].Length) / 2) + this.options[i] + new string(' ', (Console.WindowWidth - this.options[i].Length) / 2));
                    this.selected = this.options[pointer];
                }

                key = Console.ReadKey().Key.ToString();

                switch (key)
                {
                    case "UpArrow":
                        pointer--;
                        break;
                    case "DownArrow":
                        pointer++;
                        break;
                    case "Enter":
                        return;
                    case "Escape":
                        break;
                }

                if (pointer > this.options.Count - 1)
                {
                    pointer = this.startIndex;
                }

                if (pointer < this.startIndex)
                {
                    pointer = this.options.Count - 1;
                }

                ConsoleManager.DefaultColors();
            }
        }

        public string ReturnResult()
        {
            return this.selected;
        }
    }
}
