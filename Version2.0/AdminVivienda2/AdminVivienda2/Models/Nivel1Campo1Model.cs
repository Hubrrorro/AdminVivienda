using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.Models
{
    public class Nivel1Campo1Model
    {
        public Nivel1Campo1Model()
        {
            datos = new List<Nivel1Model>();
        }
        public string tituloIndex { get; set; }
        public string tituloAgregar { get; set; }
        public string tituloEditar { get; set; }
        public string campo1 { get; set; }
        public int maxValue { get; set; }
        public string estatus { get; set; }
        public List<Nivel1Model> datos { get; set; }
        public TablaNivel1 tabla { get; set; }
    }
    public class TablaNivel1
    {
        public string idNombre { get; set; }
        public string descripcion { get; set; }
        public string estatus { get; set; }
        public string nombreTabla { get; set; }

    }
    public class Nivel1Model
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int activo { get; set; }
    }
}