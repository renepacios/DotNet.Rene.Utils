

// ReSharper disable once CheckNamespace

using System.Globalization;
using Rene.Utils.Core.Resources;

namespace System.Collections.Generic
{
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
        public static void AddIfNotExist<TK, T>(this Dictionary<TK, T> dictionary, TK key, T value, bool @override = false)
        {
            if (dictionary==null) throw new NullReferenceException(string.Format(CultureInfo.CurrentCulture, ExceptionMessages.NulleReferenceExceptioX0, nameof(dictionary)));
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
                return;
            }

            if (!@override) return;

            dictionary[key] = value;
        }
    }
}
