using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Entidades.DTO;
using SysLibrary.Dados;

namespace SysLibrary.Negocio
{
    public class ExemplarBusiness
    {
        public ExemplarDTO GetExemplarById(int id)
        {
            ExemplarDao dao = new ExemplarDao();
            return dao.Get(id);
        }

        public List<ExemplarDTO> GetExemplarDisponivel()
        {
            ExemplarDao dao = new ExemplarDao();
            return dao.GetDisponivel();
        }
    }
}
