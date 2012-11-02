using System;
using System.Linq;
using System.Collections.Generic;

namespace CMcG.CodeAlignment.Business
{
    public static class Extensions
    {
        public static IEnumerable<int> UpTo(this int start, int end)
        {
            for (int i = start; i <= end; i++)
                yield return i;
        }

        public static IEnumerable<int> DownTo(this int start, int end)
        {
            for (int i = start; i >= end; i--)
                yield return i;
        }

        public static string ReplaceTabs(this string value, int tabSize)
        {
            int index = value.IndexOf('\t');
            while (index >= 0)
            {
                value = value.Remove(index, 1).Insert(index, string.Empty.PadLeft(tabSize - (index % tabSize)));
                index = value.IndexOf('\t');
            }

            return value;
        }

        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MaxItemsBy(selector).First();
        }

        public static IEnumerable<TSource> MaxItemsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var maxValue = source.Max(selector);
            var comparer = Comparer<TKey>.Default;
            return source.Where(x => comparer.Compare(selector.Invoke(x), maxValue) == 0);
        }

        public static string Aggregate(this IEnumerable<string> source, string join)
        {
            return source.Any() ? source.Aggregate((a, b) => a + join + b) : string.Empty;
        }
    }
}