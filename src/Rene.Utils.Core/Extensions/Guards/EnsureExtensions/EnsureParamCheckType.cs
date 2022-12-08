// ReSharper disable once CheckNamespace
namespace Rene.Utils.Core.Extensions.Guards.EnsureExtensions
{
    using System;
    using Rene.Utils.Core.Extensions.Guards.Internals;

    public static class EnsureParamCheckType
    {
        public static IEnsureParam IsInt(this IEnsureParam param) => param.CheckType(typeof(int));
        public static IEnsureParam IsString(this IEnsureParam param) => param.CheckType(typeof(string));
        public static IEnsureParam IsDouble(this IEnsureParam param) => param.CheckType(typeof(double));
        public static IEnsureParam IsLong(this IEnsureParam param) => param.CheckType(typeof(long));
        public static IEnsureParam IsBool(this IEnsureParam param) => param.CheckType(typeof(bool));
        public static IEnsureParam IsDecimal(this IEnsureParam param) => param.CheckType(typeof(decimal));


        private static IEnsureParam CheckType(this IEnsureParam param, Type typeToCheck, string message = null)
        {
            if (param.Type != typeToCheck)
            {
                throw ErrorFactory.BuildTypeCheckException(param, typeToCheck, message);
            }

            return param;
        }
    }
}