using AdminVivienda2.DAL;
using AdminVivienda2.Interface;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.BL
{
    public class ContratoBL : IGeneral<TBL_CONTRATOS, ContratoModel>
    {
        private RespuestaModel _respuesta;
        public RespuestaModel Actualizar(TBL_CONTRATOS modelo)
        {
            throw new NotImplementedException();
        }

        public RespuestaModel Agregar(TBL_CONTRATOS modelo)
        {
            _respuesta = new RespuestaModel();
            try
            {
                //if (ExisteDB(model.Condominio))
                //{
                //    _respuesta.ejecucion = false;
                //    _respuesta.mensaje.Add(Resources.Mensajes.MensajeDuplicado);
                //    return _respuesta;
                //}
                using (var conex = new DatabaseViviendaEntities())
                {
                    modelo.Activo = true;
                    conex.TBL_CONTRATOS.Add(modelo);
                    conex.SaveChanges();
                    _respuesta.datos = modelo.Id_Contrato;
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

        public RespuestaModel Consultar(ContratoModel modelo)
        {
            _respuesta = new RespuestaModel();
            try {
                List<TBL_CONTRATOS> listTodo = new List<TBL_CONTRATOS>();
                using (var conex = new DatabaseViviendaEntities())
                {
                    listTodo = conex.TBL_CONTRATOS.ToList();
                }
                if (!modelo.Id_Contrato.Equals(0))
                {
                    listTodo = listTodo.Where(x => x.Id_Contrato.Equals(modelo.Id_Contrato)).ToList();
                }
                if (!modelo.Id_Condominio.Equals(0))
                {
                    listTodo = listTodo.Where(x => x.Id_Condominio.Equals(modelo.Id_Condominio)).ToList();
                }
                _respuesta.ejecucion = true;
                _respuesta.datos = listTodo;
            }
            catch (Exception ex)
            { 
            }
            return listTodo;
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