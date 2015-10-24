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
        protected SYSLIBRARY_DBEntities Context = new SYSLIBRARY_DBEntities();

        /// <summary>
        /// Save modifications
        /// </summary>
        public void Save()
        {
            Context.SaveChanges();
        }

    }
}
