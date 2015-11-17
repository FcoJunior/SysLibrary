using SysLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Entities
{
    public class Locacao : BaseEntity
    {
        public int UsuarioId { get; set; }
        public int ExemplarId { get; set; }
        public DateTime DataDeLocacao { get; set; }
        public DateTime DataDeDevolucao { get; set; }
    }
}
