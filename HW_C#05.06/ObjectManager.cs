using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HW_C_05._06
{
    public static class ObjectManager
    {
        public static Dictionary<Type, double> AverageStringPropertyObject<T>(IEnumerable<T> objects)
        {
            return objects
                .GroupBy(x => x.GetType())
                .ToDictionary(
                group => group.Key,
                group => group
                .SelectMany(o => o.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(string))
                .Select(p => p.GetValue(o) as string)
                .Where(value => value != null)
                .Select(value => value.Length))
                .DefaultIfEmpty(0)
                .Average());
        }
    }
}
