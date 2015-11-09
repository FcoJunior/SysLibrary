using SysLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Entities
{
    public class Obra : BaseEntity
    {
        public string CodigoISBN { get; set; }
        public string Titulo { get; set; }
        public DateTime DataDeCadastro { get; set; }

        public int AutorId { get; set; }

        [ForeignKey("AutorId")]
        public virtual Autor Autor { get; set; }

        public int EditoraId { get; set; }

        [ForeignKey("EditoraId")]
        public virtual Editora Editora { get; set; }

        public int GeneroId { get; set; }

        [ForeignKey("GeneroId")]
        public virtual Genero Genero { get; set; }

        public int? AnoDePublicacao { get; set; }

        public string Informacoes { get; set; }


    }
}
