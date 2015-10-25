using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysLibrary.Business;
using SysLibrary.Entidades.DTO;
using SysLibrary.WebApp.ViewModels;

namespace SysLibrary.WebApp.Controllers
{
    public class ObraController : Controller
    {
        // GET: Obra
        public ActionResult Index()
        {
            ObraBusiness obraBusiness = new ObraBusiness();
            AutorBusiness autorBusiness = new AutorBusiness();
            EditoraBusiness editoraBusiness = new EditoraBusiness();
            GeneroBusiness generoBusiness = new GeneroBusiness();

            ObraViewModel vm = new ObraViewModel() 
            {
                Obras = obraBusiness.GetObra(),
                Autores = autorBusiness.GetAutor(),
                Editoras = editoraBusiness.GetEditora(),
                Generos = generoBusiness.GetGenero()
            };

            return View(vm);
        }

        // GET: Obra/Details/5
        public ActionResult Details(int id)
        {
            ObraBusiness obraBusiness = new ObraBusiness();

            ObraDTO entity = obraBusiness.GetObraById(id);
            EditoraBusiness editoraBusiness = new EditoraBusiness();
            AutorBusiness autorBusiness = new AutorBusiness();
            GeneroBusiness generoBusiness = new GeneroBusiness();

            entity.Autor = autorBusiness.GetAutorById(entity.AutorId);
            entity.Editora = editoraBusiness.GetEditoraById(entity.EditoraId);
            entity.Genero = generoBusiness.GetGeneroById(entity.GeneroId);

            return View(entity);
        }

        // POST: Obra/Create
        [HttpPost]
        public ActionResult Create(ObraDTO obj)
        {
            try
            {
                ObraBusiness business = new ObraBusiness();
                business.Create(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Obra/Edit/5
        public ActionResult Edit(int id)
        {
            ObraBusiness obraBusiness = new ObraBusiness();
            AutorBusiness autorBusiness = new AutorBusiness();
            EditoraBusiness editoraBusiness = new EditoraBusiness();
            GeneroBusiness generoBusiness = new GeneroBusiness();

            ObraViewModel vm = new ObraViewModel()
            {
                Obra = obraBusiness.GetObraById(id),
                Obras = obraBusiness.GetObra(),
                Autores = autorBusiness.GetAutor(),
                Editoras = editoraBusiness.GetEditora(),
                Generos = generoBusiness.GetGenero()
            };

            return View(vm);
        }

        // POST: Obra/Edit/5
        [HttpPost]
        public ActionResult Edit(ObraDTO obj)
        {
            try
            {
                ObraBusiness business = new ObraBusiness();
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
