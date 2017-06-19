using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETCore.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// foreach method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">collction of T</param>
        /// <param name="action"><see cref="Action{T}"/></param>
        public static void ForEach<T>(this ICollection<T> collection, Action<T> action)
        {
            foreach (T item in collection)
                action(item);
        }

        /// <summary>
        /// join collection to string jonin by joinStr
        /// </summary>
        /// <param name="lists">string collection</param>
        /// <param name="joinStr">join str</param>
        /// <returns></returns>
        public static string JoinStr(this ICollection<string> lists, string joinStr)
        {
            if (lists == null || lists.Count() == 0) return null;
            if (lists.Count() == 1) return lists.ElementAt(0) == null ? null : lists.ElementAt(0).ToString();
            if (lists.Count() == 2)
            {
                if (lists.ElementAt(0) == null && lists.ElementAt(1) == null) return null;
                if (lists.ElementAt(0) == null) return lists.ElementAt(1).ToString();
                if (lists.ElementAt(1) == null) return lists.ElementAt(0).ToString();
                return lists.ElementAt(0).ToString() + joinStr + lists.ElementAt(1).ToString();
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in lists)
            {
                if (item == null) continue;
                sb.Append(item.ToString());
                sb.Append(joinStr);
            }
            if (joinStr != null && joinStr.Length > 0)
                sb.Remove(sb.Length - joinStr.Length, joinStr.Length);
            return sb.ToString();
        }
    }
}
