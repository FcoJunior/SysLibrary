using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Dados
{
    public class Dao
    {
        public SYSLIBRARY_DBEntities Context = SysLibraryContext.GetInstance();

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
