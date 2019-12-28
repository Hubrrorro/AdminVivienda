using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.Models.Catalogos.General
{
    public class Nivel1Campo2RecursosModel
    {
        public Nivel1Campo2RecursosModel() 
        {
            datos = new List<Nivel1Campo2Model>();
        }
        public string tituloIndex { get; set; }
        public string tituloAgregar { get; set; }
        public string tituloEditar { get; set; }
        public string campo1 { get; set; }
        public string campo2 { get; set; }
        public int maxValue { get; set; }
        public int maxValue2 { get; set; }
        public string estatus { get; set; }
        public List<Nivel1Campo2Model> datos { get; set; }
        public TablaNivel1Campo2 tabla { get; set; }
    }
    public class TablaNivel1Campo2
    {
        public string idNombre { get; set; }
        public string descripcion { get; set; }
        public string descripcion2 { get; set; }
        public string estatus { get; set; }
        public string nombreTabla { get; set; }

    }
}