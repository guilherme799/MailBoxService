using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Una.PA.Helpers
{
    public static class Base64
    {
        public static string EncodeBase64(this string textoPlano, Encoding encoding)
        {
            byte[] toEncodeAsBytes = encoding.GetBytes(textoPlano);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;
        }

        public static string DecodeBase64(this string textoCriptografado, Encoding encoding)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(textoCriptografado);
            string returnValue = encoding.GetString(encodedDataAsBytes).Trim();

            return returnValue;
        }
    }
}
