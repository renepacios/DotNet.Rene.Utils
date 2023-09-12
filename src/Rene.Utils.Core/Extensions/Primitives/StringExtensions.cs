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
using System.Collections.Generic;
using System.Globalization;
using System.Text;

// ReSharper disable once CheckNamespace
namespace System
{
    public static class StringExtensions
    {
        #region Base 64

        /// <summary>
        ///     Converts string to its equivalent string that is encoded with base-64 digits.
        /// </summary>
        /// <param name="text">The string to convert</param>
        /// <returns>String encoded with base-64 equivalent to text </returns>
        public static string ToBase64(this string text)
        {
            var b = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(b);
        }

        /// <summary>
        ///     Converts the specified string, which encodes binary data as base-64 digits, to an equivalent clear text string
        /// </summary>
        /// <param name="base64String">The string to convert</param>
        /// <returns>A String that is equivalent to base64String</returns>
        public static string ToStringFromBase64(this string base64String)
        {
            var b = Convert.FromBase64String(base64String);
            return Encoding.UTF8.GetString(b);
        }

        #endregion

        #region Conversiones

        /// <summary>
        ///     Converts the string representation of a GUID to the equivalent System.Guid structure.
        /// </summary>
        /// <param name="s">The String GUID to convert</param>
        /// <returns>
        ///     A  valid System.Guid.
        /// </returns>
        public static Guid ToGuid(this string s)
        {
            Guid g;
            if (!Guid.TryParse(s, out g))
                throw new FormatException($"{s} is not a valid GUID");

            return g;
        }

        /// <summary>
        ///     Converts the string representation of a GUID to the equivalent System.Guid structure or Empty Guid if it's not possible.
        /// </summary>
        /// <param name="s">The String GUID to convert</param>
        /// <returns>
        ///     A  valid System.Guid.
        /// </returns>
        public static Guid ToGuidOrDefault(this string s)
        {
            return !Guid.TryParse(s, out var g) 
                ? Guid.Empty 
                : g;
        }

        /// <summary>
        ///     Converts the string representation of a GUID to the equivalent System.Guid structure or Empty Guid if it's not possible.
        /// </summary>
        /// <param name="s">The String GUID to convert</param>
        /// <param name="defaultValue">Return value when conversion it's not possible</param>
        /// <returns>
        ///     A  valid System.Guid.
        /// </returns>
        public static Guid ToGuidOrDefault(this string s,Guid defaultValue) =>
            Guid.TryParse(s, out var g) 
                ? g 
                : defaultValue;

        /// <summary>
        ///     Converts the string representation of a number to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="s">A string containing a number to convert</param>
        /// <returns>
        ///     Number
        ///     When this method returns, contains the 32-bit signed integer value equivalent
        ///     of the number contained in s, if the conversion succeeded, or zero if the conversion *
        ///     failed.
        /// </returns>
        public static int ToInt(this string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            return int.TryParse(s.Trim(), out var salida)
                ? salida
                : 0;
        }



        /// <summary>
        ///     Returns an enumerable collection of the specified type containing string
        /// </summary>
        /// <param name="s">A string containing sequence elements</param>
        /// <param name="separators">
        /// An array of  characters that delimit the string sub-elements in s param.
        /// </param>
        /// <typeparam name="T">
        /// The type of the element to return in the collection, this type must implement IConvertible.
        /// </typeparam>
        /// <returns>
        /// An enumerable collection whose elements contain the substrings in this instance that are delimited by one or more characters in separators. 
        /// </returns>
        public static IEnumerable<T> SplitTo<T>(this string s, params char[] separators) where T : IConvertible
        {
            if (string.IsNullOrEmpty(s)) { yield break; }


            foreach (var e in s.Split(separators, StringSplitOptions.None))
                yield return (T)Convert.ChangeType(e, typeof(T), CultureInfo.InvariantCulture);
        }


        #endregion
    }
}