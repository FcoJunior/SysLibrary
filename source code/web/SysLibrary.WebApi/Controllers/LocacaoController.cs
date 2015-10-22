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
    public class LocacaoController : ApiController
    {
        // GET api/<controller>
        [Route("api/locacao/listar")]
        [HttpGet]
        public HttpResponseMessage Listar()
        {
            LocacaoBusiness lBusiness = new LocacaoBusiness();
            var lista = lBusiness.GetAll();

            if (lista == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Nenhuma locação encontrada!");

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        [Route("api/locacao/buscar")]
        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            LocacaoBusiness lBusiness = new LocacaoBusiness();
            var bibliotecario = lBusiness.GetById(id);

            if (bibliotecario == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Nenhuma locação encontrada!");

            return Request.CreateResponse(HttpStatusCode.OK, bibliotecario);
        }

        [Route("api/locacao/salvar")]
        [HttpPost]
        public HttpResponseMessage Salvar([FromBody]LocacaoDTO entity)
        {
            LocacaoBusiness lBusiness = new LocacaoBusiness();
            if (!lBusiness.Save(entity))
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao salvar locação!");

            return Request.CreateResponse(HttpStatusCode.OK, "Salvo com sucesso!");
        }
    }
}