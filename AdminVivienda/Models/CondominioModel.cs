using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.Models
{
    public class CondominioModel
    {
        public int id_Condominio { get; set; }
        public string Condominio { get; set; }
        public bool Activo { get; set; }
    }
}