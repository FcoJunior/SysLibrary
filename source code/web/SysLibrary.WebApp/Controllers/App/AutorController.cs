using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SysLibrary.Entities;
using SysLibrary.Data;
using SysLibrary.WebApp.Models;
using SysLibrary.Business;

namespace SysLibrary.WebApp.Controllers
{
    [Authorize]
    public class AutorController : Controller
    {
        //GET /Index
        public ActionResult Index()
        {
            var model = new AutorViewModel {
                Autores = AutorBO.GetAllActive<Autor>().OrderBy(x => x.Nome).ToList()
            };

            return View(model);
        }

        //POST /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutorViewModel model)
        {
            AutorBO.Save<Autor>(model.Autor);
            return RedirectToAction("Index");
        }

        //GET /Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var autor = AutorBO.Find<Autor>(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View("Index",new AutorViewModel { 
                Autor = autor,
                Autores = AutorBO.GetAllActive<Autor>().OrderBy(x => x.Nome).ToList()
            });
        }

        //GET /Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var autor = AutorBO.Find<Autor>(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(new AutorViewModel
            {
                Autor = autor
            });
        }

        //POST /Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutorBO.Remove<Autor>(id);
            return RedirectToAction("Index");
        }
    }
}
