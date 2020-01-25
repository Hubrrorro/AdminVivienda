using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.Models
{
    public class UsuarioModel
    {
        public int Id_Usuario { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int Activo { get; set; }
    }
}