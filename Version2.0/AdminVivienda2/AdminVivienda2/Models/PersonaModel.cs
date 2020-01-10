using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.Models
{
    public class PersonaModel
    {
        public int Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Correo { get; set; }
        public string Contacto1 { get; set; }
        public string Contacto2 { get; set; }
        public int Activo { get; set; }
    }
}