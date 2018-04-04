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

        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
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

        public static void Write(string msg)
        {
            Console.Write(msg);
        }

        public static void WriteLine(string msg)
        {
            Console.Write(msg);
        }

        public static void Clear(int length)
        {
            for (int i = 0; i < length; i++)
            {
                WriteSingleChar();
            }
        }

        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey(true);
        }
    }
}
