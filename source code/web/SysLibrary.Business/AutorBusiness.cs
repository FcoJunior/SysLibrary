using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Data.DAL;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Business
{
    public class AutorBusiness
    {
        public List<AutorDTO> GetAutor()
        {
            AutorDao dao = new AutorDao();
            return dao.Get();
        }

        public AutorDTO GetAutorById(int id)
        {
            AutorDao dao = new AutorDao();
            return dao.Get(id);
        }

        public void Create(AutorDTO obj)
        {
            AutorDao dao = new AutorDao();
            dao.Insert(obj);
            dao.Save();
        }

        public void Update(AutorDTO obj)
        {
            AutorDao dao = new AutorDao();
            dao.Update(obj);
            dao.Save();
        }

        public int GetAutorCount()
        {
            AutorDao dao = new AutorDao();
            return dao.Count();
        }
    }
}
