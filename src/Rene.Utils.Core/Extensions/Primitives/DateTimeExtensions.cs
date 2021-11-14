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
        /// <remarks>     Parameter order is not relevant </remarks>
        /// <returns>boolean value indicating if the date is between or equal to one of the two values</returns>
        public static bool IsBetween(this DateTime date, DateTime fromDate, DateTime toDate)
        {
            var ticks = date.Ticks;
            var from = fromDate.MinCompare(toDate);
            var to = fromDate.MaxCompare(toDate);

            return ticks >= from.Ticks && ticks <= to.Ticks;
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


        /// <summary>
        /// Get min date between two dates
        /// </summary>
        /// <param name="date">Self date</param>
        /// <param name="dateToCompare">Date to compare</param>
        /// <returns>Min date between two arguments</returns>
        public static DateTime MinCompare(this DateTime date, DateTime dateToCompare) 
            => date.Ticks < dateToCompare.Ticks ? date : dateToCompare;


        /// <summary>
        /// Get max date between two dates
        /// </summary>
        /// <param name="date">Self date</param>
        /// <param name="dateToCompare">Date to compare</param>
        /// <returns>Max date value between two arguments</returns>
        public static DateTime MaxCompare(this DateTime date, DateTime dateToCompare) 
            => date.Ticks > dateToCompare.Ticks ? date : dateToCompare;


        /// <summary>
        /// Get date of next specific day of week
        /// </summary>
        /// <param name="date">Date from calculate</param>
        /// <param name="dayOfWeek">Day of week to find</param>
        /// <returns></returns>
        public static DateTime Next(this DateTime date, DayOfWeek dayOfWeek)
        {
            var currentDay = (int)date.Date.DayOfWeek;
            var targetDay = (int) dayOfWeek;

            if (currentDay >= targetDay) //if day is in next week
                targetDay += 7;

            var daysToAdd = targetDay - currentDay;

            return date.AddDays(daysToAdd);
            
        }
    }
}
