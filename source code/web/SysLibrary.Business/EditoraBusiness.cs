using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Data.DAL;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Business
{
    public class EditoraBusiness
    {
        public List<EditoraDTO> GetEditora()
        {
            EditoraDao dao = new EditoraDao();
            return dao.Get();
        }

        public EditoraDTO GetEditoraById(int id)
        {
            EditoraDao dao = new EditoraDao();
            return dao.Get(id);
        }

        public void Create(EditoraDTO obj)
        {
            EditoraDao dao = new EditoraDao();
            dao.Insert(obj);
            dao.Save();
        }

        public void Update(EditoraDTO obj)
        {
            EditoraDao dao = new EditoraDao();
            dao.Update(obj);
            dao.Save();
        }

        public int GetEditoraCount()
        {
            EditoraDao dao = new EditoraDao();
            return dao.Count();
        }
    }
}
