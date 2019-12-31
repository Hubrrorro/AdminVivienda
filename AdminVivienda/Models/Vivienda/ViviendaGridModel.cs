using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.Models.Vivienda
{
    public class ViviendaGridModel
    {
        public int Id_Condominio { get; set; }
        public int id_Vivienda { get; set; }
        public string Vivienda { get; set; }
        public bool Activo { get; set; }
    }
}