using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysLibrary.Business;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.WebApp.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Index()
        {
            AutorBusiness business = new AutorBusiness();
            var autores = business.GetAutor();
            return View(autores);
        }

        // POST: Autor/Create
        [HttpPost]
        public ActionResult Create(AutorDTO obj)
        {
            try
            {
                AutorBusiness business = new AutorBusiness();
                business.Create(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest); ;
            }
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            AutorBusiness business = new AutorBusiness();
            return View(business.GetAutorById(id));
        }

        // POST: Autor/Edit/5
        [HttpPost]
        public ActionResult Edit(AutorDTO obj)
        {
            try
            {
                AutorBusiness business = new AutorBusiness();
                business.Update(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
