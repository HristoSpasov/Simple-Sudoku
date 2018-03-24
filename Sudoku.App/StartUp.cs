namespace Sudoku.App
{
    using Sudoku.App.Core;
    using Sudoku.App.Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ModulesManager manager = Modules.Instance;

            Engine engine = new Engine(manager);
            engine.Run();
        }
    }
}
