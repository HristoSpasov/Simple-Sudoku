namespace Sudoku.App.Core
{
    using System;
    using Sudoku.App.Constants;

    public static class ConsoleManager
    {
        public static void SetTheConsoleForTheGame()
        {
            Console.CursorVisible = false;

            Console.WindowHeight = ConsoleConstants.Height;
            Console.WindowWidth = ConsoleConstants.Width;
        }

        public static void SelectedOptionColor()
        {
            Console.ForegroundColor = ConsoleConstants.SelectedOptionForegroundColor;
            Console.BackgroundColor = ConsoleConstants.SelectedOptionBackgroundColor;
        }

        public static void DefaultColors()
        {
            Console.ForegroundColor = ConsoleConstants.ForegroundColor;
            Console.BackgroundColor = ConsoleConstants.BackgroundColor;
        }

        public static void SetCursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static void WriteSingleChar()
        {
            Console.Write(' ');
        }

        public static void WriteSingleChar(char c)
        {
            Console.Write(c);
        }

        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey(true);
        }
    }
}
