// ReSharper disable once CheckNamespace
namespace System
{
    using Data;

    public class EnsureParam<T> : IEnsureParam
    {

        public string Name { get; }
        public T Value { get; }
        public Type Type => typeof(T);


        internal EnsureParam(T value, string name = null)
        {
            Value = value;
            Name = name;
        }
    }

    public interface IEnsureParam
    {
        Type Type { get; }
        string Name { get; }
    }
}