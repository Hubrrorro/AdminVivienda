using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.BL
{

    public class TipoViviendaBL : Nivel1Campo2BL
    {
        private static TablaNivel1Campo2 _tablaNivel1 = new TablaNivel1Campo2()
        {
            descripcion = "TipoVivienda",
            idNombre = "Id_TipoVivienda",
            descripcion2 = "Clave",
            nombreTabla = "CAT_TIPOVIVIENDAS"
        };
        private static Nivel1Campo2Model _nivel1 = new Nivel1Campo2Model()
        {
            campo1 = "Tipo de vivienda",
            campo2 = "Clave",
            maxValue2 = 5,
            maxValue = 50,
            estatus = "Estatus",
            tituloAgregar = "Agregar tipo de vivienda",
            tituloEditar = "Editar tipo de vivienda",
            tituloIndex = "Buscar tipo de vivienda",
            tablaC2 = _tablaNivel1
        };
        public TipoViviendaBL() : base(_nivel1)
        {
        }
    }
}