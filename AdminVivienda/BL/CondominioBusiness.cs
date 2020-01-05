using AdminVivienda.Controllers.Catalogos;
using AdminVivienda.DAL;
using AdminVivienda.DAL.Catalogos;
using AdminVivienda.Interface;
using AdminVivienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminVivienda.Models.Catalogos;
namespace AdminVivienda.BL
{
    public class CondominioBusiness : IGeneralBusiness<CondominioModel>
    {
        private RespuestaModel _respuesta;
        private IGeneralManage<CAT_CONDOMINIO> _manage;
        public CondominioBusiness()
        {
            _respuesta = new RespuestaModel();
            _manage = new CondominioManage();
        }
        private CAT_CONDOMINIO Transformar(CondominioModel model) {
            CAT_CONDOMINIO condominio = new CAT_CONDOMINIO();
            condominio.Condominio = model.Condominio.Trim();
            condominio.Activo = model.Activo == 1 ? true : false;
            condominio.Id_Condominio = model.id_Condominio;
            condominio.Clave = model.Clave;
            condominio.Colonia = model.Colonia;
            condominio.Cp = model.CP;
            condominio.DemMun = model.DemMun;
            condominio.Id_Estado = model.id_Estado;
            return condominio;
        }
        private void RevisarCamposObligatorios(CAT_CONDOMINIO model)
        {
            _respuesta.ejecucion = true;
            if (String.IsNullOrEmpty(model.Condominio))
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Mensajes.CampoRequerido);
            }

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
        public RespuestaModel Select() {
            try
            {
                var listTodo = _manage.Consultar();
                listTodo = listTodo.Where(x => x.Activo.Equals(true)).ToList();
                List<SelectModel> listSelect = new List<SelectModel>();
                foreach (var registro in listTodo)
                {
                    listSelect.Add(new SelectModel()
                    {
                        descripcion = registro.Condominio,
                        id = registro.Id_Condominio
                    }) ;
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
        public RespuestaModel Consultar(CondominioModel model) {
            try
            {
                var listTodo = _manage.Consultar();
                if (!String.IsNullOrEmpty(model.Condominio))
                    listTodo = listTodo.Where(x => x.Condominio.Contains(model.Condominio)).ToList();
                if (model.Activo == 1)
                    listTodo = listTodo.Where(x => x.Activo.Equals(true)).ToList();
                if (model.Activo == 0)
                    listTodo = listTodo.Where(x => x.Activo.Equals(false)).ToList();
                //List<CondominioModel> listado = new List<CondominioModel>();
                //foreach (var condominio in listTodo)
                //{
                //    listado.Add(new CondominioModel() { Activo = condominio.Activo ? 1 : 0, Condominio = condominio.Condominio,
                //        id_Condominio = condominio.Id_Condominio, Clave = condominio.Clave, Colonia = condominio.Colonia, DemMun = condominio.DemMun,
                //     CP = condominio.Cp.Value
                //    });
                //}
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