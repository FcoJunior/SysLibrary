using SysLibrary.Business.Base;
using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Business
{
    public class LocacaoBO : BaseBO
    {
        public ICollection<Locacao> GetLocacaoByUsuario(int? id)
        {
            var repositorio = SysLibrary.Repository.Factory.GetInstance();
            return repositorio.GetAll<Locacao>().Where(c => c.Ativo && c.UsuarioId == id).ToList();
        }
    }
}
