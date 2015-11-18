using SysLibrary.Business;
using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SysLibrary.Util;

namespace SysLibrary.WebApp.Controllers
{
    public class WSUsuarioController : ApiController
    {
        [HttpGet]
        [Route("api/usuario/login")]
        public HttpResponseMessage Login(string Email, string Senha)
        {
            if (Email == null || Senha == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Login Inválido");

            try {

                var usuario = UsuarioBO.GetUserByCredentials(Email, Senha);

                if(usuario == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Login Inválido");

                usuario.Token = Encryption.CreateToken(usuario);

                UsuarioBO.Save<Usuario>(usuario);

                var encriptObj = new EncryptionObject(usuario.Id, usuario.Token);
                var tk = Encryption.Base64Encode(encriptObj);

                return Request.CreateResponse(HttpStatusCode.OK, tk);

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }

        }
    }
}
