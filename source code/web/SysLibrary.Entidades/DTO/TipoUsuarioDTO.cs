using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class TipoUsuarioDTO : DTO
    {
        public string Tipo { get; set; }

        public virtual ICollection<UsuarioDTO> Usuario { get; set; }
    }
}
