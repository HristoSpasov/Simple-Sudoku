namespace Sudoku.App.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Sudoku.App.Interfaces;

    public class CommandFactory
    {
        private readonly IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand GetCommand(string cmdName)
        {
            string commandFullName = cmdName + "Command";

            Type cmdType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SingleOrDefault(t => t.Name == commandFullName);

            if (cmdType == null)
            {
                throw new ArgumentNullException($"{cmdName} does not exist!");
            }

            ConstructorInfo constructor = cmdType.GetConstructors().Single();

            Type[] constructorParameters = constructor
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .ToArray();

            object[] dependencies = constructorParameters
                .Select(this.serviceProvider.GetService)
                .ToArray();

            ICommand command = (ICommand)constructor.Invoke(dependencies);

            return command;
        }
    }
}
