using SysLibrary.Business;
using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysLibrary.WebApp.Models
{
    public class ObraViewModel
    {
        public ObraViewModel()
        {
            Autores = new SelectList(AutorBO.GetAllActive<Autor>(),"Id","Nome");
            Editoras = new SelectList(EditoraBO.GetAllActive<Editora>(), "Id", "Nome");
            Generos = new SelectList(GeneroBO.GetAllActive<Genero>(), "Id", "Nome");
        }

        public Obra Obra { get; set; }
        public ICollection<Obra> Obras { get; set; }

        public SelectList Autores { get; set; }
        public SelectList Editoras { get; set; }
        public SelectList Generos { get; set; }
    }
}