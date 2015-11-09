using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Entities.Enumeradores
{
    public enum StatusExemplar
    {
        [Description("Disponível")]
        Disponivel = 1,

        [Description("Locado")]
        Locado
    }
}
