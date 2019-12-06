using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.Models.Vivienda
{
    public class ViviendaIndexModel
    {
        public List<EstadoModel> Estados { get; set; }
        public List<ViviendaGridModel> Viviendas { get; set; }
    }
}