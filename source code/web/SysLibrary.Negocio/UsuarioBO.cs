using SysLibrary.Business.Base;
using SysLibrary.Entities;
using SysLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Util;
using SysLibrary.Repository;

namespace SysLibrary.Business
{
    public class UsuarioBO : BaseBO
    {
        public static Usuario GetUserByCredentials(Usuario usuario)
        {
            var repositorio = Factory.GetInstance();
            usuario.Senha.Encript();

            return repositorio.GetAll<Usuario>(x => x.Ativo && x.Email == usuario.Email && x.Senha == usuario.Senha).FirstOrDefault();
        }
    }
}
