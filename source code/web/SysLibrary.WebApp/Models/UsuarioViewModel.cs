using SysLibrary.Business;
using SysLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysLibrary.WebApp.Models
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            
        }

        public Usuario Usuario { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Locacao> Locacoes { get; set; }
    }
}