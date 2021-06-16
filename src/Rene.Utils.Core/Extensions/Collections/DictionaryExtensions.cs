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

    using System.Globalization;
    using Rene.Utils.Core.Resources;

    public static class DictionaryExtensions
    {
        static DictionaryExtensions() { }

        /// <summary>
        /// Add item to dictionary if it not contains key 
        /// </summary>
        /// <typeparam name="TK">Key Type</typeparam>
        /// <typeparam name="T">Value Type</typeparam>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="key">Key</param>
        /// <param name="value">value</param>
        /// <param name="override">[if key exist force update value]</param>
        /// <exception cref="NullReferenceException"></exception>
        public static void AddIfNotExist<TK, T>(this IDictionary<TK, T> dictionary, TK key, T value, bool @override = false)
        {
            if (dictionary == null) throw new NullReferenceException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(dictionary)));
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
                return;
            }

            if (!@override) return;

            dictionary[key] = value;
        }

        /// <summary>
        /// Add or update item into dictionary item collection. It element exist it will by override by default
        /// </summary>
        /// <typeparam name="TK">Key Type</typeparam>
        /// <typeparam name="T">Value Type</typeparam>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="key">Key</param>
        /// <param name="value">value</param>
        /// <exception cref="NullReferenceException"></exception>
        public static void AddToGroup<TK, T>(this IDictionary<TK, IList<T>> dictionary, TK key, T value)
        {
            if (dictionary == null) throw new NullReferenceException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(dictionary)));

            if ((object)key == null) throw new NullReferenceException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(key)));

            if (!dictionary.TryGetValue(key, out var valueList))
            {
                valueList = new List<T>();
                dictionary[key] = valueList;
            }
            valueList.Add(value);
        }

    }
}
