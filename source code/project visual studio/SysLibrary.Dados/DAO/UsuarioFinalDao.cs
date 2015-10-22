using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados.DAO
{
    public class UsuarioFinalDao : Dao, IDao<UsuarioFinalDTO>
    {
        public void Insert(UsuarioFinalDTO obj)
        {
            UsuarioFinalEntity entity = Parse(obj);
            Context.UsuarioFinal.Add(entity);
        }

        public void Update(UsuarioFinalDTO obj)
        {
            UsuarioFinalEntity entity = Parse(obj);
            Context.Entry<UsuarioFinalEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(UsuarioFinalDTO obj)
        {
            UsuarioFinalEntity entity = Parse(obj);
            Context.UsuarioFinal.Remove(entity);
        }

        public List<UsuarioFinalDTO> Get()
        {
            var query = (from e in Context.UsuarioFinal
                         select new UsuarioFinalDTO()
                         {
                             Id = e.Id,
                             UsuarioId = e.UsuarioId,
                             Matricula = e.Matricula,
                             Nome = e.Nome,
                             Pendencia = e.Pendencia
                         }).ToList();

            return query;
        }

        public UsuarioFinalDTO Get(int id)
        {
            var query = (from e in Context.UsuarioFinal
                         where e.Id.Equals(id)
                         select new UsuarioFinalDTO()
                         {
                             Id = e.Id,
                             UsuarioId = e.UsuarioId,
                             Matricula = e.Matricula,
                             Nome = e.Nome,
                             Pendencia = e.Pendencia
                         }).Single();

            return query;

        }

        public int Count()
        {
            return Context.UsuarioFinal.Count();
        }

        private UsuarioFinalEntity Parse(UsuarioFinalDTO obj)
        {
            UsuarioFinalEntity entity = new UsuarioFinalEntity()
            {
                Id = obj.Id,
                UsuarioId = obj.UsuarioId,
                Matricula = obj.Matricula,
                Nome = obj.Nome,
                Pendencia = obj.Pendencia

            };

            return entity;
        }
     
    }
}
