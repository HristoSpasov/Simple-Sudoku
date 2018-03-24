namespace Sudoku.App.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Sudoku.App.Interfaces;
    using Sudoku.App.Utilities;

    public class CommandFactory
    {
        private readonly ModulesManager modulesManager;

        public CommandFactory()
        {
            this.modulesManager = Modules.Instance;
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

            object[] dependencies = new object[constructorParameters.Length];
            int counter = 0;
            foreach (Type param in constructorParameters)
            {
                object instance =
                    this.modulesManager.GetType()
                        .GetMethod("GetService")
                        .MakeGenericMethod(new[] { param })
                        .Invoke(this.modulesManager, null);

                dependencies[counter] = instance;
                counter++;
            }

            ICommand command = (ICommand)constructor.Invoke(dependencies);

            return command;
        }
    }
}
