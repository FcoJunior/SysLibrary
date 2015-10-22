using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados
{
    public class ExemplarDao : Dao, IDao<ExemplarDTO>
    {
        private ExemplarEntity Parse(ExemplarDTO obj)
        {
            ExemplarEntity entity = new ExemplarEntity()
            {
                Id = obj.Id,
                DataCadastro = obj.DataCadastro,
                ObraId = obj.ObraId,
                Patrimonio = obj.Patrimonio,
                Status = obj.Status
            };

            return entity;
        }
        
        public void Insert(ExemplarDTO obj)
        {
            ExemplarEntity entity = Parse(obj);
            Context.Exemplar.Add(entity);
        }

        public void Update(ExemplarDTO obj)
        {
            ExemplarEntity entity = Parse(obj);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(ExemplarDTO obj)
        {
            ExemplarEntity entity = Parse(obj);
            Context.Exemplar.Remove(entity);
        }

        public List<ExemplarDTO> Get()
        {
            var query = (from e in Context.Exemplar 
                         select new ExemplarDTO() 
                         { 
                             Id = e.Id, 
                             Patrimonio = e.Patrimonio, 
                             ObraId = e.ObraId, 
                             Status = e.Status, 
                             DataCadastro = e.DataCadastro 
                         }).ToList();

            return query;
        }

        public ExemplarDTO Get(int id)
        {
            var query = (from e in Context.Exemplar 
                         where e.Id.Equals(id)
                         select new ExemplarDTO()
                         {
                             Id = e.Id,
                             Patrimonio = e.Patrimonio,
                             ObraId = e.ObraId,
                             Status = e.Status,
                             DataCadastro = e.DataCadastro
                         }).Single();

            return query;
        }

        public int Count()
        {
            return Context.Exemplar.Count();
        }

        public List<ExemplarDTO> GetDisponivel()
        {
            var query = (from e in Context.Exemplar
                         where e.Status
                         select new ExemplarDTO()
                         {
                             Id = e.Id,
                             Patrimonio = e.Patrimonio,
                             ObraId = e.ObraId,
                             DataCadastro = e.DataCadastro
                         }).ToList();

            return query;
        }
        
    }
}
