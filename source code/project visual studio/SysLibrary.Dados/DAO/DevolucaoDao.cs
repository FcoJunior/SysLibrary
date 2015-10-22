using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados.DAO
{
    public class DevolucaoDao : Dao, IDao<DevolucaoDTO>
    {
        public void Insert(DevolucaoDTO obj)
        {
            DevolucaoEntity entity = Parse(obj);
            Context.Devolucao.Add(entity);
        }

        public void Update(DevolucaoDTO obj)
        {
            DevolucaoEntity entity = Parse(obj);
            Context.Entry<DevolucaoEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(DevolucaoDTO obj)
        {
            DevolucaoEntity entity = Parse(obj);
            Context.Devolucao.Remove(entity);
        }

        public List<DevolucaoDTO> Get()
        {
            var query = (from e in Context.Devolucao
                         select new DevolucaoDTO()
                         {
                             Id = e.Id,
                             EmprestimoId = e.EmprestimoId,
                             DataDevolucao = e.DataDevolucao,
                             Multa = e.Multa,
                             Emprestimo = new EmprestimoDTO
                             {
                                  Id = e.Emprestimo.Id
                             }
                         }).ToList();

            return query;
        }

        public DevolucaoDTO Get(int id)
        {
            var query = (from e in Context.Devolucao
                         where e.Id.Equals(id)
                         select new DevolucaoDTO()
                         {
                             Id = e.Id,
                             EmprestimoId = e.EmprestimoId,
                             DataDevolucao = e.DataDevolucao,
                             Multa = e.Multa,
                             Emprestimo = new EmprestimoDTO 
                             {
                                 Id = e.Emprestimo.Id
                             }
                         }).Single();

            return query;

        }

        public int Count()
        {
            return Context.Devolucao.Count();
        }

        private DevolucaoEntity Parse(DevolucaoDTO obj)
        {
            DevolucaoEntity entity = new DevolucaoEntity()
            {
                Id = obj.Id,
                EmprestimoId = obj.EmprestimoId,
                DataDevolucao = obj.DataDevolucao,
                Multa = obj.Multa

            };

            return entity;
        }
     
    }
}
