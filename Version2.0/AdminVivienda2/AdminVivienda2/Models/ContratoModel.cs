using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.Models
{
    public class ContratoModel
    {
        public int Id_Contrato { get; set; }
        public string Contrato { get; set; }
        public int Id_Condominio { get; set; }
        public string FechaIni { get; set; }
        public string FechaFin { get; set; }
        public List<ServiciosContratoModel> Servicios { get; set; }
    }
}