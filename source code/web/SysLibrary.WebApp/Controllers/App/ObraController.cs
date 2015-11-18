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
using SysLibrary.Business;
using SysLibrary.WebApp.Models;

namespace SysLibrary.WebApp.Controllers
{
    [Authorize]
    public class ObraController : Controller
    {
        // GET: /Obra/
        public ActionResult Index()
        {
            var obras = ObraBO.GetAllActive<Obra>();

            return View(new ObraViewModel {
                Obras = obras
            });
        }

        // GET: /Obra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obra = ObraBO.Find<Obra>(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(obra);
        }

        // GET: /Obra/Create
        public ActionResult Create()
        {
            return View(new ObraViewModel());
        }

        // POST: /Obra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ObraViewModel model)
        {
            
            model.Obra.DataDeCadastro = DateTime.Today;
            ObraBO.Save<Obra>(model.Obra);

            return RedirectToAction("Index");
     
        }

        // GET: /Obra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obra = ObraBO.Find<Obra>(id);
            if (obra == null)
            {
                return HttpNotFound();
            }

            return View("Create", new ObraViewModel {
                Obra = obra
            });
        }

        // GET: /Obra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obra = ObraBO.Find<Obra>(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(new ObraViewModel {
                Obra = obra
            });
        }

        // POST: /Obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObraBO.Remove<Obra>(id);
            return RedirectToAction("Index");
        }

    }
}
