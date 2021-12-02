using System;
using System.Collections.Generic;
using DomainLogic;

namespace Shared
{
    public static class ExtensionMethods
    {
        private static Dictionary<Type, Func<string,object>> specialTypesList = new Dictionary<Type, Func<string,object>>()
        {
            [typeof(Direction)] = ParseDirection
            
        };

        public static T ChangeType<T>(this object obj)
        {
            if (specialTypesList.TryGetValue(typeof(T), out var func))
            {
                return (T)func(obj.ChangeType<string>());
            }

            return (T)Convert.ChangeType(obj, typeof(T));
        }
        
        private static object ParseDirection(string text)
        {
            switch (text)
            {
                case "forward":
                    return Direction.Forward;
                case "up":
                    return Direction.Up;
                case "down":
                    return Direction.Down;
            }

            throw new ArgumentException($"No direction found for {text}");
        }
    }
}
