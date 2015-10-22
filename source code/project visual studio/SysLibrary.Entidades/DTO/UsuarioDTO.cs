using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class UsuarioDTO : DTO
    {
        public int TipoUsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }

        public virtual ICollection<BibliotecarioDTO> Bibliotecario { get; set; }
        public virtual TipoUsuarioDTO TipoUsuario { get; set; }
        public virtual ICollection<UsuarioFinalDTO> UsuarioFinal { get; set; }
    }
}
