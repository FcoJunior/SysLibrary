using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Entidades.DTO;
using SysLibrary.Dados;

namespace SysLibrary.Negocio
{
    public class LocacaoBusiness
    {
        public void LocacaoCreate(List<int> exemplar, int usuario, int bibliotecario)
        {
            LocacaoDao dao = new LocacaoDao();
            LocacaoDTO locacao = new LocacaoDTO();


            locacao.BibliotecarioId = bibliotecario;
            locacao.UsuarioFinalId = usuario;
            locacao.DataLocacao = DateTime.Now;

            dao.Insert(locacao);

            foreach (var e in exemplar)
            {
                
            }

            dao.Save();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(LocacaoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
