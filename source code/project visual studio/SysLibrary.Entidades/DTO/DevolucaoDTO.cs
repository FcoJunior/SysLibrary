using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class DevolucaoDTO : DTO
    {
        public int EmprestimoId { get; set; }
        public System.DateTime DataDevolucao { get; set; }
        public float Multa { get; set; }

        public virtual EmprestimoDTO Emprestimo { get; set; }
    }
}
