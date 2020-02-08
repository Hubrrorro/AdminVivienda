using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.Models
{
    public class ServiciosContratoModel
    {
        public int Id_Contrato { get; set; }
        public int Id_Servicio { get; set; }
        public string Servicio { get; set; }
        public double MesAnt { get; set; }
        public double MesCorr { get; set; }
        public double MesVen { get; set; }
        public int Activo { get; set; }
    }
}