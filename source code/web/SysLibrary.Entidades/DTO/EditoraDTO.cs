﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysLibrary.Entidades.DTO
{
    public class EditoraDTO : DTO
    {
        public string Nome { get; set; }

        public virtual ICollection<ObraDTO> Obra { get; set; }
    }
}