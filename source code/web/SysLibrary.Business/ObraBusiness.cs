using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Data.DAL;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Business
{
    public class ObraBusiness
    {
        public List<ObraDTO> GetObra()
        {
            ObraDao dao = new ObraDao();
            return dao.Get();
        }

        public List<ObraDTO> GetObra(int? pageNumber, int? numberObjectsPerPage)
        {
            ObraDao dao = new ObraDao();
            return dao.Get((int)pageNumber, (int)numberObjectsPerPage);
        }

        public ObraDTO GetObraById(int id)
        {
            ObraDao dao = new ObraDao();
            return dao.Get(id);
        }

        public void Create(ObraDTO obj)
        {
            ObraDao dao = new ObraDao();
            dao.Insert(obj);
            dao.Save();
        }

        public void Update(ObraDTO obj)
        {
            ObraDao dao = new ObraDao();
            dao.Update(obj);
            dao.Save();
        }

        public int GetObraCount()
        {
            ObraDao dao = new ObraDao();
            return dao.Count();
        }
    }
}
