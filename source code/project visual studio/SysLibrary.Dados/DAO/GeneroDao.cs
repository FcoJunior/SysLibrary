using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados.DAO
{
    public class GeneroDao : Dao, IDao<GeneroDTO>
    {
        public void Insert(GeneroDTO obj)
        {
            GeneroEntity entity = Parse(obj);
            Context.Genero.Add(entity);
        }

        public void Update(GeneroDTO obj)
        {
            GeneroEntity entity = Parse(obj);
            Context.Entry<GeneroEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(GeneroDTO obj)
        {
            GeneroEntity entity = Parse(obj);
            Context.Genero.Remove(entity);
        }

        public List<GeneroDTO> Get()
        {
            var query = (from e in Context.Genero
                         select new GeneroDTO()
                         {
                             Id = e.Id,
                             Nome = e.Nome
                         }).ToList();

            return query;
        }

        public GeneroDTO Get(int id)
        {
            var query = (from e in Context.Genero
                         where e.Id.Equals(id)
                         select new GeneroDTO()
                         {
                             Id = e.Id,
                             Nome = e.Nome
                         }).Single();

            return query;

        }

        public int Count()
        {
            return Context.Genero.Count();
        }

        private GeneroEntity Parse(GeneroDTO obj)
        {
            GeneroEntity entity = new GeneroEntity()
            {
                Id = obj.Id,
                Nome = obj.Nome

            };

            return entity;
        }
     
    }
}
