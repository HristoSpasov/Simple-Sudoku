namespace Sudoku.App.Utilities
{
    public sealed class CurrentSourceFile
    {
        private static readonly object Padlock = new object();
        private static string currentSourceFilePath = null;

        private CurrentSourceFile()
        {
        }

        public static string GetPath
        {
            get
            {
                return currentSourceFilePath;
            }
        }

        public static string Instance(string newString)
        {
            if (currentSourceFilePath == null)
            {
                currentSourceFilePath = newString;
            }

            return currentSourceFilePath;
        }
    }
}
