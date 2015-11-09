using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Util
{
    public static class Extensions
    {
        public static string Encript(this string text)
        {
            return ConvertToHashSHA1(text);
        }

        private static string ConvertToHashSHA1(string text)
        {
            var hasher = SHA1.Create();
            var encoder = new ASCIIEncoding();

            var bytes = encoder.GetBytes(text);
            hasher.ComputeHash(bytes);

            return Convert.ToBase64String(hasher.Hash);
        }
    }
}
