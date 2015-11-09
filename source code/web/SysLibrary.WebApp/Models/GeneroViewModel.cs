using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysLibrary.WebApp.Models
{
    public class GeneroViewModel
    {
        public GeneroViewModel()
        {

        }

        public Genero Genero { get; set; }
        public ICollection<Genero> Generos { get; set; }
    }
}