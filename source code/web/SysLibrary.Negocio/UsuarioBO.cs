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
        public static Usuario GetUserByCredentials(string Email, string Senha)
        {
            var repositorio = Factory.GetInstance();
            Senha = Senha.Encript();

            return repositorio.GetAll<Usuario>(x => x.Ativo && x.Email == Email && x.Senha == Senha).FirstOrDefault();
        }
    }
}
