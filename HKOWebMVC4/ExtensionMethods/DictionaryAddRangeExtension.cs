using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HKOWebMVC4.ExtensionMethods
{
    public static class DictionaryAddRangeExtension
    {        public static void AddRange<T, S>(this Dictionary<T, S> source, Dictionary<T, S> collection)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    if (!source.ContainsKey(item.Key))
                    {
                        source.Add(item.Key, item.Value);
                    }
                }
            }
        }
    }
}