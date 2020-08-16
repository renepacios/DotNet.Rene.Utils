
// ReSharper disable once CheckNamespace
namespace System
{

    using ComponentModel;
    using Reflection;

    public static class EnumExtensions
    {
        public static string ToDisplayValue(this Enum value)
        {
            if (value==null) throw  new ArgumentNullException(nameof(value));

            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();
           
            var descrip = field.GetCustomAttribute<DescriptionAttribute>();
            
            return descrip?.Description ?? value.ToString();

            
        }
    }
}