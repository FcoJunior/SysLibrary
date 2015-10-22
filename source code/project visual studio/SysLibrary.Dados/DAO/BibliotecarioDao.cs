using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados.DAO
{
    public class BibliotecarioDao : Dao, IDao<BibliotecarioDTO>
    {
        public void Insert(BibliotecarioDTO obj)
        {
            BibliotecarioEntity entity = Parse(obj);
            Context.Bibliotecario.Add(entity); 
        }

        public void Update(BibliotecarioDTO obj)
        {
            BibliotecarioEntity entity = Parse(obj);
            Context.Entry<BibliotecarioEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(BibliotecarioDTO obj)
        {
            BibliotecarioEntity entity = Parse(obj);
            Context.Bibliotecario.Remove(entity);
        }

        public List<BibliotecarioDTO> Get()
        {
            var query = (from e in Context.Bibliotecario
                         select new BibliotecarioDTO()
                         {
                             Id = e.Id,
                             UserId = e.UserId,
                             Nome = e.Nome
                         }).ToList();

            return query;
        }

        public BibliotecarioDTO Get(int id)
        {
            var query = (from e in Context.Bibliotecario
                         where e.Id.Equals(id)
                         select new BibliotecarioDTO()
                         {
                              Id = e.Id,
                              UserId = e.UserId,
                              Nome = e.Nome
                         }).Single();

            return query;

        }

        public int Count()
        {
            return Context.Bibliotecario.Count();
        }

        private BibliotecarioEntity Parse(BibliotecarioDTO obj)
        {
            BibliotecarioEntity entity = new BibliotecarioEntity()
            {
                Id = obj.Id,
                UserId = obj.UserId,
                Nome = obj.Nome
          
            };

            return entity;
        }
     
    }
}
