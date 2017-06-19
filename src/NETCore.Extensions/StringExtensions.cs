using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NETCore.Extensions
{
    public static class StringExtensions
    {
        #region Regex
        private static readonly Regex WebUrlExpression = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex EmailExpression = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$", RegexOptions.Singleline | RegexOptions.Compiled);
        #endregion


        #region basic

        /// <summary>
        /// 判断指定的字符串值是否为 Null 或者 System.String.Empty 空字符串值。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        /// <summary>
        /// 判断指定的字符串值是否为 Null 、 System.String.Empty 空字符串值或者仅由空格组成。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmptyOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        #endregion

        #region Bytes

        /// <summary>
        /// string to bytes[]
        /// </summary>
        /// <param name="input">string</param>
        /// <returns></returns>
        public static byte[] ToBytes(this string input)
        {
            return ToBytes(input, Encoding.UTF8);
        }

        /// <summary>
        /// string to bytes[] withd encoding
        /// </summary>
        /// <param name="input">string</param>
        /// <param name="encoding"><see cref="Encoding"/></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string input, Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding not be null");
            }
            return encoding.GetBytes(input);
        }

        #endregion

        #region Int

        /// <summary>
        /// string to int
        /// </summary>
        /// <param name="input">string value</param>
        /// <returns></returns>
        public static int ToInt(this string input)
        {
            return ToInt(input, 0);
        }

        /// <summary>
        /// string to int 
        /// </summary>
        /// <param name="input">string value</param>
        /// <param name="defaultValue">default int value</param>
        /// <returns></returns>
        public static int ToInt(this string input, int defaultValue)
        {
            int ret = 0;
            return int.TryParse(input, out ret) ? ret : defaultValue;
        }

        #endregion

        #region GUID

        /// <summary>
        /// string parse to guid
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns></returns>
        public static Guid ToGuid(this string input)
        {
            return Guid.Parse(input);
        }

        /// <summary>
        /// string parse to guid
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="format">“N”、“D”、“B”、“P”或“X”</param>
        /// <returns></returns>
        public static Guid ToGuid(this string input, string format)
        {
            return Guid.ParseExact(input, format);
        }

        /// <summary>
        /// try parse string to guid
        /// </summary>
        /// <param name="input">input string </param>
        /// <param name="result">guid result</param>
        /// <returns></returns>
        public static bool TryToGuid(this string input, out Guid result)
        {
            return Guid.TryParse(input, out result);
        }

        #endregion

        #region DateTime

        /// <summary>
        /// string parse to datetime
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns></returns>

        public static DateTime ToDateTime(this string input)
        {
            return DateTime.Parse(input);
        }

        /// <summary>
        /// string try parse to datetime
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="result">result datetime</param>
        /// <returns></returns>
        public static bool TryToDateTime(this string input, out DateTime result)
        {
            return DateTime.TryParse(input, out result);
        }

        #endregion

        #region Format

        /// <summary>
        /// format input string with args
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="args">args</param>
        /// <returns></returns>
        public static string Format(this string input, params object[] args)
        {
            return string.Format(input, args);
        }
        #endregion

        #region Regex

        /// <summary>
        /// Regex macth
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="regexRule">regex rule</param>
        /// <returns>is match return true ,else false</returns>
        public static bool IsMatch(this string input, string regexRule)
        {
            return Regex.IsMatch(input, regexRule);
        }

        /// <summary>
        /// Regex macth
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="pattern">regex rule</param>
        /// <param name="regexOptions"><see cref="RegexOptions"/></param>
        /// <returns>is match return true ,else false</returns>
        public static bool IsMatch(this string input, string regexRule, RegexOptions regexOptions)
        {
            return Regex.IsMatch(input, regexRule, regexOptions);
        }

        /// <summary>
        /// Regex macth
        /// </summary>
        /// <param name="input">input string<</param>
        /// <param name="regexRule">regex rule</param>
        /// <param name="regexOptions"><see cref="RegexOptions"/></param>
        /// <param name="timeOut"><see cref="TimeSpan"/><see cref="Regex.InfiniteMatchTimeout"/></param>
        /// <returns>is match return true ,else false</returns>
        public static bool IsMatch(this string input, string regexRule, RegexOptions regexOptions, TimeSpan timeOut)
        {
            return Regex.IsMatch(input, regexRule, regexOptions, timeOut);
        }

        /// <summary>
        /// check phone
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns></returns>
        public static bool IsMobilePhone(this string input)
        {
            return input.IsMatch(@"^(13|14|15|17|18)\d{9}$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// check web url
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns></returns>
        public static bool IsWebUrl(this string input)
        {
            return !string.IsNullOrEmpty(input) && WebUrlExpression.IsMatch(input);
        }

        /// <summary>
        /// check email
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns></returns>
        public static bool IsEmail(this string input)
        {
            return !string.IsNullOrEmpty(input) && EmailExpression.IsMatch(input);
        }
        #endregion
    }
}
