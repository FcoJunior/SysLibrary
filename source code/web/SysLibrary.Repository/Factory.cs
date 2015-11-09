using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Repository
{
    public class Factory
    {
        public static IRepository GetInstance()
        {
            return new RepositoryEF();
        }
    }
}
