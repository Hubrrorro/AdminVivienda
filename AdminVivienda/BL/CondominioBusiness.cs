using AdminVivienda.DAL;
using AdminVivienda.DAL.Catalogos;
using AdminVivienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.BL
{
    public class CondominioBusiness
    {
        private RespuestaModel _respuesta;
        private CondominioManage _manage;
        public CondominioBusiness()
        {
            _respuesta = new RespuestaModel();
            _manage = new CondominioManage();
        }
        public RespuestaModel Agregar(CAT_CONDOMINIO model)
        {
            if (String.IsNullOrEmpty(model.Condominio))
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add("Falta el nombre del condominio");
                return _respuesta;
            }
            if (_manage.Existe(model.Condominio))
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add("Ya existe el nombre del condominio");
                return _respuesta;
            }
            _manage.Agregar(model);
            _respuesta.ejecucion = true;
            _respuesta.mensaje.Add("Se agregó correctamente");
            return _respuesta;
        }
    }
}