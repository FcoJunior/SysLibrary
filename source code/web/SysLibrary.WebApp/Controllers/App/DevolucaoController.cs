using SysLibrary.Business;
using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SysLibrary.WebApp.Controllers.App
{
    public class DevolucaoController : Controller
    {
        //
        // GET: /Devolucao/
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult BuscarExemplarPorCodigo(string codigo)
        {
            var locacao = LocacaoBO.GetAllActive<Locacao>(x => x.Exemplar.Patrimonio == codigo && x.DataDeDevolucao == null);
            if (locacao.Count() == 0)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Erro = "Nenhuma locação encontrada para este exemplar!" }, JsonRequestBehavior.AllowGet);
            }

            var json = locacao.Select(x => new { Titulo = x.Exemplar.Obra.Titulo, Usuario = x.Usuario.Nome}).ToList();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarInformacoesDaLocacaoPorCodigo(string codigo)
        {
            var locacao = LocacaoBO.GetAllActive<Locacao>(x => x.Exemplar.Patrimonio == codigo && x.DataDeDevolucao == null);
            if (locacao.Count() == 0)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Erro = "Nenhuma locação encontrada para este exemplar!" }, JsonRequestBehavior.AllowGet);
            }

            var json = locacao.Select(x => new { Titulo = x.Exemplar.Obra.Titulo,
                Id = x.Id,
                DataPrevista = x.DataPrevistaDeDevolucao.ToString("dd/MM/yyyy"),
                DataDeDevolucao = DateTime.Today.ToString("dd/MM/yyyy"), 
                DiasAtrasados = (DateTime.Today - x.DataPrevistaDeDevolucao).Days, 
                Valor = (DateTime.Today - x.DataPrevistaDeDevolucao).Days*0.50 }).ToList();

            return Json(json, JsonRequestBehavior.AllowGet);

        }
	}
}