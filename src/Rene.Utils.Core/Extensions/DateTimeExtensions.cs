/*
 *  Copyright (C) 2018  René Pacios
 *
 *  You can use  for Personal or commercial presuppose, but you must maintain the copyright information and author
 *  This code is distributed on an "AS IS" BASIS,  * WITHOUT WARRANTIES OF ANY KIND, USE ON YOUR OWN RISK
 *
 */

// ReSharper disable once CheckNamespace
namespace System
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns true if the date is between or equal to one of the two values.
        /// </summary>
        /// <param name="date">DateTime from where the calculation will be preformed.</param>
        /// <param name="fromDate">Start date to check for</param>
        /// <param name="toDate">End date to check for</param>
        /// <returns>boolean value indicating if the date is between or equal to one of the two values</returns>
        public static bool IsBetween(this DateTime date, DateTime fromDate, DateTime toDate)
        {
            var ticks = date.Ticks;
            return ticks >= fromDate.Ticks && ticks <= toDate.Ticks;
        }

        /// <summary>
        /// Returns 12:59:59pm time for the date passed.
        /// Useful for date only search ranges end value
        /// </summary>
        /// <param name="date">Date to convert</param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime date)
        {
            return date.Date.AddDays(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Returns 12:00am time for the date passed.
        /// Useful for date only search ranges start value
        /// </summary>
        /// <param name="date">Date to convert</param>
        /// <returns></returns>
        public static DateTime BeginningOfDay(this DateTime date)
        {
            return date.Date;
        }

    }
}
