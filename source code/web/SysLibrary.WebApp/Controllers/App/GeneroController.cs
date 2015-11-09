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
    public class GeneroController : Controller
    {

        // GET: /Genero/
        public ActionResult Index()
        {
            var model = new GeneroViewModel
            {
                Generos = GeneroBO.GetAllActive<Genero>().OrderBy(x => x.Nome).ToList()
            };

            return View(model);
        }

        

        // POST: /Genero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GeneroViewModel model)
        {
            GeneroBO.Save<Genero>(model.Genero);
            return RedirectToAction("Index");
        }

        // GET: /Genero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var editora = GeneroBO.Find<Genero>(id);
            if (editora == null)
            {
                return HttpNotFound();
            }
            return View("Index", new GeneroViewModel
            {
                Genero = editora,
                Generos = GeneroBO.GetAllActive<Genero>().OrderBy(x => x.Nome).ToList()
            });
        }


        // GET: /Genero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var genero = GeneroBO.Find<Genero>(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(new GeneroViewModel
            {
                Genero = genero
            });
        }

        // POST: /Genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeneroBO.Remove<Genero>(id);
            return RedirectToAction("Index");
        }

       
    }
}
