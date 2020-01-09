using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.Models
{
    public class CondominioModel
    {
        public int id_Condominio { get; set; }
        public string Condominio { get; set; }
        public int Activo { get; set; }
        public string DemMun { get; set; }
        public string Colonia { get; set; }
        public int CP { get; set; }
        public string Clave { get; set; }
        public int id_Estado { get; set; }
        public string Estado { get; set; }
    }
}