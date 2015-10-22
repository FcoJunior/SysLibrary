using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class ExemplarDTO : DTO
    {
        public int ObraId { get; set; }
        public string Patrimonio { get; set; }
        public bool Status { get; set; }
        public System.DateTime DataCadastro { get; set; }

        public virtual ICollection<EmprestimoDTO> Emprestimo { get; set; }
        public virtual ObraDTO Obra { get; set; }
    }
}
