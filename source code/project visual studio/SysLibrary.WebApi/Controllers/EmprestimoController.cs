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
    public class EmprestimoController : ApiController
    {
        // GET api/<controller>
        [Route("api/emprestimo/listar")]
        [HttpGet]
        public HttpResponseMessage Listar()
        {
            EmprestimoBusiness eBusiness = new EmprestimoBusiness();
            var lista = eBusiness.GetAll();

            if (lista == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Nenhum empréstimo encontrado!");

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        [Route("api/emprestimo/buscar")]
        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            EmprestimoBusiness eBusiness = new EmprestimoBusiness();
            var bibliotecario = eBusiness.GetById(id);

            if (bibliotecario == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Nenhum empréstimo encontrado!");

            return Request.CreateResponse(HttpStatusCode.OK, bibliotecario);
        }

        [Route("api/emprestimo/salvar")]
        [HttpPost]
        public HttpResponseMessage Salvar([FromBody]EmprestimoDTO entity)
        {
            EmprestimoBusiness eBusiness = new EmprestimoBusiness();
            if (!eBusiness.Save(entity))
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao salvar emprestimo!");

            return Request.CreateResponse(HttpStatusCode.OK, "Salvo com sucesso!");
        }
    }
}