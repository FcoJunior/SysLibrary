using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.WebApp.ViewModels
{
    public class ObraViewModel
    {
        public ObraDTO Obra { get; set; }

        public List<ObraDTO> Obras { get; set; }
        public List<GeneroDTO> Generos { get; set; }
        public List<AutorDTO> Autores { get; set; }
        public List<EditoraDTO> Editoras { get; set; }
    }
}