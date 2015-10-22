using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class UsuarioFinalDTO : DTO
    {
        public int UsuarioId { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public bool Pendencia { get; set; }

        public virtual ICollection<LocacaoDTO> Locacao { get; set; }
        public virtual UsuarioDTO Usuario { get; set; }
    }
}
