using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Data.DAL
{
    public class GeneroDao : Dao, IDao<GeneroDTO>
    {
        public void Insert(GeneroDTO obj)
        {
            Genero entity = Parse(obj);
            Context.Genero.Add(entity);
        }

        public void Update(GeneroDTO obj)
        {
            Genero entity = Parse(obj);
            Context.Entry<Genero>(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Context.Genero.Remove(Context.Genero.Find(id));
        }

        public GeneroDTO Get(int id)
        {
            var query = Context.Genero
                .Where(c => c.Id.Equals(id))
                .Select(c => new GeneroDTO() { Id = c.Id, Nome = c.Nome })
                .Single();
            return query;
        }

        public List<GeneroDTO> Get()
        {
            var query = Context.Genero
                .Select(c => new GeneroDTO() { Id = c.Id, Nome = c.Nome })
                .ToList();
            return query;
        }

        public int Count()
        {
            return Context.Genero.Count();
        }

        private Genero Parse(GeneroDTO obj)
        {
            Genero entity = new Genero() 
            {
                Id = obj.Id,
                Nome = obj.Nome
            };
            return entity;
        }
    }
}
