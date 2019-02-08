using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeLibrary
{
    public static partial class ExtensionMethods
    {
        #region arrays

        public static string Join<T>(this T[] array, string str)
        {
            StringBuilder sb = new StringBuilder();
            int index = 1;
            foreach (T item in array)
            {
                sb.Append(item.ToString());
                sb.Append((index++ < array.Length) ? str : "");
            }
            return sb.ToString();
        }

        #endregion arrays

        #region IEnumerable

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            source.ThrowIfNull("source");
            action.ThrowIfNull("action");
            foreach (T element in source)
            {
                action(element);
            }
        }

        public static void ToConsole<T>(
            this IEnumerable<T> list, string formatStr = "")
        {
            foreach (var item in list)
            {
                string.Format(formatStr, item).ToConsole();
            }
        }

        public static List<string> ToStringList<T>(this IEnumerable<T> list)
        {
            List<string> output = new List<string> { };
            foreach (var item in list)
            {
                output.Add(item.ToString());
            }
            return output;
        }

        public static string NumberString<T>(this IEnumerable<T> set)
        {
            return set.ToArray().Join(",");
        }

        public static void ToConsole<T>(this IEnumerable<T> list)
        {
            list.ToArray().Join(",").ToConsole();
        }

        public static long Product(this IEnumerable<int> set)
        {
            return set.Aggregate((long)1, (x, y) => x = (long)(x * y));
        }

        //public static int Sum(this IEnumerable<int> set)
        //{
        //    return set.Aggregate(0, (x, y) => x = x + y);
        //}

        #endregion IEnumerable

        #region List<T>

        public static List<T> ForEach<T>(this List<T> source, Func<T, T> action)
        {
            List<T> result = new List<T> { };
            source.ThrowIfNull("source");
            foreach (T element in source)
            {
                result.Add(action(element));
            }
            return result;
        }

        public static List<T> Copy<T>(this List<T> set)
        {
            T[] temp = new T[set.Count];
            set.CopyTo(temp);
            return temp.ToList<T>();
        }

        public static HashSet<T> ToHashSet<T>(this List<T> set)
        {
            HashSet<T> result = new HashSet<T> { };
            foreach(var item in set)
            {
                result.Add(item);
            }
            return result;
        }

        public static T Last<T>(this List<T> set)
        {
            int lastIndex = set.Count - 1;
            return set[lastIndex];
        }

        #endregion List<T>

        #region HashSet<T>

        public static HashSet<T> CopyWith<T>(this HashSet<T> set, HashSet<T> otherSet)
        {
            HashSet<T> newSet = new HashSet<T> { };
            foreach (var item in set)
                newSet.Add(item);
            foreach (var item in otherSet)
                newSet.Add(item);
            return newSet;
        }

        public static bool IsEmpty<T>(this HashSet<T> collection)
        {
            return collection.Count == 0;
        }

        public static int Sum(this HashSet<int> set)
        {
            int accumulator = 0;
            foreach (int i in set)
            {
                accumulator += i;
            }
            return accumulator;
        }

        public static void PrintLines(this HashSet<int> set, string extra = "")
        {
            for (int i = 0; i < set.Count; i++)
            {
                $"{extra}[{i}]: {set.ElementAt(i)}".ToConsole();
            }
        }

        public static HashSet<int> SelectEvens(this HashSet<int> set)
        {
            HashSet<int> result = new HashSet<int> { };
            foreach (var item in set)
            {
                if (item % 2 == 0) result.Add(item);
            }
            return result;
        }

        public static void ToString(this HashSet<long> set)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in set)
            {
                sb.Append($"[{item}],");
            }
            sb.ToString().TrimEnd().ToConsole();
        }

        public static HashSet<T> AddRange<T>(this HashSet<T> set, HashSet<T> otherset)
        {
            foreach (var item in otherset)
            {
                set.Add(item);
            }
            return set;
        }

        public static List<T> ToList<T>(this HashSet<T> set)
        {
            List<T> list = new List<T> { };
            foreach (var item in set)
            {
                list.Add(item);
            }
            return list;
        }        

        public static T[] ToArray<T>(this HashSet<T> source)
        {
            return source.ToList().ToArray();
        }

        #endregion HashSet<T>

    }
}
