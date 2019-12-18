using AdminVivienda.DAL.Catalogos;
using AdminVivienda.Models;
using AdminVivienda.Models.Catalogos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.BL.Catalogos
{
    public class GeneralNivel1Campo2Business
    {
        private GeneralManageNivel1Campo2 _manage;
        private RespuestaModel _respuesta;
        public GeneralNivel1Campo2Business(string idName, string columnName, string column2Name, string tabla)
        {
            _respuesta = new RespuestaModel();
            _manage = new GeneralManageNivel1Campo2(idName, columnName,column2Name, tabla);
        }
        public RespuestaModel Consultar(Nivel1Campo2Model modelo)
        {
            try
            {
                _respuesta.ejecucion = true;
                _respuesta.datos = _manage.Consultar(modelo);
            }
            catch (Exception ex)
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(ex.Message);
            }
            return _respuesta;
        }
        public RespuestaModel Agregar(Nivel1Campo2Model modelo)
        {
            try
            {
                if (String.IsNullOrEmpty(modelo.descripcion))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add("Dato requerido");
                    return _respuesta;
                }
                var listado = _manage.Consultar(new Nivel1Campo2Model() { activo = -1, id = 0 });
                int intExiste = listado.Where(x => x.descripcion.Trim().ToUpper().Equals(modelo.descripcion.Trim().ToUpper())).Count();
                if (intExiste > 0)
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add("El dato que deseas ingresar ya se encuentra registrado");
                    return _respuesta;
                }
                _manage.Agregar(modelo);
                _respuesta.ejecucion = true;
                _respuesta.mensaje.Add("Se agregó correctamente");
                return _respuesta;
            }
            catch (Exception ex)
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(ex.Message);
                return _respuesta;
            }

        }
        public RespuestaModel Actualizar(Nivel1Campo2Model modelo)
        {
            try
            {
                if (String.IsNullOrEmpty(modelo.descripcion))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add("Dato requerido");
                    return _respuesta;
                }
                if (modelo.id.Equals(0))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add("Identificador requerido");
                    return _respuesta;
                }
                var listado = _manage.Consultar(modelo);
                int intExiste = listado.Where(x => x.descripcion.Trim().ToUpper().Equals(modelo.descripcion.Trim().ToUpper()) && !x.id.Equals(modelo.id)).Count();
                if (intExiste > 0)
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add("El dato que deseas modificar ya se encuentra registrado");
                    return _respuesta;
                }
                _manage.Editar(modelo);
                _respuesta.ejecucion = true;
                _respuesta.mensaje.Add("Se actualizó correctamente");
                return _respuesta;
            }
            catch (Exception ex)
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(ex.Message);
                return _respuesta;
            }
        }
    }
}