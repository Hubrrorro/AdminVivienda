using AdminVivienda.Models.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.Models.Vivienda
{
    public class ViviendaModel
    {
        public int id_Vivienda { get; set; }
        public string Vivienda { get; set; }
        public string Calle { get; set; }
        public string DemMun { get; set; }
        public string Colonia { get; set; }
        public string NumExt { get; set; }
        public string NumInt { get; set; }
        public string Lote { get; set; }
        public string Cp { get; set; }
        public int Id_Estado { get; set; }
        public int Id_Propietario { get; set; }
        public int Id_TipoVivienda { get; set; }
        public int Id_Condominio { get; set; }
        public int Activo { get; set; }
        public PersonaModel persona { get; set; }

}
}