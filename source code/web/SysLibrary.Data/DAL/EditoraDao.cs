using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Data.DAL
{
    public class EditoraDao : Dao, IDao<EditoraDTO>
    {
        public void Insert(EditoraDTO obj)
        {
            Editora entity = Parse(obj);
            Context.Editora.Add(entity);
        }

        public void Update(EditoraDTO obj)
        {
            Editora entity = Parse(obj);
            Context.Entry<Editora>(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Context.Editora.Remove(Context.Editora.Find(id));
        }

        public EditoraDTO Get(int id)
        {
            var query = Context.Editora
                .Where(c => c.Id.Equals(id))
                .Select(c => new EditoraDTO() { Id = c.Id, Nome = c.Nome })
                .Single();
            return query;
        }

        public List<EditoraDTO> Get()
        {
            var query = Context.Editora
                .Select(c => new EditoraDTO() { Id = c.Id, Nome = c.Nome })
                .ToList();
            return query;
        }

        public int Count()
        {
            return Context.Editora.Count();
        }

        private Editora Parse(EditoraDTO obj)
        {
            Editora entity = new Editora() 
            {
                Id = obj.Id,
                Nome = obj.Nome
            };

            return entity;
        }
    }
}
