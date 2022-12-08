

// ReSharper disable once CheckNamespace
namespace System
{
    using Rene.Utils.Core.Extensions.Guards.Internals;

    public static class Ensure
    {
        public static EnsureParam<T> Argument<T>(T value, string name = null)
        {
           return new EnsureParam<T>(value, name);
        }

    }
}
