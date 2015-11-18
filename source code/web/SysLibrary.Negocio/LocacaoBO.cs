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
        public static ICollection<Locacao> GetLocacaoByUsuario(int? id)
        {
            var repositorio = SysLibrary.Repository.Factory.GetInstance();
            return repositorio.GetAll<Locacao>().Where(c => c.Ativo && c.UsuarioId == id && c.DataDeDevolucao == null).ToList();
        }

        public static void Devolver(int id)
        {
            var repositorio = SysLibrary.Repository.Factory.GetInstance();
            var locacao = repositorio.GetById<Locacao>(id);

            locacao.DataDeDevolucao = DateTime.Today;
            repositorio.Save<Locacao>(locacao);
        }

        public static void Devolver(List<int> lista)
        {
            using(var repositorio = SysLibrary.Repository.Factory.GetInstance())
            {
                foreach (var id in lista)
                {
                    var locacao = repositorio.GetById<Locacao>(id);
                    locacao.DataDeDevolucao = DateTime.Today;
                    repositorio.Save<Locacao>(locacao);
                    repositorio.Commit();
                }
            }
        }
    }
}
