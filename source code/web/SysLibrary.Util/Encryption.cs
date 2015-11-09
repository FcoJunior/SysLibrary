using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;
using SysLibrary.Entities;

namespace SysLibrary.Util
{
    public static class Encryption
    {
        public static string Base64Encode(EncryptionObject obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            var buffer = Encoding.UTF8.GetBytes(json);
            return Convert.ToBase64String(buffer);
        }

        public static EncryptionObject Base64Decode(string text)
        {
            var buffer = Convert.FromBase64String(text);
            string json = Encoding.UTF8.GetString(buffer);
            return JsonConvert.DeserializeObject<EncryptionObject>(json);
        }

        public static string CreateToken(Usuario usuario)
        {

            string input = usuario.Id.ToString() + usuario.Email + DateTime.Now.ToString();

            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x5"));
            }

            return sBuilder.ToString();
        }
    }
}
