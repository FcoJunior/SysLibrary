using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysLibrary.WebApp.Models
{
    public class EditoraViewModel
    {
        public EditoraViewModel()
        {

        }

        public Editora Editora { get; set; }
        public ICollection<Editora> Editoras { get; set; }
    }
}