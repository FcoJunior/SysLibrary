using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class EmprestimoDTO : DTO
    {
        public int LocacaoId { get; set; }
        public int ExemplarId { get; set; }
        public System.DateTime DataPrevistaDevolucao { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<DevolucaoDTO> Devolucao { get; set; }
        public virtual ExemplarDTO Exemplar { get; set; }
        public virtual ICollection<RenovacaoDTO> Renovacao { get; set; }
        public virtual LocacaoDTO Locacao { get; set; }
    }
}
