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
    public class EditoraController : Controller
    {

        // GET: /Editora/
        public ActionResult Index()
        {
            var model = new EditoraViewModel
            {
                Editoras = EditoraBO.GetAllActive<Editora>().OrderBy(x => x.Nome).ToList()
            };

            return View(model);
        }


        // POST: /Editora/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditoraViewModel model)
        {
            EditoraBO.Save<Editora>(model.Editora);
            return RedirectToAction("Index");
         }

        // GET: /Editora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var editora = EditoraBO.Find<Editora>(id);
            if (editora == null)
            {
                return HttpNotFound();
            }
            return View("Index", new EditoraViewModel
            {
                Editora = editora,
                Editoras = EditoraBO.GetAllActive<Editora>().OrderBy(x => x.Nome).ToList()
            });
        }

        // GET: /Editora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var editora = EditoraBO.Find<Editora>(id);
            if (editora == null)
            {
                return HttpNotFound();
            }
            return View(new EditoraViewModel
            {
                Editora = editora
            });
        }

        // POST: /Editora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EditoraBO.Remove<Editora>(id);
            return RedirectToAction("Index");
        }

    }
}
