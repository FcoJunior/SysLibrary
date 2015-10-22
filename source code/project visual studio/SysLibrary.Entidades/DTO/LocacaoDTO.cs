using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class LocacaoDTO : DTO
    {
        public int UsuarioFinalId { get; set; }
        public int BibliotecarioId { get; set; }
        public System.DateTime DataLocacao { get; set; }

        public virtual BibliotecarioDTO Bibliotecario { get; set; }
        public virtual ICollection<EmprestimoDTO> Emprestimo { get; set; }
        public virtual UsuarioFinalDTO UsuarioFinal { get; set; }
    }
}
