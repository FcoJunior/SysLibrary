using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class RenovacaoDTO : DTO
    {
        public int EmprestimoId { get; set; }
        public System.DateTime DataRenovacao { get; set; }
        public System.DateTime DataPrevistaDevolucao { get; set; }

        public virtual EmprestimoDTO Emprestimo { get; set; }
    }
}
