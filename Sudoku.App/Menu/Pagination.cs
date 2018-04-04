namespace Sudoku.App.Menu
{
    using System;
    using System.Collections.Generic;
    using Sudoku.App.Core;

    public class Pagination
    {
        private string selected;
        private int startIndex = 0;

        public Pagination()
        {
        }

        public void Paginate(List<string> options)
        {
            Console.Clear();

            int pointer = this.startIndex;

            while (true)
            {
                ConsoleManager.DefaultColors();
                Console.Clear();

                for (int i = 0; i < (Console.WindowHeight - options.Count) / 2; i++)
                {
                    Console.WriteLine();
                }

                for (int i = 0; i < options.Count; i++)
                {
                    ConsoleManager.DefaultColors();

                    if (pointer == options.IndexOf(options[i]))
                    {
                        ConsoleManager.SelectedOptionColor();
                    }

                    Console.WriteLine(new string(' ', (Console.WindowWidth - options[i].Length) / 2) + options[i] + new string(' ', (Console.WindowWidth - options[i].Length) / 2));
                    this.selected = options[pointer];
                }

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        pointer--;
                        break;
                    case ConsoleKey.DownArrow:
                        pointer++;
                        break;
                    case ConsoleKey.Enter:
                        return;
                }

                if (pointer > options.Count - 1)
                {
                    pointer = this.startIndex;
                }
                else if (pointer < this.startIndex)
                {
                    pointer = options.Count - 1;
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
