using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Data.DAL;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Business
{
    public class GeneroBusiness
    {
        public List<GeneroDTO> GetGenero()
        {
            GeneroDao dao = new GeneroDao();
            return dao.Get();
        }

        public GeneroDTO GetGeneroById(int id)
        {
            GeneroDao dao = new GeneroDao();
            return dao.Get(id);
        }
    }
}
