using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Entidades.DTO
{
    public class BibliotecarioDTO : DTO
    {
        public int UserId { get; set; }
        public string Nome { get; set; }

        public virtual UsuarioDTO Usuario { get; set; }
        public virtual ICollection<LocacaoDTO> Locacao { get; set; }
    }
}
