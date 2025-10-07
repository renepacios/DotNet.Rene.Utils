/*
                                                \||||||/
                                                 ( o o )
------------------------------------------- oooO---(_)---Oooo-------------------------------------------------------
Author: 	René Pacios
            https://www.webrene.es/
            Copyright (c) 2012, René Pacios

Created: 2025, 10, 7, 18:51

 Permission is hereby granted, free of charge, to any person  obtaining a copy of this software and
associated documentation files (the "Software"), to deal in the Software without  restriction, including
without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished to do so, subject
to the following  conditions:

    The above copyright notice and this permission notice shall be
    included in all copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.

                                           oooO
                                          (    )      Oooo
-------------------------------------------\  (------(    )----------------------------------------------------------------
                                            \_)       )  /
                                                      (_/

*/


// ReSharper disable once CheckNamespace
namespace System.Collections.Generic
{
    using Rene.Utils.Core.Resources;
    using Globalization;
    using Linq;

    public static class ListExtensions
    {
        static ListExtensions()
        {

        }


        /// <summary>
        /// Add item to list if not exists item that match with condition
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="value">value</param>
        /// <param name="condition">Expression to check if element exist in list</param>
        /// <param name="override">[if key exist force update value]</param>
        /// <exception cref="NullReferenceException"></exception>
        public static void AddIfNotExist<T>(this IList<T> list, T value, Func<T,T, bool> condition, bool @override = false)
        {
            if (list == null) throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(list)));
            if (condition == null) throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(condition)));
            if (list.Any(x=> condition(value,x)))
            {
                if (!@override) return;

                var existingItem = list.First(x => condition(value, x));
                var index = list.IndexOf(existingItem);
                if (index >= 0)
                {
                    list[index] = value;
                }
                return;
            }

            list.Add(value);

        }

        /// <summary>
        /// Add elements to list if not exists item that match with condition
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="values">values to add </param>
        /// <param name="condition">Expression to check if element exist in list</param>
        /// <param name="override">[if key exist force update value]</param>
        /// <exception cref="NullReferenceException"></exception>
        public static void AddRangeIfNotExist<T>(this IList<T> list, IEnumerable<T> values, Func<T,T, bool> condition, bool @override = false)
        {
            if (list == null) throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(list)));
            if (condition == null) throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(condition)));
            if (values == null) return;
            foreach (var value in values)
            {
                list.AddIfNotExist(value, condition, @override);
            }
        }
    }
}
