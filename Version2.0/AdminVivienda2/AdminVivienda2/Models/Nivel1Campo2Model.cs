using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.Models
{
    public class Nivel1Campo2Model : Nivel1Campo1Model
    {
        public string campo2 { get; set; }
        public int maxValue2 { get; set; }
        public List<Nivel1_2Model> datosC2 { get; set; }
        public TablaNivel1Campo2 tablaC2 { get; set; }
    }
    public class TablaNivel1Campo2 : TablaNivel1
    {
        public string descripcion2 { get; set; }
    }
    public class Nivel1_2Model : Nivel1Model
    {
        public string descripcion2 { get; set; }
    }
}