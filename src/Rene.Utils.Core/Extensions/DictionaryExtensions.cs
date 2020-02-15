/*
 *  Copyright (C) 2019  René Pacios
 *
 *  You can use  for Personal or commercial presuppose, but you must maintain the copyright information and author
 *  This code is distributed on an "AS IS" BASIS,  * WITHOUT WARRANTIES OF ANY KIND, USE ON YOUR OWN RISK
 *
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
