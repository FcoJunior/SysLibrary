using SysLibrary.Business;
using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysLibrary.WebApp.Models
{
    public class ExemplarViewModel
    {

        public ExemplarViewModel()
        {
            Obras = new SelectList(ObraBO.GetAllActive<Obra>(),"Id","Titulo");
        }

        public Exemplar Exemplar { get; set; }
        public ICollection<Exemplar> Exemplares { get; set; }

        public SelectList Obras { get; set; }

    }
}