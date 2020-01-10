using AdminVivienda2.DAL;
using AdminVivienda2.Interface;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.BL
{
    public class CondominioBL : IGeneral<CAT_CONDOMINIOS, CondominioModel>
    {
        private RespuestaModel _respuesta;
        public RespuestaModel Agregar(CAT_CONDOMINIOS model)
        {
            _respuesta = new RespuestaModel();
            try
            {
                if (ExisteDB(model.Condominio))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Resources.Mensajes.MensajeDuplicado);
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    model.Activo = true;
                    conex.CAT_CONDOMINIOS.Add(model);
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
        public RespuestaModel Actualizar(CAT_CONDOMINIOS model)
        {
            try
            {
                _respuesta = new RespuestaModel();
                if (ExisteDB(model))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Resources.Mensajes.MensajeDuplicado);
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    var condominio = conex.CAT_CONDOMINIOS.Where(x => x.Id_Condominio.Equals(model.Id_Condominio)).FirstOrDefault();
                    //condominio = model;
                    condominio.Activo = model.Activo;
                    condominio.Clave = model.Clave;
                    condominio.Colonia = model.Colonia;
                    condominio.Condominio = model.Condominio;
                    condominio.Cp = model.Cp;
                    condominio.DemMun = model.DemMun;
                    condominio.Id_Estado = model.Id_Estado;
                    conex.SaveChanges();
                    _respuesta.ejecucion = true;
                    _respuesta.mensaje.Add(Resources.Mensajes.MensajeEditar);
                }
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }
        public RespuestaModel Consultar(CondominioModel model)
        {
            try
            {
                List<CAT_CONDOMINIOS> listado;
                _respuesta = new RespuestaModel();
                using (var conex = new DatabaseViviendaEntities())
                {
                    listado = conex.CAT_CONDOMINIOS.ToList();
                    if (!String.IsNullOrEmpty(model.Condominio))
                        listado = listado.Where(x => x.Condominio.ToUpper().Contains(model.Condominio.ToUpper())).ToList();
                    if (model.Activo == 1)
                        listado = listado.Where(x => x.Activo.Equals(true)).ToList();
                    if (model.Activo == 0)
                        listado = listado.Where(x => x.Activo.Equals(false)).ToList();
                    _respuesta.ejecucion = true;
                    _respuesta.datos = listado;
                }
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
                _respuesta = new RespuestaModel();
                _respuesta.ejecucion = true;
                CAT_CONDOMINIOS condominio;
                using (var conex = new DatabaseViviendaEntities())
                {
                    condominio = conex.CAT_CONDOMINIOS.Where(x => x.Id_Condominio.Equals(id)).FirstOrDefault();
                }
                _respuesta.datos = condominio;
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
                List<SelectModel> listadoSelect = new List<SelectModel>();
                _respuesta = new RespuestaModel();
                using (var conex = new DatabaseViviendaEntities())
                {
                    var listado = conex.CAT_CONDOMINIOS.Where(x => x.Activo.Equals(true)).ToList();
                    foreach (var itemlst in listado)
                    {
                        listadoSelect.Add(new SelectModel() { descripcion = itemlst.Condominio, id = itemlst.Id_Condominio });
                    }
                    _respuesta.ejecucion = true;
                    _respuesta.datos = listadoSelect;
                }
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }
        private bool ExisteDB(string nombre)
        {
            int cantidad = 0;
            using (var conex = new DatabaseViviendaEntities())
            {
                cantidad = conex.CAT_CONDOMINIOS.Where(x => x.Condominio.Trim().ToUpper().Equals(nombre.Trim().ToUpper())).Count();
            }
            if (cantidad == 0)
                return false;
            else
                return true;
        }
        private bool ExisteDB(CAT_CONDOMINIOS model)
        {
            int cantidad = 0;
            using (var conex = new DatabaseViviendaEntities())
            {
                cantidad = conex.CAT_CONDOMINIOS.Where(x => x.Condominio.Trim().ToUpper().Equals(model.Condominio.Trim().ToUpper())
                && x.Id_Condominio != model.Id_Condominio).Count();
            }
            if (cantidad == 0)
                return false;
            else
                return true;
        }
    }
}