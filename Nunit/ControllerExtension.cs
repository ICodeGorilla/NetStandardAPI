using System;
using System.Collections.Generic;
using System.Linq;

namespace NTests
{
    public static class ControllerExtension
    {
        public static T ResolveController<T>(this IServiceProvider serviceProvider)
        {
            var parameters = GetParametersForController<T>(serviceProvider);
            return (T)Activator.CreateInstance(typeof(T), parameters);
        }
        
        private static object[] GetParametersForController<T>(IServiceProvider serviceProvider)
        {
            var ctors = typeof(T).GetConstructors();
            //We just want to use the first constuctor for now
            var ctor = ctors[0];

            return ctor.GetParameters().OrderBy(p => p.Position).Select(param => serviceProvider.GetService(param.ParameterType)).ToArray();
        }
    }

}
