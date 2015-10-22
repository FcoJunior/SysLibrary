using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados.DAO
{
    public class RenovacaoDao : Dao, IDao<RenovacaoDTO>
    {
        public void Insert(RenovacaoDTO obj)
        {
            RenovacaoEntity entity = Parse(obj);
            Context.Renovacao.Add(entity);
        }

        public void Update(RenovacaoDTO obj)
        {
            RenovacaoEntity entity = Parse(obj);
            Context.Entry<RenovacaoEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(RenovacaoDTO obj)
        {
            RenovacaoEntity entity = Parse(obj);
            Context.Renovacao.Remove(entity);
        }

        public List<RenovacaoDTO> Get()
        {
            var query = (from e in Context.Renovacao
                         select new RenovacaoDTO()
                         {
                             Id = e.Id,
                             EmprestimoId = e.EmprestimoId,
                             DataRenovacao = e.DataRenovacao,
                             DataPrevistaDevolucao = e.DataPrevistaDevolucao
                         }).ToList();

            return query;
        }

        public RenovacaoDTO Get(int id)
        {
            var query = (from e in Context.Renovacao
                         where e.Id.Equals(id)
                         select new RenovacaoDTO()
                         {
                             Id = e.Id,
                             EmprestimoId = e.EmprestimoId,
                             DataRenovacao = e.DataRenovacao,
                             DataPrevistaDevolucao = e.DataPrevistaDevolucao
                         }).Single();

            return query;

        }

        public int Count()
        {
            return Context.Renovacao.Count();
        }

        private RenovacaoEntity Parse(RenovacaoDTO obj)
        {
            RenovacaoEntity entity = new RenovacaoEntity()
            {
                Id = obj.Id,
                EmprestimoId = obj.EmprestimoId,
                DataRenovacao = obj.DataRenovacao,
                DataPrevistaDevolucao = obj.DataPrevistaDevolucao

            };

            return entity;
        }
     
    }
}
