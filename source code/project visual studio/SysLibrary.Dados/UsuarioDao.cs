using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados
{
    public class UsuarioDao : Dao, IDao<UsuarioDTO>
    {
        public void Insert(UsuarioDTO obj)
        {
            UsuarioEntity entity = Parse(obj);
            Context.Usuario.Add(entity);
        }

        public void Update(UsuarioDTO obj)
        {
            UsuarioEntity entity = Parse(obj);
            Context.Entry<UsuarioEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(UsuarioDTO obj)
        {
            UsuarioEntity entity = Parse(obj);
            Context.Usuario.Remove(entity);
        }

        public List<UsuarioDTO> Get()
        {
            var query = (from e in Context.Usuario
                         select new UsuarioDTO()
                         {
                             Id = e.Id,
                             Email = e.Email,
                             Senha = e.Senha,
                             Status = e.Status,
                             TipoUsuarioId = e.TipoUsuarioId,
                             Token = e.Token
                         }).ToList();

            return query;
        }

        public UsuarioDTO Get(int id)
        {
            var query = (from e in Context.Usuario 
                         where e.Id.Equals(id) 
                         select new UsuarioDTO() 
                         {
                             Id = e.Id,
                             Email = e.Email,
                             Senha = e.Senha,
                             Status = e.Status,
                             TipoUsuarioId = e.TipoUsuarioId,
                             Token = e.Token
                         }).Single();

            return query;
        }

        public int Count()
        {
            return Context.Usuario.Count();
        }

        private UsuarioEntity Parse(UsuarioDTO obj)
        {
            UsuarioEntity entity = new UsuarioEntity() 
            {
                Id = obj.Id,
                Email = obj.Email,
                Senha = obj.Senha,
                Status = obj.Status,
                TipoUsuarioId = obj.TipoUsuarioId,
                Token = obj.Token
            };

            return entity;
        }

        public int Login(string email, string senha)
        {
            var query = (from e in Context.Usuario
                         where e.Email.Equals(email) &&
                         e.Senha.Equals(senha) &&
                         e.Status
                         select new UsuarioDTO() 
                         {
                             Id = e.Id,
                             Status = e.Status,
                             Email = e.Email,
                             Senha = e.Senha,
                             TipoUsuarioId = e.TipoUsuarioId
                         }).ToList();

            return query.Count();
        }

        public UsuarioDTO GetByEmail(string email)
        {
            var query = (from e in Context.Usuario
                         where e.Email.Equals(email)
                         select new UsuarioDTO() 
                         {
                             Id = e.Id,
                             Email = e.Email,
                             Senha = e.Senha,
                             Status = e.Status,
                             TipoUsuarioId = e.TipoUsuarioId,
                             Token = e.Token
                         });

            return query.FirstOrDefault();
        }



        public void SetToken(UsuarioDTO entity)
        {
            Context.Usuario.Find(entity.Id).Token = entity.Token;
        }
    }
}
