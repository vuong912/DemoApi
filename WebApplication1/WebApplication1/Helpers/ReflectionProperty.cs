using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public class ReflectionProperty
    {
        public static PropertyInfo Get(Object obj,string propertyName)
        {
            return obj.GetType().GetProperty(propertyName,
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.IgnoreCase);
        }
    }
}
