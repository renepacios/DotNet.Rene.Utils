// ReSharper disable once CheckNamespace
namespace System
{
    using Collections.Generic;
    using Linq;
    using System.ComponentModel;
    using System.Reflection;


    public static class EnumHelper<T>
    {
        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }


        public static IList<T> GetValues()
        {
            var enumValues = new List<T>();
            Type type = typeof(T);

            foreach (FieldInfo fi in type.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(type, fi.Name, false));
            }

            return enumValues;
        }

        public static IList<string> GetNames()
        {
            return typeof(T)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(fi => fi.Name)
                .ToList();
        }

        public static IList<string> GetDisplayValues()
        {
            return GetValues().Select(obj => (obj as Enum)?.ToDisplayValue()).ToList();

        }


        /// <summary>
        /// Get all enum values with value, string value and description value if exist
        /// </summary>
        /// <example>
        ///     IList<(int key, string name, string description)> dev = EnumHelper<Sytem.PlatformID>.GetNameValueDescriptions();
        ///
        /// </example>
        /// <returns></returns>
        public static IList<(int, string, string)> GetNameValueDescriptions()
        {
            int EnumParse(string s) => (int)Enum.Parse(typeof(T), s, true);

            string GetDescription(FieldInfo fi) =>
                fi.GetCustomAttribute<DescriptionAttribute>()?.Description ?? fi.Name;

            return typeof(T)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(fi => (EnumParse(fi.Name), fi.Name, GetDescription(fi)))
                .ToList();
        }

    }
}
