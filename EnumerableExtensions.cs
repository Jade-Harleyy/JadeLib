using System;
using System.Collections.Generic;
using System.Linq;

namespace JadeLib
{
    public static class EnumerableExtensions
    {
        public static void AddToArray<T>(ref T[] array, int index, params T[] objs)
        {
            T[] newArray = new T[Math.Max(index, array.Length) + objs.Length];
            Array.Copy(array, newArray, Math.Min(index, array.Length));
            Array.Copy(objs, 0, newArray, index, objs.Length);
            Array.Copy(array, index, newArray, index + objs.Length, array.Length - index);
            array = newArray;
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property) => items.GroupBy(property).Select(x => x.First());
    }
}
