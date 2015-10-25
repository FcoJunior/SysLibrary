using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Data.DAL
{
    public class AutorDao : Dao, IDao<AutorDTO>
    {
        public void Insert(AutorDTO obj)
        {
            Autor entity = Parse(obj);
            Context.Autor.Add(entity);
        }

        public void Update(AutorDTO obj)
        {
            Autor entity = Parse(obj);
            Context.Entry<Autor>(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Context.Autor.Remove(Context.Autor.Find(id));
        }

        public AutorDTO Get(int id)
        {
            var query = Context.Autor
                .Where(c => c.Id.Equals(id))
                .Select(c => new AutorDTO() { Id = c.Id, Nome = c.Nome })
                .Single();
            return query;
        }

        public List<AutorDTO> Get()
        {
            var query = Context.Autor
                .Select(c => new AutorDTO() { Id = c.Id, Nome = c.Nome })
                .ToList();
            return query;
        }

        public int Count()
        {
            return Context.Autor.Count();
        }

        private Autor Parse(AutorDTO entity)
        {
            return new Autor() 
            {
                Id = entity.Id,
                Nome = entity.Nome
            };
        }
    }
}
