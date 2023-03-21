using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.OpenLibrary
{
    public static class StringExtensions
    {
        public static string ToQueryStringSpaces(this string query)
        {
            return query.Replace(" ", "+").Replace("%20", "+");
        }
    }
}
