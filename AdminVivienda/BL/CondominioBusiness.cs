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
        private CAT_CONDOMINIO Transformar(CondominioModel model) {
            CAT_CONDOMINIO condominio = new CAT_CONDOMINIO();
            condominio.Condominio = model.Condominio;
            condominio.Activo = model.Activo == 1 ? true : false;
            model.id_Condominio = model.id_Condominio;
            return condominio;
        }
        private void RevisarCamposObligatorios(CAT_CONDOMINIO model)
        {
            if (String.IsNullOrEmpty(model.Condominio))
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Mensajes.CampoRequerido);
            }

        }
        public RespuestaModel ObtenerPorID(int id)
        {
            try
            {
                var listTodo = _manage.ObtenerPorId(id);
                _respuesta.ejecucion = true;
                _respuesta.datos = listTodo;
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Mensajes.Falla);

            }
            return _respuesta;
        }
        public RespuestaModel Obtener(CondominioModel model) {
            try
            {
                var listTodo = _manage.ObtenerTodo();
                if (!String.IsNullOrEmpty(model.Condominio))
                    listTodo = listTodo.Where(x => x.Condominio.Contains(model.Condominio)).ToList();
                if (model.Activo == 1)
                    listTodo = listTodo.Where(x => x.Activo.Equals(true)).ToList();
                if (model.Activo == 0)
                    listTodo = listTodo.Where(x => x.Activo.Equals(false)).ToList();
                _respuesta.ejecucion = true;
                _respuesta.datos = listTodo;
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Mensajes.Falla);
                
            }
            return _respuesta;
        }
        public RespuestaModel Agregar(CondominioModel model)
        {
            try
            {
                CAT_CONDOMINIO condominio = Transformar(model);
                RevisarCamposObligatorios(condominio);
                if (!_respuesta.ejecucion)
                    return _respuesta;
                if (_manage.Existe(model.Condominio))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Mensajes.SIExiste);
                    return _respuesta;
                }
                _manage.Agregar(condominio);
                _respuesta.ejecucion = true;
                _respuesta.mensaje.Add(Mensajes.OkGuardar);
                return _respuesta;
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Mensajes.Falla);
                
            }
            return _respuesta;
        }
        public RespuestaModel Actualizar(CondominioModel model)
        {
            try
            {
                CAT_CONDOMINIO condominio = Transformar(model);
                RevisarCamposObligatorios(condominio);
                if (!_respuesta.ejecucion)
                    return _respuesta;
                if (_manage.Existe(condominio))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Mensajes.SIExiste);
                    return _respuesta;
                }
                _manage.Actualizar(condominio);
                _respuesta.ejecucion = true;
                _respuesta.mensaje.Add(Mensajes.OkActualizar);
                
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Mensajes.Falla);
                
            }
            return _respuesta;
        }
    }
}