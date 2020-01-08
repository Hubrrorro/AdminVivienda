using AdminVivienda.BL.Catalogos;
using AdminVivienda.Models.Catalogos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda.Controllers.Catalogos
{
    public class TipoViviendaController : CatalogoNivel1Controller
    {
        private static TablaNivel1 _tablaNivel1 = new TablaNivel1()
        {
            descripcion = "TipoVivienda",
            idNombre = "Id_TipoVivienda",
            nombreTabla = "CAT_TIPOVIVIENDA"
        };
        private static Nivel1RecursosModel _nivel1 = new Nivel1RecursosModel()
        {
            campo1 = "Tipo de vivienda",
            maxValue = 50,
            estatus = "Estatus",
            tituloAgregar = "Agregar tipo de vivienda",
            tituloEditar = "Editar tipo de vivienda",
            tituloIndex = "Buscar tipo de vivienda",
            tabla = _tablaNivel1
        };
        // GET: TipoVivienda
        
        public TipoViviendaController() : base(_nivel1)
        {
        }
    }
}