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
    public class ExemplarController : Controller
    {

        // GET: /Exemplar/
        public ActionResult Index()
        {
            var model = new ExemplarViewModel
            {
                Exemplares = ExemplarBO.GetAllActive<Exemplar>()
            };

            return View(model);
        }

        public ActionResult ExemplarName(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exemplar = ExemplarBO.Find<Exemplar>(id);
            if (exemplar == null)
            {
                return HttpNotFound();
            }
            return JavaScript(exemplar.Obra.Titulo);
        }

        // GET: /Exemplar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exemplar = ExemplarBO.Find<Exemplar>(id);
            if (exemplar == null)
            {
                return HttpNotFound();
            }
            return View(exemplar);
        }

        // GET: /Exemplar/Create
        public ActionResult Create()
        {
            return View(new ExemplarViewModel());
        }

        // POST: /Exemplar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExemplarViewModel model)
        {
            model.Exemplar.DataDeCadastro = DateTime.Today;
            model.Exemplar.Status = Entities.Enumeradores.StatusExemplar.Disponivel;
            ExemplarBO.Save<Exemplar>(model.Exemplar);

            return RedirectToAction("Index");
        }

        // GET: /Exemplar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exemplar = ExemplarBO.Find<Exemplar>(id);
            if (exemplar == null)
            {
                return HttpNotFound();
            }

            return View("Create", new ExemplarViewModel
            {
                Exemplar = exemplar
            });
        }

        
        // GET: /Exemplar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exemplar = ExemplarBO.Find<Exemplar>(id);
            if (exemplar == null)
            {
                return HttpNotFound();
            }
            return View(new ExemplarViewModel
            {
                Exemplar = exemplar
            });
        }

        // POST: /Exemplar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExemplarBO.Remove<Exemplar>(id);
            return RedirectToAction("Index");
        }

    }
}
