using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.Models
{
    public class TipoVivienda
    {
        public int id_TipoVivienda { get; set; }
        public string tipoVivienda { get; set; }
        public string clave { get; set; }
        public bool activo { get; set; }
    }
}