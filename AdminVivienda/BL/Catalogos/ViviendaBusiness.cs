using AdminVivienda.DAL;
using AdminVivienda.DAL.Catalogos;
using AdminVivienda.Interface;
using AdminVivienda.Models;
using AdminVivienda.Models.Catalogos;
using AdminVivienda.Models.Vivienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.BL.Catalogos
{
    public class ViviendaBusiness : IGeneralBusiness<ViviendaModel>
    {
        private IGeneralManage<CAT_VIVIENDA> _manage;
        private RespuestaModel _respuesta;
        public ViviendaBusiness()
        {
            _respuesta = new RespuestaModel();
            _manage = new ViviendaManage();
        }
        private CAT_VIVIENDA Transformar(ViviendaModel model)
        {
            CAT_VIVIENDA vivienda = new CAT_VIVIENDA();
            vivienda.Activo = model.Activo == 1 ? true : false;
            vivienda.Calle = model.Calle;
            vivienda.id_Condominio = model.Id_Condominio;
            vivienda.id_Propietario = model.Id_Propietario;
            vivienda.id_TipoVivienda = model.Id_TipoVivienda;
            vivienda.Id_Vivienda = model.id_Vivienda;
            vivienda.Lote = model.Lote;
            vivienda.NumExt = model.NumExt;
            vivienda.NumInt = model.NumInt;
            vivienda.Vivienda = model.Vivienda;
            return vivienda;
        }
        private void RevisarCamposObligatorios(CAT_VIVIENDA model)
        {
            _respuesta.ejecucion = true;
            if (String.IsNullOrEmpty(model.Vivienda))
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Mensajes.CampoRequerido);
            }

        }

        public RespuestaModel Actualizar(ViviendaModel modelo)
        {
            try
            {
                CAT_VIVIENDA vivienda = Transformar(modelo);
                RevisarCamposObligatorios(vivienda);
                if (!_respuesta.ejecucion)
                    return _respuesta;
                if (_manage.Existe(vivienda))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Mensajes.SIExiste);
                    return _respuesta;
                }
                PersonalManage personalManage = new PersonalManage();
                personalManage.Actualizar(new CAT_PERSONAS()
                {
                    Activo = true,
                    ApeMat = modelo.persona.ApeMaterno,
                    ApePat = modelo.persona.ApePaterno,
                    Contacto1 = modelo.persona.Contacto1,
                    Contacto2 = modelo.persona.Contacto2,
                    Correo = modelo.persona.Correo,
                    Nombre = modelo.persona.Nombre,
                     Id_Persona = modelo.Id_Propietario
                });
                _manage.Actualizar(vivienda);
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

        public RespuestaModel Agregar(ViviendaModel modelo)
        {
            try
            {
                CAT_VIVIENDA vivienda = Transformar(modelo);
                RevisarCamposObligatorios(vivienda);
                if (!_respuesta.ejecucion)
                    return _respuesta;
                if (_manage.Existe(modelo.Vivienda))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Mensajes.SIExiste);
                    return _respuesta;
                }
                PersonalManage personalManage = new PersonalManage();
                personalManage.Agregar(new CAT_PERSONAS()
                {
                    Activo = true,
                    ApeMat = modelo.persona.ApeMaterno,
                    ApePat = modelo.persona.ApePaterno,
                    Contacto1 = modelo.persona.Contacto1,
                    Contacto2 = modelo.persona.Contacto2,
                    Correo = modelo.persona.Correo,
                    Nombre = modelo.persona.Nombre
                });
                var personaid =  personalManage.Consultar().Where(x => x.Correo.Equals(modelo.persona.Correo)).FirstOrDefault().Id_Persona;
                vivienda.id_Propietario = personaid;
                _manage.Agregar(vivienda);
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

        public RespuestaModel Consultar(ViviendaModel modelo)
        {
            try
            {
                var listTodo = _manage.Consultar();

                if (!String.IsNullOrEmpty(modelo.Vivienda))
                    listTodo = listTodo.Where(x => x.Vivienda.Contains(modelo.Vivienda)).ToList();
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
        public RespuestaModel Select()
        {
            try
            {
                var listTodo = _manage.Consultar();
                listTodo = listTodo.Where(x => x.Activo.Equals(true)).ToList();
                List<SelectModel> listSelect = new List<SelectModel>();
                foreach (var registro in listTodo)
                {
                    listSelect.Add(new SelectModel()
                    {
                        descripcion = registro.Vivienda,
                        id = registro.Id_Vivienda
                    });
                }
                _respuesta.datos = listSelect;
                _respuesta.ejecucion = true;
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