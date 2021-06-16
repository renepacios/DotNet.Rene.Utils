/*
												\||||||/
												 ( o o )
------------------------------------------- oooO---(_)---Oooo-------------------------------------------------------
Author: 	René Pacios
			https://www.webrene.es/	
			Copyright (c) 2012, René Pacios

Created: 2020, 12, 5, 23:28

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
namespace System
{
    using Collections.Generic;
    using Linq;
    using System.ComponentModel;
    using System.Reflection;

    [Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1000:Do not declare static members on generic types",
        Justification = "Is a Helper Method. Structure is a sortcut to use")]
    public static class EnumSource<T>
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
