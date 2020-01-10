using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda2.Controllers.Catalogos
{
    public class TipoViviendaController : Nivel1Campo1Controller
    {
        // GET: TipoVivienda
        private static TablaNivel1 _tablaNivel1 = new TablaNivel1()
        {
            descripcion = "TipoVivienda",
            idNombre = "Id_TipoVivienda",
            nombreTabla = "CAT_TIPOVIVIENDAS"
        };
        private static Nivel1Campo1Model _nivel1 = new Nivel1Campo1Model()
        {
            campo1 = "Tipo de vivienda",
            maxValue = 50,
            estatus = "Estatus",
            tituloAgregar = "Agregar tipo de vivienda",
            tituloEditar = "Editar tipo de vivienda",
            tituloIndex = "Buscar tipo de vivienda",
            tabla = _tablaNivel1
        };
        public TipoViviendaController() : base(_nivel1)
        {
        }
    }
}