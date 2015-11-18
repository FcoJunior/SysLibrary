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

namespace SysLibrary.WebApp.Controllers.App
{
    [Authorize]
    public class LocacaoController : Controller
    {
        // GET: Locacao
        public ActionResult Index(int? usuarioId)
        {
            try
            {
                UsuarioViewModel vm = new UsuarioViewModel();
                vm.Usuario = UsuarioBO.Find<Usuario>(usuarioId);
                vm.Locacoes = LocacaoBO.GetLocacaoByUsuario(usuarioId);

                if(vm.Usuario == null)
                {
                    vm.Usuario = new Usuario();
                }
                if(vm.Locacoes == null)
                {
                    vm.Locacoes = new List<Locacao>();
                }
                return View(vm);
            }
            catch
            {
                return View(new UsuarioViewModel());
            }
        }

        public ActionResult Devolucao(int id)
        {
            using (var repositorio = SysLibrary.Repository.Factory.GetInstance())
            {
                var obj = repositorio.GetById<Locacao>(id);
                obj.DataDeDevolucao = DateTime.Now;
                repositorio.Save<Locacao>(obj);
            }

            return RedirectToAction("Index");
        }

        // GET: Locacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locacao/Create
        [HttpPost]
        public ActionResult Create(Locacao obj)
        {
            try
            {
                obj.DataDeLocacao = DateTime.Now;
                LocacaoBO.Save<Locacao>(obj);
                HttpStatusCodeResult http = new HttpStatusCodeResult(HttpStatusCode.OK);
                return http;
            }
            catch
            {
                return View();
            }
        }

        // GET: Locacao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Locacao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Locacao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Locacao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
