using AdminVivienda2.DAL;
using AdminVivienda2.Interface;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.BL
{
    public class ViviendaBL : IGeneral<CAT_VIVIENDAS, ViviendaModel>
    {
        private RespuestaModel _respuesta;

        public ViviendaBL() {
            _respuesta = new RespuestaModel();
        }
        public RespuestaModel Actualizar(CAT_VIVIENDAS modelo)
        {
            try
            {
                if (!_respuesta.ejecucion)
                    return _respuesta;
                if (Existe(modelo))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Resources.Mensajes.MensajeDuplicado);
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    var registro = conex.CAT_VIVIENDAS.Where(x => x.Id_Vivienda.Equals(modelo.Id_Vivienda)).FirstOrDefault();
                    registro.Activo = modelo.Activo;
                    registro.Calle = modelo.Calle;
                    registro.id_Condominio = modelo.id_Condominio;
                    registro.id_Propietario = modelo.id_Propietario;
                    registro.id_TipoVivienda = modelo.id_TipoVivienda;
                    registro.Lote = modelo.Lote;
                    registro.NumExt = modelo.NumExt;
                    registro.NumInt = modelo.NumInt;
                    registro.Vivienda = modelo.Vivienda;
                    conex.SaveChanges();
                }
                _respuesta.ejecucion = true;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeEditar);
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }

        public RespuestaModel Agregar(CAT_VIVIENDAS modelo)
        {
            try
            {
                if (Existe(modelo.Vivienda))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Resources.Mensajes.MensajeDuplicado);
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    modelo.Activo = true;
                    conex.CAT_VIVIENDAS.Add(modelo);
                    conex.SaveChanges();
                }
                _respuesta.ejecucion = true;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeCorrecto);
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }

        public RespuestaModel Consultar(ViviendaModel modelo)
        {
            try
            {
                List<CAT_VIVIENDAS> listTodo = new List<CAT_VIVIENDAS>(); 
                using (var conex = new DatabaseViviendaEntities())
                {
                    listTodo= conex.CAT_VIVIENDAS.ToList();
                }
                if (!String.IsNullOrEmpty(modelo.Vivienda))
                    listTodo = listTodo.Where(x => x.Vivienda.Contains(modelo.Vivienda)).ToList();
                if (modelo.Activo.Equals(1))
                    listTodo = listTodo.Where(x => x.Activo.Equals(true)).ToList();
                if (modelo.Activo.Equals(0))
                    listTodo = listTodo.Where(x => x.Activo.Equals(false)).ToList();
                _respuesta.ejecucion = true;
                _respuesta.datos = listTodo;
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }
        public RespuestaModel Select()
        {
            try
            {
                List<SelectModel> listSelect = new List<SelectModel>();
                using (var conex = new DatabaseViviendaEntities())
                {
                    var listado = conex.CAT_VIVIENDAS.Where(x => x.Activo.Equals(true)).ToList();
                    foreach (var itemlst in listado)
                    {
                        listSelect.Add(new SelectModel() { descripcion = itemlst.Vivienda, id = itemlst.Id_Vivienda });
                    }
                }
                _respuesta.ejecucion = true;
                _respuesta.datos = listSelect;
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }
        public RespuestaModel ConsultarId(int id)
        {
            try
            {
                CAT_VIVIENDAS vivienda = new CAT_VIVIENDAS();
                using (var conex = new DatabaseViviendaEntities())
                {
                    vivienda= conex.CAT_VIVIENDAS.Where(x => x.Id_Vivienda.Equals(id)).FirstOrDefault();
                }
                _respuesta.ejecucion = true;
                _respuesta.datos = vivienda;
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);
            }
            return _respuesta;
            
        }
        private bool Existe(string nombre)
        {
            int cantidad = 0;
            using (var conex = new DatabaseViviendaEntities())
            {
                cantidad = conex.CAT_VIVIENDAS.Where(x => x.Vivienda.Trim().ToUpper().Equals(nombre.Trim().ToUpper())).Count();
            }
            if (cantidad == 0)
                return false;
            else
                return true;
        }
        private bool Existe(CAT_VIVIENDAS model)
        {
            int cantidad = 0;
            using (var conex = new DatabaseViviendaEntities())
            {
                cantidad = conex.CAT_VIVIENDAS.Where(x => x.Vivienda.Trim().ToUpper().Equals(model.Vivienda.Trim().ToUpper())
                && x.Id_Vivienda != model.Id_Vivienda).Count();
            }
            if (cantidad == 0)
                return false;
            else
                return true;
        }
    }
}