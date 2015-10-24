using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Data.DAL
{
    public class Dao
    {
        /// <summary>
        /// Use Context for connect to database 
        /// </summary>
        public SYSLIBRARY_DBEntities Context = new SYSLIBRARY_DBEntities();

    }
}
