﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Pictre.DataObjects
{
    public static class Extensions
    {
        /// <summary>
        /// Transform object into Identity data type (integer).
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is -1.</param>
        /// <returns>Identity value.</returns>
        public static int AsId(this object item, int defaultId = -1)
        {
            if (item == null)
                return defaultId;

            int result;
            if (!int.TryParse(item.ToString(), out result))
                return defaultId;

            return result;
        }

        /// <summary>
        /// Transform object into integer data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(int).</param>
        /// <returns>The integer value.</returns>
        public static int AsInt(this object item, int defaultInt = default(int))
        {
            if (item == null)
                return defaultInt;

            int result;
            if (!int.TryParse(item.ToString(), out result))
                return defaultInt;

            return result;
        }

        /// <summary>
        /// Transform object into double data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(double).</param>
        /// <returns>The double value.</returns>
        public static double AsDouble(this object item, double defaultDouble = default(double))
        {
            if (item == null)
                return defaultDouble;

            double result;
            if (!double.TryParse(item.ToString(), out result))
                return defaultDouble;

            return result;
        }

        /// <summary>
        /// Transform object into string data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(string).</param>
        /// <returns>The string value.</returns>
        public static string AsString(this object item, string defaultString = default(string))
        {
            if (item == null || item.Equals(System.DBNull.Value))
                return defaultString;

            return item.ToString().Trim();
        }

        /// <summary>
        /// Transform object into DateTime data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(DateTime).</param>
        /// <returns>The DateTime value.</returns>
        public static DateTime AsDateTime(this object item, DateTime defaultDateTime = default(DateTime))
        {
            if (item == null || string.IsNullOrEmpty(item.ToString()))
                return defaultDateTime;

            DateTime result;
            if (!DateTime.TryParse(item.ToString(), out result))
                return defaultDateTime;

            return result;
        }

        /// <summary>
        /// Transform object into bool data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(bool).</param>
        /// <returns>The bool value.</returns>
        public static bool AsBool(this object item, bool defaultBool = default(bool))
        {
            if (item == null)
                return defaultBool;

            return new List<string>() { "yes", "y", "true" }.Contains(item.ToString().ToLower());
        }

        /// <summary>
        /// Transform string into byte array.
        /// </summary>
        /// <param name="s">The object to be transformed.</param>
        /// <returns>The transformed byte array.</returns>
        public static byte[] AsByteArray(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            return Convert.FromBase64String(s);
        }

        /// <summary>
        /// Transform object into base64 string.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <returns>The base64 string value.</returns>
        public static string AsBase64String(this object item)
        {
            if (item == null)
                return null;
            ;

            return Convert.ToBase64String((byte[])item);
        }

        /// <summary>
        /// Transform Binary into base64 string data type. 
        /// Note: This is used in LINQ to SQL only.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <returns>The base64 string value.</returns>
        public static string AsBase64String(this Binary item)
        {
            if (item == null)
                return null;

            return Convert.ToBase64String(item.ToArray());
        }

        /// <summary>
        /// Transform base64 string to Binary data type. 
        /// Note: This is used in LINQ to SQL only.
        /// </summary>
        /// <param name="s">The base 64 string to be transformed.</param>
        /// <returns>The Binary value.</returns>
        public static Binary AsBinary(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            return new Binary(Convert.FromBase64String(s));
        }

        /// <summary>
        /// Transform object into Guid data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <returns>The Guid value.</returns>
        public static Guid AsGuid(this object item)
        {
            try { return new Guid(item.ToString()); }
            catch { return Guid.Empty; }
        }

        /// <summary>
        /// Concatenates SQL and ORDER BY clauses into a single string. 
        /// </summary>
        /// <param name="sql">The SQL string</param>
        /// <param name="sortExpression">The Sort Expression.</param>
        /// <returns>Contatenated SQL Statement.</returns>
        public static string OrderBy(this string sql, string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return sql;

            return sql + " ORDER BY " + sortExpression;
        }
    }
}
