using SysLibrary.Entidades.DTO;
using SysLibrary.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SysLibrary.WebApi.Controllers
{
    public class BibliotecarioController : ApiController
    {
        // GET api/<controller>
        [Route("api/bibliotecario/listar")]
        [HttpGet]
        public HttpResponseMessage Listar()
        {
            BibliotecarioBusiness bBusiness = new BibliotecarioBusiness();
            var lista = bBusiness.GetAll();

            if(lista == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Nenhum bibliotecario encontrado!");

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        [Route("api/bibliotecario/buscar")]
        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            BibliotecarioBusiness bBusiness = new BibliotecarioBusiness();
            var bibliotecario = bBusiness.GetById(id);

            if (bibliotecario == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Nenhum bibliotecario encontrado!");

            return Request.CreateResponse(HttpStatusCode.OK, bibliotecario);
        }

        [Route("api/bibliotecario/salvar")]
        [HttpPost]
        public HttpResponseMessage Salvar([FromBody]BibliotecarioDTO entity)
        {
            BibliotecarioBusiness bBusiness = new BibliotecarioBusiness();
            if(!bBusiness.Save(entity))
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao salvar bibliotecario!");

            return Request.CreateResponse(HttpStatusCode.OK, "Salvo com sucesso!");
        }
    }
}