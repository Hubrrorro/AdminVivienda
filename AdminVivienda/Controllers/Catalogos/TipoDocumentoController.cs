using AdminVivienda.Models.Catalogos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda.Controllers.Catalogos
{
    public class TipoDocumentoController : CatalogoNivel1Controller
    {
        private static TablaNivel1 _tablaNivel1 = new TablaNivel1()
        {
            descripcion = "TipoDocumento",
            idNombre = "Id_TipoDocumento",
            nombreTabla = "CAT_TIPODOCUMENTO"
        };
        private static Nivel1RecursosModel _nivel1 = new Nivel1RecursosModel()
        {
            campo1 = "Tipo de documento",
            maxValue = 50,
            estatus = "Estatus",
            tituloAgregar = "Agregar tipo de documento",
            tituloEditar = "Editar tipo de documento",
            tituloIndex = "Buscar tipo de documento",
            tabla = _tablaNivel1
        };
        public TipoDocumentoController() : base(_nivel1)
        {
        }
    }
}