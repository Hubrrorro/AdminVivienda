using AdminVivienda2.DAL;
using AdminVivienda2.Interface;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.BL
{
    public class ServicioContratoBL : IGeneral<ASOC_CONTRATOS_SERVICIOS, ServiciosContratoModel>
    {
        private RespuestaModel _respuesta;
        public RespuestaModel Actualizar(ASOC_CONTRATOS_SERVICIOS modelo)
        {
            throw new NotImplementedException();
        }

        public RespuestaModel Agregar(ASOC_CONTRATOS_SERVICIOS modelo)
        {
            _respuesta = new RespuestaModel();
            try
            {
                using (var conex = new DatabaseViviendaEntities())
                {
                    modelo.Activo = true;
                    conex.ASOC_CONTRATOS_SERVICIOS.Add(modelo);
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

        public RespuestaModel Consultar(ServiciosContratoModel modelo)
        {
            try
            {
                List<ASOC_CONTRATOS_SERVICIOS> listTodo = new List<ASOC_CONTRATOS_SERVICIOS>();
                using (var conex = new DatabaseViviendaEntities())
                {
                    listTodo = conex.ASOC_CONTRATOS_SERVICIOS.ToList();
                }
                if (!modelo.Id_Servicio.Equals(0))
                    listTodo = listTodo.Where(x => x.Id_Servicio.Equals(modelo.Id_Servicio)).ToList();
                if (!modelo.Id_Contrato.Equals(0))
                    listTodo = listTodo.Where(x => x.Id_Contrato.Equals(modelo.Id_Contrato)).ToList();
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

        public RespuestaModel ConsultarId(int id)
        {
            throw new NotImplementedException();
        }

        public RespuestaModel Select()
        {
            throw new NotImplementedException();
        }
    }
}