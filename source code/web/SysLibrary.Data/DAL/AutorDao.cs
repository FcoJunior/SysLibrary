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
            var query = (from e in Context.Autor
                             where e.Id.Equals(id)
                             select new AutorDTO(){
                                 Id = e.Id,
                                 Nome = e.Nome
                             }).Single();
            return query;
        }

        public List<AutorDTO> Get()
        {
            var query = (from e in Context.Autor
                         select new AutorDTO()
                         {
                             Id = e.Id,
                             Nome = e.Nome
                         }).ToList();
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
