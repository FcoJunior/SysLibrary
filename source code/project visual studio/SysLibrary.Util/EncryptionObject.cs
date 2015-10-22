using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Util
{
    public class EncryptionObject
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public EncryptionObject(int id, string token)
        {
            this.Id = id;
            this.Token = token;
        }
    }
}
