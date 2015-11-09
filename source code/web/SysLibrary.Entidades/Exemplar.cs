using SysLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Entities.Enumeradores;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysLibrary.Entities
{
    public class Exemplar : BaseEntity
    {
        public int ObraId { get; set; }

        [ForeignKey("ObraId")]
        public virtual Obra Obra { get; set; }

        public string Patrimonio { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public StatusExemplar Status { get; set; }
    }
}
