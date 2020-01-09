using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.Models
{
    public class RespuestaModel
    {
        public RespuestaModel()
        {
            mensaje = new List<string>();
        }
        public bool ejecucion { get; set; }
        public List<string> mensaje { get; set; }
        public dynamic datos { get; set; }
    }
}