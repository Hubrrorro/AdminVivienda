using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda2.Controllers.Catalogos
{
    public class EstadosController : Nivel1Campo1Controller
    {
        // GET: Estados
        private static TablaNivel1 _tablaNivel1 = new TablaNivel1()
        {
            descripcion = "Estado",
            idNombre = "Id_Estado",
            nombreTabla = "CAT_ESTADOS"
        };
        private static Nivel1Campo1Model _nivel1 = new Nivel1Campo1Model()
        {
            campo1 = "Estado",
            maxValue = 50,
            estatus = "Estatus",
            tituloAgregar = "Agregar Estado",
            tituloEditar = "Editar Estado",
            tituloIndex = "Buscar Estado",
            tabla = _tablaNivel1
        };
        public EstadosController() : base(_nivel1)
        {
        }
    }
}