

// ReSharper disable once CheckNamespace
namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        static DictionaryExtensions() { }

        /// <summary>
        /// Add item to dictionary if it not contains key 
        /// </summary>
        /// <typeparam name="K">Key Type</typeparam>
        /// <typeparam name="T">Value Type</typeparam>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="key">Key</param>
        /// <param name="value">value</param>
        /// <param name="override">[if key exist force update value]</param>
        public static void AddIfNotExist<K, T>(this Dictionary<K, T> dictionary, K key, T value, bool @override = false)
        {
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
