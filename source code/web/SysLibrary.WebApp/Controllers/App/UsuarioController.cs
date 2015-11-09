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
using SysLibrary.Util;
using System.Web.Security;

namespace SysLibrary.WebApp.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        // GET: /Usuario/
        public ActionResult Index()
        {
            var usuarios = UsuarioBO.GetAllActive<Usuario>();

            return View(new UsuarioViewModel
            {
                Usuarios = usuarios
            });
        }

        // GET: /Usuario/Create
        public ActionResult Create()
        {
            return View(new UsuarioViewModel());
        }

        // POST: /Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel model)
        {
           
            if (model.Usuario.Id == 0)
                model.Usuario.Senha = "1234".Encript();

            UsuarioBO.Save<Usuario>(model.Usuario);
            return RedirectToAction("Index");

        }

        // GET: /Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var usuario = UsuarioBO.Find<Usuario>(id);
            if (usuario == null)
            {
                return HttpNotFound();  
            }

            return View("Create", new UsuarioViewModel
            {
                Usuario = usuario
            });
        }

        // GET: /Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var usuario = UsuarioBO.Find<Usuario>(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(new UsuarioViewModel
            {
                Usuario = usuario
            });
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioBO.Remove<Usuario>(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Logar()
        {
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Logar(UsuarioViewModel model)
        {
            var senha = model.Usuario.Senha.Encript();
            var usuarios = UsuarioBO.GetAllActive<Usuario>(x => x.Email == model.Usuario.Email && x.Senha == senha);

            if (usuarios.Any())
            {
                FormsAuthentication.SetAuthCookie(usuarios.FirstOrDefault().Nome, false);
                return RedirectToAction("Index", "Home");
            }

            TempData["Message"] = "Email ou senha inválida!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}
