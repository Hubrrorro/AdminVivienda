using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.Models
{
    public class DocumentosAdministradorModel
    {
        public int Id_Documento { get; set; }
        public int Id_Condominio { get; set; }
        public string Documento { get; set; }
        public string Descripcion { get; set; }
        public int Id_TipoDocumento { get; set; }
        public int Activo { get; set; }
        public DateTime Fecha { get; set; }
        public string Ruta { get; set; }
    }
}