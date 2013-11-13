using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// Method extensions de la clase String.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a null string if the current value is empty or white spaces.
        /// </summary>
        /// <param name="str">String to evaluate.</param>
        /// <returns>A non-empty string or a null.</returns>
        public static string GetNullIfEmpty(this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return null;

            return str;
        }

        /// <summary>
        /// Returns an empty string if the current value is null.
        /// </summary>
        /// <param name="str">String a evaluar.</param>
        /// <returns>a non-null string.</returns>
        public static string GetEmptyIfNull(this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return String.Empty;

            return str;
        }

        /// <summary>
        /// Parses the string as an integer.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 32-bit signed integer equivalent to the number contained in s.</returns>
        public static int IntParse(this string str)
        {
            int value;
            Int32.TryParse(str, out value);
            return value;
        }

        /// <summary>
        /// Parses the string as a nullable integer.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 32-bit signed integer equivalent to the number contained in s, or a null.</returns>
        public static int? NullableIntParse(this string str)
        {
            int value;
            if (Int32.TryParse(str, out value))
                return value;

            return null;
        }

        /// <summary>
        /// Parses the string as a double.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns> A double-precision floating-point number that is equivalent to the numeric value or symbol specified in s.</returns>
        public static double DoubleParse(this string str)
        {
            double value;
            Double.TryParse(str, out value);
            return value;
        }

        /// <summary>
        /// Parses the string as a nullable double.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns> A double-precision floating-point number that is equivalent to the numeric value or symbol specified in s, or null.</returns>
        public static double? NullableDoubleParse(this string str)
        {
            double value;
            if (Double.TryParse(str, out value))
                return value;

            return null;
        }

        public static DateTime DateTimeParse(this string str)
        {
            DateTime value;
            DateTime.TryParse(str, out value);
            return value;
        }

        public static DateTime? NullableDateTimeParse(this string str)
        {
            DateTime value;
            if (DateTime.TryParse(str, out value))
                return value;

            return null;
        }

        public static TimeSpan TimeSpanParse(this string str)
        {
            TimeSpan value;
            TimeSpan.TryParse(str, out value);
            return value;
        }

        public static TimeSpan? NullableTimeSpanParse(this string str)
        {
            TimeSpan value;
            if (TimeSpan.TryParse(str, out value))
                return value;

            return null;
        }

        /// <summary>
        /// Parses the values of a csv line.
        /// </summary>
        /// <param name="line">Line to parse.</param>
        /// <returns>Collection of values. Null if the line is not valid.</returns>
        public static IEnumerable<string> GetCommaSeparatedValues(this string line)
        {
            int start = 0;
            bool inside = false;
            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case ';':
                        if (inside)
                            continue;

                        // if the value is enclosed in quotation marks, I will skip those.
                        if (line[start] == '"' && line[i - 1] == '"')
                        {
                            yield return line.Substring(start + 1, i - start - 2);
                        }
                        else
                        {
                            yield return line.Substring(start, i - start);
                        }
                        start = i + 1;
                        break;
                    case '"':
                        if (inside && i + 1 < line.Length && line[i + 1] == '"')
                            i++;
                        else
                            inside = !inside;
                        break;
                }
            }
            if (start < line.Length - 1)
            {
                if (line[start] == '"' && line[line.Length - 1] == '"')
                {
                    yield return line.Substring(start + 1, line.Length - start - 2);
                }
                else
                {
                    yield return line.Substring(start, line.Length - start);
                }
            }
        }

        public static string GetQueryStringValue(this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return "NULL";

            return String.Concat('\'', str.Replace("'", "''"), '\'');
        }

        public static string ToSecureJsonString(this string str)
        {
            return str.Replace("'", "&apos;");
        }
    }
}
