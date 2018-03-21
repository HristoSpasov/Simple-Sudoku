namespace Sudoku.App
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Sudoku.App.Core;
    using Sudoku.App.Entities;
    using Sudoku.App.Factories;

    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = configureServices();

            BoardManager boardManager = new BoardManager(serviceProvider);
            Mouse mouse = new Mouse();

            Engine engine = new Engine(serviceProvider, boardManager, mouse);
            engine.Run();
        }

        private static IServiceProvider configureServices()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<SudokuGenerator, SudokuGenerator>();
            serviceCollection.AddTransient<BoardManager, BoardManager>();
            serviceCollection.AddTransient<Mouse, Mouse>();
            serviceCollection.AddTransient<SudokuSolver, SudokuSolver>();

            serviceCollection.AddTransient<AsciiNumberFactory, AsciiNumberFactory>();
            serviceCollection.AddTransient<CommandFactory, CommandFactory>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
