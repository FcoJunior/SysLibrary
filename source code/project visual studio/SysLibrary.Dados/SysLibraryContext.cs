using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Dados
{
    public static class SysLibraryContext
    {
        private static SYSLIBRARY_DBEntities Context;

        public static SYSLIBRARY_DBEntities GetInstance()
        {
            if (Context == null)
            {
                Context = new SYSLIBRARY_DBEntities();
            }
            return Context;
        }
    }
}
