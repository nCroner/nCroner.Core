using System.Collections.Generic;
using System.Linq;

namespace nCroner.Common.Tools
{
    public static class StringExt
    {
        public static IEnumerable<string> Split(this string str, int n)
        {
            if (string.IsNullOrEmpty(str) || n < 1)
            {
                return new List<string>();
            }

            if (str.Length < n)
            {
                return new List<string>()
                {
                    str
                };
            }

            return Enumerable.Range(0, str.Length / n)
                .Select(i => str.Substring(i * n, n));
        }
    }
}