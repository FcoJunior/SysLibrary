using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados.DAO
{
    public class TipoUsuarioDao : Dao, IDao<TipoUsuarioDTO>
    {
        public void Insert(TipoUsuarioDTO obj)
        {
            TipoUsuarioEntity entity = Parse(obj);
            Context.TipoUsuario.Add(entity);
        }

        public void Update(TipoUsuarioDTO obj)
        {
            TipoUsuarioEntity entity = Parse(obj);
            Context.Entry<TipoUsuarioEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(TipoUsuarioDTO obj)
        {
            TipoUsuarioEntity entity = Parse(obj);
            Context.TipoUsuario.Remove(entity);
        }

        public List<TipoUsuarioDTO> Get()
        {
            var query = (from e in Context.TipoUsuario
                         select new TipoUsuarioDTO()
                         {
                             Id = e.Id,
                             Tipo = e.Tipo
                         }).ToList();

            return query;
        }

        public TipoUsuarioDTO Get(int id)
        {
            var query = (from e in Context.TipoUsuario
                         where e.Id.Equals(id)
                         select new TipoUsuarioDTO()
                         {
                             Id = e.Id,
                             Tipo = e.Tipo
                         }).Single();

            return query;

        }

        public int Count()
        {
            return Context.TipoUsuario.Count();
        }

        private TipoUsuarioEntity Parse(TipoUsuarioDTO obj)
        {
            TipoUsuarioEntity entity = new TipoUsuarioEntity()
            {
                Id = obj.Id,
                Tipo = obj.Tipo

            };

            return entity;
        }
     
    }
}
