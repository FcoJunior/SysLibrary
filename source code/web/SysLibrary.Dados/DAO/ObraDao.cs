using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados.DAO
{
    public class ObraDao : Dao, IDao<ObraDTO>
    {
        public void Insert(ObraDTO obj)
        {
            ObraEntity entity = Parse(obj);
            Context.Obra.Add(entity);
        }

        public void Update(ObraDTO obj)
        {
            ObraEntity entity = Parse(obj);
            Context.Entry<ObraEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(ObraDTO obj)
        {
            ObraEntity entity = Parse(obj);
            Context.Obra.Remove(entity);
        }

        public List<ObraDTO> Get()
        {
            var query = (from e in Context.Obra
                         select new ObraDTO()
                         {
                             Id = e.Id,
                             GeneroId = e.GeneroId,
                             EditoraId = e.EditoraId,
                             Nome = e.Nome,
                             Autor = e.Autor,
                             DataCadastro = e.DataCadastro
                         }).ToList();

            return query;
        }

        public ObraDTO Get(int id)
        {
            var query = (from e in Context.Obra
                         where e.Id.Equals(id)
                         select new ObraDTO()
                         {
                             Id = e.Id,
                             GeneroId = e.GeneroId,
                             EditoraId = e.EditoraId,
                             Nome = e.Nome,
                             Autor = e.Autor,
                             DataCadastro = e.DataCadastro
                         }).Single();

            return query;

        }

        public int Count()
        {
            return Context.Obra.Count();
        }

        private ObraEntity Parse(ObraDTO obj)
        {
            ObraEntity entity = new ObraEntity()
            {
                Id = obj.Id,
                GeneroId = obj.GeneroId,
                EditoraId = obj.EditoraId,
                Nome = obj.Nome,
                Autor = obj.Autor,
                DataCadastro = obj.DataCadastro

            };

            return entity;
        }
     
    }
}
