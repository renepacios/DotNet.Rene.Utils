// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Provides extension methods for the <see cref="Exception"/> class.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets the full message of the exception, including the messages of any inner exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>The full message of the exception.</returns>
        public static string GetFullMessage(this Exception exception)
        {
            if (exception == null) return string.Empty;

            var message = exception.Message;

            if (exception.InnerException != null)
            {
                message = $"{message} ---> {exception.InnerException.GetFullMessage()}";
            }

            return message;
        }
    }
}
