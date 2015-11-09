using SysLibrary.Business;
using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SysLibrary.WebApp.Controllers
{
    public class WSObraController : ApiController
    {
        // GET: api/Obra
        [Route("api/Obra")]
        public HttpResponseMessage Get()
        {
            var obras = ObraBO.GetAllActive<Obra>();
            var obj = new { Obras = obras };

            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        // GET: api/Obra/5
        [Route("api/Obra/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var obra = ObraBO.Find<Obra>(id);

            if (obra == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var obj = new { Obra = obra };
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}