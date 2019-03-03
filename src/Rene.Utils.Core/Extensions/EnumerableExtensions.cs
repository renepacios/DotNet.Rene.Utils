/*
 *  Copyright (C) 2018  René Pacios
 *
 *  You can use  for Personal or commercial presuppose, but you must maintain the copyright information and author
 *  This code is distributed on an "AS IS" BASIS,  * WITHOUT WARRANTIES OF ANY KIND, USE ON YOUR OWN RISK
 *
 */


using System.Linq;
// ReSharper disable once CheckNamespace
namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Extend internal ForEach Method add item index to action callback
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var i = 0;
            foreach (var item in source)
            {
                action(item, i);
                i++;
            }
        }


        /// <summary>
        ///     Get ListItems after apply action to each item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> SelectEach<T>(this IEnumerable<T> source, Func<T, T> action)
        {
            foreach (var item in source)
                yield return action(item);
        }

        /// <summary>
        ///     Add element at first position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
        {
            yield return item;
            foreach (var l in source)
                yield return l;
        }


        /// <summary>
        ///     Add element at last position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> list, T item)
        {
            foreach (var l in list)
                yield return l;

            yield return item;
        }


        /// <summary>
        ///  Determines whether a sequence contains any elements. Can be used with null instances
        /// </summary>
        /// <typeparam name="T">  The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IEnumerable`1 to check for emptiness.</param>
        /// <param name="predicate"> A function to test each element for a condition.</param>
        /// <returns> true if the source sequence contains any elements; otherwise, false.</returns>
        public static bool AnyNotNull<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            if (source == null) return false;
            return predicate != null ? source.Any(predicate) : source.Any();
        }
    }

}