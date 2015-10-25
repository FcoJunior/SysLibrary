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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ObraDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ObraDTO> Get()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
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
