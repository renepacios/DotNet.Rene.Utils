/*
												\||||||/
												 ( o o )
------------------------------------------- oooO---(_)---Oooo-------------------------------------------------------
Author: 	René Pacios
			https://www.webrene.es/	
			Copyright (c) 2012, René Pacios

Created: 2020, 8, 16, 13:51

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
    using Globalization;
    using Linq;
    using Rene.Utils.Core.Resources;
    using ComponentModel;
    using Data;

    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Extend internal ForEach Method add item index to where callback
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
        ///     Get ListItems after apply where to each item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="where"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        public static IEnumerable<T> SelectEach<T>(this IEnumerable<T> source, Func<T, T> @where)
        {

            if (source == null) throw new NullReferenceException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(source)));

            foreach (var item in source)
                yield return @where(item);
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


        /// <summary>
        /// Create data table from object collection
        /// </summary>
        /// <param name="data">Data collection to populate dataTable</param>
        /// <param name="tableName">Optional table name. Item type is default value</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DataTable ToDataTable<T>(this IEnumerable<T> data, string tableName = "")
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            table.TableName = !string.IsNullOrEmpty(tableName)
                ? tableName
                : typeof(T).Name;

            for (var i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
               var  desc= prop.Attributes.OfType<DescriptionAttribute>().FirstOrDefault();
               var columnName = desc?.Description ?? prop.Name;
               table.Columns.Add(columnName, prop.PropertyType);
            }

            var values = new object[props.Count];

            foreach (T item in data)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            return table;
        }
        
        /// <summary>
        /// Get list item type
        /// </summary>
        /// <returns>Item type</returns>
        public static Type GetItemType<T>(this IEnumerable<T> _) => typeof(T);

    }

}