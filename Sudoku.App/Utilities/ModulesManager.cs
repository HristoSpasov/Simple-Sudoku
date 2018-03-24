namespace Sudoku.App.Utilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ModulesManager
    {
        private readonly Dictionary<Type, Type> dependencies;
        private readonly Dictionary<Type, object> cache;

        public ModulesManager()
        {
            this.dependencies = new Dictionary<Type, Type>();
            this.cache = new Dictionary<Type, object>();
        }

        public ModulesManager Register<TAbstr, TImpl>()
            where TImpl : TAbstr
        {
            this.dependencies[typeof(TAbstr)] = typeof(TImpl);

            return this;
        }

        public T GetService<T>()
        {
            Type abstractType = typeof(T);
            return (T)this.get(abstractType);
        }

        private object get(Type abstractType)
        {
            // Check if this type is already cached
            if (this.cache.ContainsKey(abstractType))
            {
                return this.cache[abstractType];
            }

            // Process
            Type concreteType = this.dependencies[abstractType];

            ConstructorInfo ctorInfo = concreteType
                .GetConstructors()
                .FirstOrDefault();

            // Itterate over ctor params
            ParameterInfo[] ctorArgs = ctorInfo.GetParameters();

            object[] argsToPassToCtor = new object[ctorArgs.Length];

            int counter = 0;

            foreach (ParameterInfo arg in ctorArgs)
            {
                Type argType = arg.ParameterType;
                object obj = this.get(argType);
                argsToPassToCtor[counter++] = obj;
            }

            // Add to cache
            object objectToCahe = ctorInfo.Invoke(argsToPassToCtor);
            this.cache[abstractType] = objectToCahe;

            // Make instance
            return objectToCahe;
        }
    }
}
