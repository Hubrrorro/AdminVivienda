using AdminVivienda.DAL;
using AdminVivienda.DAL.Catalogos;
using AdminVivienda.Interface;
using AdminVivienda.Models;
using AdminVivienda.Models.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.BL.Catalogos
{
    public class PersonalBusiness : IGeneralBusiness<PersonaModel>
    {
        private IGeneralManage<CAT_PERSONAS> _manage;
        private RespuestaModel _respuesta;
        public PersonalBusiness()
        {
            _respuesta = new RespuestaModel();
            _manage = new PersonalManage();
        }
        private CAT_PERSONAS Transformar(PersonaModel model)
        {
            CAT_PERSONAS personal = new CAT_PERSONAS();
            personal.Activo = model.Activo == 1 ? true : false;
            personal.ApeMat = model.ApeMaterno;
            personal.ApePat = model.ApePaterno;
            personal.Contacto1 = model.Contacto1;
            personal.Contacto2 = model.Contacto2;
            personal.Correo = model.Correo;
            personal.Id_Persona = model.Id_Persona;
            personal.Nombre = model.Nombre;
            return personal;
        }
        private void RevisarCamposObligatorios(CAT_PERSONAS model)
        {
            _respuesta.ejecucion = true;
            if (String.IsNullOrEmpty(model.Correo))
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Mensajes.CampoRequerido);
            }

        }

        public RespuestaModel Actualizar(PersonaModel modelo)
        {
            try
            {
                CAT_PERSONAS personal = Transformar(modelo);
                RevisarCamposObligatorios(personal);
                if (!_respuesta.ejecucion)
                    return _respuesta;
                if (_manage.Existe(personal))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Mensajes.SIExiste);
                    return _respuesta;
                }
                _manage.Actualizar(personal);
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

        public RespuestaModel Agregar(PersonaModel modelo)
        {
            try
            {
                CAT_PERSONAS personal = Transformar(modelo);
                RevisarCamposObligatorios(personal);
                if (!_respuesta.ejecucion)
                    return _respuesta;
                if (_manage.Existe(modelo.Correo))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Mensajes.SIExiste);
                    return _respuesta;
                }
                _manage.Agregar(personal);
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

        public RespuestaModel Consultar(PersonaModel modelo)
        {
            try
            {
                var listTodo = _manage.Consultar();

                if (!String.IsNullOrEmpty(modelo.Correo))
                    listTodo = listTodo.Where(x => x.Correo.Contains(modelo.Correo)).ToList();
                if (!String.IsNullOrEmpty(modelo.Nombre))
                    listTodo = listTodo.Where(x => x.Nombre.Contains(modelo.Nombre)).ToList();
                if (!String.IsNullOrEmpty(modelo.ApePaterno))
                    listTodo = listTodo.Where(x => x.ApePat.Contains(modelo.ApePaterno)).ToList();
                if (!String.IsNullOrEmpty(modelo.ApeMaterno))
                    listTodo = listTodo.Where(x => x.ApeMat.Contains(modelo.ApeMaterno)).ToList();
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