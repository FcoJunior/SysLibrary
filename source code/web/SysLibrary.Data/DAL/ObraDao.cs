using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Data.DAL
{
    public class ObraDao : Dao, IDao<ObraDTO>
    {
        public void Insert(ObraDTO obj)
        {
            Obra entity = Parse(obj);
            Context.Obra.Add(entity);
        }

        public void Update(ObraDTO obj)
        {
            Obra entity = Parse(obj);
            Context.Entry<Obra>(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Context.Obra.Remove(Context.Obra.Find(id));
        }

        public ObraDTO Get(int id)
        {
            var query = Context.Obra
                .Where(c => c.Id.Equals(id))
                .Select(c => new ObraDTO() { 
                    Id = c.Id, 
                    Nome = c.Nome, 
                    EditoraId = c.EditoraId, 
                    GeneroId = c.GeneroId, 
                    AutorId = c.AutorId })
                .Single();
            return query;
        }

        public List<ObraDTO> Get()
        {
            var query = Context.Obra
                .Select(c => new ObraDTO()
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    EditoraId = c.EditoraId,
                    GeneroId = c.GeneroId,
                    AutorId = c.AutorId
                })
                .ToList();
            return query;
        }

        public List<ObraDTO> Get(int pageNumber, int numberObjectsPerPage)
        {
            var query = Context.Obra
                .Select(c => new ObraDTO()
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    EditoraId = c.EditoraId,
                    GeneroId = c.GeneroId,
                    AutorId = c.AutorId
                })
                .Skip(numberObjectsPerPage * pageNumber)
                .Take(numberObjectsPerPage)
                .ToList();
            return query;
        }

        public int Count()
        {
            return Context.Obra.Count();
        }

        public Obra Parse(ObraDTO obj)
        {
            Obra entity = new Obra() 
            {
                Id = obj.Id,
                Nome = obj.Nome,
                GeneroId = obj.GeneroId,
                EditoraId = obj.EditoraId,
                AutorId = obj.AutorId,
                DataCadastro = obj.DataCadastro
            };
            return entity;
        }
    }
}
