using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.util
{
    class CSAssemblyHelper
    {
        /** Returns a list of types that derive from a given type. */
        public static List<Type> getSubtypes<T>() where T : class
        {
            System.Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            return (from System.Type type in types where type.IsSubclassOf(typeof(T))
                                                      || (   typeof(T).IsAssignableFrom(type)
                                                          && typeof(T) != type)
                    select type).ToList();

        }

        public static T instantiateType<T>(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }

        public static T instantiateType<T>(Type type, object[] args)
        {
            return (T)Activator.CreateInstance(type, args);
        }
    }
}
