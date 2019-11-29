/*
 *  Copyright (C) 2018  René Pacios
 *
 *  You can use  for Personal or commercial presuppose, but you must maintain the copyright information and author
 *  This code is distributed on an "AS IS" BASIS,  * WITHOUT WARRANTIES OF ANY KIND, USE ON YOUR OWN RISK
 *
 */


using System.Globalization;
using System.Linq;
using Rene.Utils.Core.Resources;

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
        /// <exception cref="NullReferenceException"></exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            if (source == null) throw new NullReferenceException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(source)));

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
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        public static IEnumerable<T> SelectEach<T>(this IEnumerable<T> source, Func<T, T> action)
        {

            if (source == null) throw new NullReferenceException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(source)));

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
            if (source == null) yield break;
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
            if (list == null)
            {
                yield return item;
                yield break;
            }

            foreach (var l in list)
                yield return l;

            yield return item;
        }


        /// <summary>
        ///  Determines whether a sequence contains any elements. Can be used with null instances
        /// </summary>
        /// <typeparam name="T">  The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IEnumerable.</param>
        /// <param name="predicate"> A function to test each element for a condition.</param>
        /// <returns> true if the source sequence contains any elements; otherwise, false.</returns>
        public static bool AnyNotNull<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            if (source == null) return false;
            return predicate != null ? source.Any(predicate) : source.Any();
        }


        /// <summary>
        ///  Convert Enumerable of T into Enumerable of  tuple with T and Index
        /// </summary>
        /// <typeparam name="T">  The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IEnumerable.</param>
        /// <returns> true if the source sequence contains any elements; otherwise, false.</returns>
        public static IEnumerable<(T item, int index)> AsEnumerableWithIndex<T>(this IEnumerable<T> source)
            => source?.Select((item, index) => (item, index));
    }

}