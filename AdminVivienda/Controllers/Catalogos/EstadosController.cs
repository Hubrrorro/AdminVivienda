using AdminVivienda.Models.Catalogos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda.Controllers.Catalogos
{
    public class EstadosController : CatalogoNivel1Controller
    {
        // GET: TipoVivienda
        private static TablaNivel1 _tablaNivel1 = new TablaNivel1()
        {
            descripcion = "Estado",
            idNombre = "Id_Estado",
            nombreTabla = "CAT_ESTADOS"
        };
        private static Nivel1RecursosModel _nivel1 = new Nivel1RecursosModel()
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