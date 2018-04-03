namespace Sudoku.App.Utilities
{
    using System;

    public sealed class CurrentSourceFile
    {
        private static Lazy<string> sourceFileName;

        private CurrentSourceFile()
        {
        }

        public static string Instance(string newString)
        {
            if (sourceFileName == null)
            {
                sourceFileName = new Lazy<string>(() => newString);
            }

            return sourceFileName.Value;
        }
    }
}
