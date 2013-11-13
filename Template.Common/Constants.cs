using System;
using System.Threading;

namespace Template.Common
{
    class Constants
    {
        /// <summary>
        /// Gets the birthday format of the current thread culture.
        /// Example: M/d
        /// </summary>
        public static string BirthdayFormat { get { return Thread.CurrentThread.CurrentCulture.Name.Equals("es-AR") ? "d/M" : "M/d"; } }

        /// <summary>
        /// Gets the date format of the current thread culture.
        /// Example: M/dd/yyyy
        /// </summary>
        public static string DateFormat { get { return Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern; } }

        /// <summary>
        /// Gets the date-time format of the current thread culture.
        /// Example: M/dd/yyyy hh:mm a
        /// </summary>
        public static string DateTimeFormat { get { return String.Concat(Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern, " ", Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortTimePattern); } }
    }
}
