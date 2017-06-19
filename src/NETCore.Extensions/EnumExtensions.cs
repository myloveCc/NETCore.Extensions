using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NETCore.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// get enum display name
        /// </summary>
        /// <param name="input">enum obj</param>
        /// <returns></returns>
        public static string DisplayName(this Enum input)
        {
            return Enum.GetName(input.GetType(), input);
        }

        /// <summary>
        /// get enum attribute collection。
        /// </summary>
        /// <param name="input">enum obj</param>
        /// <returns>attribute collection</returns>
        public static IEnumerable<Attribute> GetCustomeAttributes(this Enum input)
        {
            return input.GetType().GetField(input.DisplayName()).GetCustomAttributes(true).OfType<Attribute>();
        }

        /// <summary>
        /// get enum specific attribute collection
        /// </summary>
        /// <param name="input">enum obj</param>
        /// <param name="attributeType">specific attribute</param>
        /// <returns>specific attribute collection</returns>
        public static IEnumerable<Attribute> GetCustomeAttributes(this Enum input, Type attributeType)
        {
            return input.GetType().GetField(input.DisplayName()).GetCustomAttributes(attributeType, true).OfType<Attribute>();
        }

        /// <summary>
        ///  get enum specific attribute collection with T:
        /// </summary>
        /// <typeparam name="T">specific attribute。</typeparam>
        /// <param name="input">enu</param>
        /// <returns>该枚举值字段所定义的所有指定类型的自定义特性的数组。</returns>
        public static IEnumerable<T> GetCustomeAttributes<T>(this Enum input) where T : Attribute
        {
            return input.GetType().GetField(input.DisplayName()).GetCustomAttributes<T>(true);
        }
    }
}
