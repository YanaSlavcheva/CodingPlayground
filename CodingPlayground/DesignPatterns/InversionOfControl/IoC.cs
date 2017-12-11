using System;
using System.Collections.Generic;

namespace DesignPatterns.InversionOfControl
{
    public static class IoC
    {
        private static readonly IDictionary<Type, Type> types = new Dictionary<Type, Type>();

        private static readonly IDictionary<Type, object> typeInstances = new Dictionary<Type, object>();

        public static void Register<TContract, TImplementation>()
        {
            types[typeof(TContract)] = typeof(TImplementation);
        }

        public static void Register<TContract, TImplementation>(TImplementation instance)
        {
            typeInstances[typeof(TContract)] = instance;
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public static object Resolve(Type contract)
        {
            if (typeInstances.ContainsKey(contract))
            {
                return typeInstances[contract];
            }
            else
            {
                var implementation = types[contract];
                var constructor = implementation.GetConstructors()[0];
                var constructorParameters = constructor.GetParameters();

                if (constructorParameters.Length == 0)
                {
                    return Activator.CreateInstance(implementation);
                }

                var parameters = new List<object>(constructorParameters.Length);

                foreach (var parameterInfo in constructorParameters)
                {
                    parameters.Add(Resolve(parameterInfo.ParameterType));
                }

                return constructor.Invoke(parameters.ToArray());
            }
        }
    }
}
