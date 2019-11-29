using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.Models.Catalogos
{
    public class TipoViviendaModel
    {
        public int Id_TipoVivienda { get; set; }
        public string TipoVivienda { get; set; }
        public int Activo { get; set; }
    }
}