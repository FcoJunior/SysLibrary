using SysLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Entities
{
    public class Locacao : BaseEntity
    {
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public int ExemplarId { get; set; }

        [ForeignKey("ExemplarId")]
        public virtual Exemplar Exemplar { get; set; }

        public DateTime DataDeLocacao { get; set; }

        public DateTime DataPrevistaDeDevolucao { get; set; }

        public DateTime? DataDeDevolucao { get; set; }
    }
}
