using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SysLibrary.Entidades.DTO;
using SysLibrary.Business;

namespace SysLibrary.WebApi.Controllers
{
    public class ObraController : ApiController
    {
        // GET: api/Obra
        [Route("api/Obra")]
        public HttpResponseMessage Get()
        {
            ObraBusiness obraBusiness = new ObraBusiness();
            AutorBusiness autorBusiness = new AutorBusiness();
            EditoraBusiness editoraBusiness = new EditoraBusiness();
            GeneroBusiness generoBusiness = new GeneroBusiness();

            var vm = new {
                Obras = obraBusiness.GetObra(),
                Autores = autorBusiness.GetAutor(),
                Editoras = editoraBusiness.GetEditora(),
                Generos = generoBusiness.GetGenero()
            };

            return Request.CreateResponse(HttpStatusCode.OK, vm);
        }

        // GET: api/Obra/5
        [Route("api/Obra/{id}")]
        public HttpResponseMessage Get(int id)
        {
            ObraBusiness obraBusiness = new ObraBusiness();

            ObraDTO entity = obraBusiness.GetObraById(id);
            EditoraBusiness editoraBusiness = new EditoraBusiness();
            AutorBusiness autorBusiness = new AutorBusiness();
            GeneroBusiness generoBusiness = new GeneroBusiness();

            entity.Autor = autorBusiness.GetAutorById(entity.AutorId);
            entity.Editora = editoraBusiness.GetEditoraById(entity.EditoraId);
            entity.Genero = generoBusiness.GetGeneroById(entity.GeneroId);

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        // POST: api/Obra
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Obra/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Obra/5
        public void Delete(int id)
        {
        }
    }
}
