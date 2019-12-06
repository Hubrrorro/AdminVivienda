using AdminVivienda.DAL;
using AdminVivienda.DAL.Catalogos;
using AdminVivienda.Interface;
using AdminVivienda.Models;
using AdminVivienda.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.BL.Catalogos
{
    public class TipoViviendaBusiness : IGeneralBusiness<TipoViviendaModel>
    {
        private IGeneralManage<CAT_TIPOVIVIENDA> _manage;
        private RespuestaModel _respuesta;
        public TipoViviendaBusiness()
        {
            _respuesta = new RespuestaModel();
            _manage = new TipoViviendaManage();
        }
        private CAT_TIPOVIVIENDA Transformar(TipoViviendaModel model)
        {
            CAT_TIPOVIVIENDA tipoVivienda = new CAT_TIPOVIVIENDA();
            tipoVivienda.TipoVivienda = model.TipoVivienda.Trim();
            tipoVivienda.Activo = model.Activo == 1 ? true : false;
            tipoVivienda.Id_TipoVivienda = model.Id_TipoVivienda;
            return tipoVivienda;
        }
        private void RevisarCamposObligatorios(CAT_TIPOVIVIENDA model)
        {
            _respuesta.ejecucion = true;
            if (String.IsNullOrEmpty(model.TipoVivienda))
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Mensajes.CampoRequerido);
            }

        }

        public RespuestaModel Actualizar(TipoViviendaModel modelo)
        {
            try
            {
                CAT_TIPOVIVIENDA tipoVivienda = Transformar(modelo);
                RevisarCamposObligatorios(tipoVivienda);
                if (!_respuesta.ejecucion)
                    return _respuesta;
                if (_manage.Existe(tipoVivienda))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Mensajes.SIExiste);
                    return _respuesta;
                }
                _manage.Actualizar(tipoVivienda);
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

        public RespuestaModel Agregar(TipoViviendaModel modelo)
        {
            try
            {
                CAT_TIPOVIVIENDA tipoVivienda = Transformar(modelo);
                RevisarCamposObligatorios(tipoVivienda);
                if (!_respuesta.ejecucion)
                    return _respuesta;
                if (_manage.Existe(modelo.TipoVivienda))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Mensajes.SIExiste);
                    return _respuesta;
                }
                _manage.Agregar(tipoVivienda);
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

        public RespuestaModel Consultar(TipoViviendaModel modelo)
        {
            try
            {
                var listTodo = _manage.Consultar();
                if (!String.IsNullOrEmpty(modelo.TipoVivienda))
                    listTodo = listTodo.Where(x => x.TipoVivienda.Contains(modelo.TipoVivienda)).ToList();
                if (modelo.Activo == 1)
                    listTodo = listTodo.Where(x => x.Activo.Equals(true)).ToList();
                if (modelo.Activo == 0)
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

        public RespuestaModel ConsultarId(int id)
        {
            try
            {
                var listTodo = _manage.ConsultarId(id);
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
    }
    
}