using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysLibrary.WebApp.Models
{
    public class AutorViewModel
    {
        public AutorViewModel()
        {

        }

        public Autor Autor { get; set; }
        public ICollection<Autor> Autores { get; set; }
    }
}