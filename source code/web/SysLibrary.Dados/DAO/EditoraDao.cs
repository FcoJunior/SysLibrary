using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados.DAO
{
    public class EditoraDao : Dao, IDao<EditoraDTO>
    {
        public void Insert(EditoraDTO obj)
        {
            EditoraEntity entity = Parse(obj);
            Context.Editora.Add(entity);
        }

        public void Update(EditoraDTO obj)
        {
            EditoraEntity entity = Parse(obj);
            Context.Entry<EditoraEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(EditoraDTO obj)
        {
            EditoraEntity entity = Parse(obj);
            Context.Editora.Remove(entity);
        }

        public List<EditoraDTO> Get()
        {
            var query = (from e in Context.Editora
                         select new EditoraDTO()
                         {
                             Id = e.Id,
                             Nome = e.Nome
                         }).ToList();

            return query;
        }

        public EditoraDTO Get(int id)
        {
            var query = (from e in Context.Editora
                         where e.Id.Equals(id)
                         select new EditoraDTO()
                         {
                             Id = e.Id,
                             Nome = e.Nome
                         }).Single();

            return query;

        }

        public int Count()
        {
            return Context.Editora.Count();
        }

        private EditoraEntity Parse(EditoraDTO obj)
        {
            EditoraEntity entity = new EditoraEntity()
            {
                Id = obj.Id,
                Nome = obj.Nome

            };

            return entity;
        }
    }
}
