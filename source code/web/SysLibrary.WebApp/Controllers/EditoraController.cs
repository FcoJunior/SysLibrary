using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysLibrary.Business;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.WebApp.Controllers
{
    public class EditoraController : Controller
    {
        // GET: Editora
        public ActionResult Index()
        {
            EditoraBusiness business = new EditoraBusiness();
            return View(business.GetEditora());
        }

        // POST: Editora/Create
        [HttpPost]
        public ActionResult Create(EditoraDTO obj)
        {
            try
            {
                EditoraBusiness business = new EditoraBusiness();
                business.Create(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Editora/Edit/5
        public ActionResult Edit(int id)
        {
            EditoraBusiness business = new EditoraBusiness();
            return View(business.GetEditoraById(id));
        }

        // POST: Editora/Edit/5
        [HttpPost]
        public ActionResult Edit(EditoraDTO obj)
        {
            try
            {
                EditoraBusiness business = new EditoraBusiness();
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
