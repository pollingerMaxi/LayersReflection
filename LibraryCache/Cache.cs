using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCache
{
    public static class Cache
    {
        private static Dictionary<Type, Type> typeCache = new Dictionary<Type, Type>();

        public static IT GetInstance<IT>() where IT : class
        {
            if (!typeCache.ContainsKey(typeof(IT)))
            {
                var assemblies = Directory.GetFiles(".", "*.dll");
                foreach (var assemblyName in assemblies)
                {
                    Assembly a = Assembly.LoadFrom(assemblyName);
                    var matchingType = a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IT))).FirstOrDefault();
                    if(matchingType != null)
                    {
                        typeCache.Add(typeof(IT), matchingType);
                        break;
                    }
                }
            }
            var type = typeCache[typeof(IT)];
            return type.GetConstructor(Type.EmptyTypes).Invoke(null) as IT;
        }

        public static void ForceInterfaceMapping(Type interfaceType, Type concreteType)
        {
            if (!typeCache.ContainsKey(interfaceType))
            {
                typeCache.Add(interfaceType, concreteType);
            }
            else
            {
                typeCache[interfaceType] = concreteType;
            }
        }
    }
}
