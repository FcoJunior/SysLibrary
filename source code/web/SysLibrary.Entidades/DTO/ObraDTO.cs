using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class ObraDTO : DTO
    {
        public int GeneroId { get; set; }
        public int EditoraId { get; set; }
        public string Nome { get; set; }
        public int AutorId { get; set; }
        public System.DateTime DataCadastro { get; set; }

        public virtual EditoraDTO Editora { get; set; }
        public virtual AutorDTO Autor { get; set; }
        public virtual ICollection<ExemplarDTO> Exemplar { get; set; }
        public virtual GeneroDTO Genero { get; set; }
    }
}
