using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SysLibrary.Negocio;
using SysLibrary.Entidades.DTO;
using Newtonsoft.Json;
using SysLibrary.Util;

namespace SysLibrary.WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        [Route("api/usuario/login")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody]UsuarioDTO entity)
        {
            if (entity != null)
            {
            try
            {
                UsuarioBusiness userBusiness = new UsuarioBusiness();
                    var login = userBusiness.Login(entity);
                
                    if (!login)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Login Inválido");
                }

                    UsuarioDTO user = userBusiness.Get(entity.Email);

                user.Token = Encryption.CreateToken(entity);
                userBusiness.SetJWT(user);

                EncryptionObject JWT = new EncryptionObject(entity.Id, user.Token);

                return Request.CreateResponse(HttpStatusCode.OK, Encryption.Base64Encode(JWT));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Login Inválido");
        }
    }
}
