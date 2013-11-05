using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Una.PA.Helpers
{
    public static class UTF8
    {
        public static string ToUTF8(this string textoPlano, Encoding encoding)
        {
            byte[] toEncodeAsBytes = encoding.GetBytes(textoPlano);
            string returnValue = Encoding.UTF8.GetString(toEncodeAsBytes).Trim();

            return returnValue;
        }
    }
}
