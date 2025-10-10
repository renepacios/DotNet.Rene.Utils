using System.Text;
using Rene.Utils.Core.Resources;

// ReSharper disable once CheckNamespace
namespace System;

public static class StringExtensionsBase64
{

   

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

    public static byte[] ToByteArrayFromBase64(this string base64String)
    {
        if (string.IsNullOrEmpty(base64String))
            throw new ArgumentException(ExceptionMessages.StringNullArgumentFormat, nameof(base64String));
        if (!base64String.Contains("base64,"))
            throw new FormatException($"{base64String} is not a valid Base64 string");

        var base64 = GetOnlyBase64String(base64String);
        var bytes = Convert.FromBase64String(base64);

        return bytes;

        string GetOnlyBase64String(string s) => !string.IsNullOrEmpty(s) && s.Contains(",")
            ? s.Split(',')[1]
            : s;
    }



}