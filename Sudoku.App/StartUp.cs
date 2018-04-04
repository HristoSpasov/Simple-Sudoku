namespace Sudoku.App
{
    using Core;
    using Utilities;

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
