using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados
{
    public class LocacaoDao : Dao, IDao<LocacaoDTO>
    {
        public void Insert(LocacaoDTO obj)
        {
            LocacaoEntity entity = Parse(obj);
            Context.Locacao.Add(entity);
        }

        public void Update(LocacaoDTO obj)
        {
            LocacaoEntity entity = Parse(obj);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(LocacaoDTO obj)
        {
            LocacaoEntity entity = Parse(obj);
            Context.Locacao.Remove(entity);
        }

        public List<LocacaoDTO> Get()
        {
            var query = (from e in Context.Locacao
                         select new LocacaoDTO()
                         {
                             Id = e.Id,
                             UsuarioFinalId = e.UsuarioFinalId,
                             BibliotecarioId = e.BibliotecarioId,
                             DataLocacao = e.DataLocacao
                         }).ToList();

            return query;
        }

        public LocacaoDTO Get(int id)
        {
            var query = (from e in Context.Locacao
                         where e.Id.Equals(id)
                         select new LocacaoDTO() {
                            Id = e.Id,
                            UsuarioFinalId = e.UsuarioFinalId,
                            BibliotecarioId = e.BibliotecarioId,
                            DataLocacao = e.DataLocacao
                         }).Single();
            
            return query;
        }

        public int Count()
        {
            return Context.Locacao.Count();
        }

        private LocacaoEntity Parse(LocacaoDTO obj)
        {
            LocacaoEntity entity = new LocacaoEntity() 
            {
                Id = obj.Id,
                BibliotecarioId = obj.BibliotecarioId,
                UsuarioFinalId = obj.UsuarioFinalId,
                DataLocacao = obj.DataLocacao
            };

            return entity;
        }
    }
}
