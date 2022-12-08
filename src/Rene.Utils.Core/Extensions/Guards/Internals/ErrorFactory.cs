using System;

namespace Rene.Utils.Core.Extensions.Guards.Internals
{
    using Resources;

    internal static class ErrorFactory
    {
        public static Exception BuildTypeCheckException(IEnsureParam param, Type checkType, string message = null)
        {
            //return new ArgumentException($"{param.Name} param must be {checkType.FullName} but is {param?.Type.FullName}")
            var msg = message ?? string.Format(ExceptionMessages.Ensure_Type_Is_Invalid, param.Name, checkType, param.Type.FullName);

            return new ArgumentException(msg);
        }
    }
}
