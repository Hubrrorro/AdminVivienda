using AdminVivienda2.DAL;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminVivienda2.BL
{
    public class Nivel1Campo1BL
    {
        private RespuestaModel _respuesta;
        private Nivel1Campo1Model _nivel;
        private string _qry;
        public Nivel1Campo1BL(Nivel1Campo1Model nivel)
        {
            _respuesta = new RespuestaModel();
            _nivel = nivel;
        }
        public RespuestaModel Consultar(Nivel1Model modelo)
        {
            try
            {
                
                using (var conex = new DatabaseViviendaEntities())
                {
                    List<SqlParameter> parametros = new List<SqlParameter>();
                    _qry = "select " + _nivel.tabla.idNombre + " AS ID," + _nivel.tabla.descripcion + " AS DESCRIPCION,CAST(ACTIVO AS INT) AS ACTIVO from " + _nivel.tabla.nombreTabla;

                    if (!String.IsNullOrEmpty(modelo.descripcion))
                    {
                        parametros.Add(new SqlParameter("@DESCRIPCION", modelo.descripcion));
                        _qry += " WHERE " + _nivel.tabla.descripcion + " LIKE @DESCRIPCION";
                    }
                    if (!modelo.id.Equals(0))
                    {
                        if (parametros.Count.Equals(0))
                            _qry += " WHERE ";
                        else
                            _qry += " AND ";
                        _qry += _nivel.tabla.idNombre + "= @ID";
                        parametros.Add(new SqlParameter("@ID", modelo.id));
                    }
                    if (!modelo.activo.Equals(-1))
                    {
                        if (parametros.Count.Equals(0))
                            _qry += " WHERE ";
                        else
                            _qry += " AND ";
                        _qry += "ACTIVO = @ACTIVO";
                        parametros.Add(new SqlParameter("@ACTIVO", modelo.activo));
                    }
                    if (parametros.Count.Equals(0))
                    {
                        _respuesta.ejecucion = true;
                        _respuesta.datos = conex.Database.SqlQuery<Nivel1Model>(_qry).ToList();
                    }
                    else
                    {
                        _respuesta.ejecucion = true;
                        _respuesta.datos = conex.Database.SqlQuery<Nivel1Model>(_qry, parametros.ToArray()).ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(ex.Message);
            }
            return _respuesta;
        }
        public RespuestaModel Agregar(Nivel1Model modelo)
        {
            try
            {
                if (String.IsNullOrEmpty(modelo.descripcion))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add("Dato requerido");
                    return _respuesta;
                }
                var listado = (List<Nivel1Model>)Consultar(new Nivel1Model() { activo = -1, id = 0 }).datos;
                int intExiste = listado.Where(x => x.descripcion.Trim().ToUpper().Equals(modelo.descripcion.Trim().ToUpper())).Count();
                if (intExiste > 0)
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add("El dato que deseas ingresar ya se encuentra registrado");
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    //List<SqlParameter> parametros = new List<SqlParameter>() { new SqlParameter("@VALOR", model.descripcion.Trim()) };

                    _qry = "INSERT INTO " + _nivel.tabla.nombreTabla + "(" + _nivel.tabla.descripcion + ", ACTIVO) VALUES (@VALOR,1)";
                    conex.Database.ExecuteSqlCommand(_qry, new SqlParameter("@VALOR", modelo.descripcion.Trim()));
                }
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
        public RespuestaModel Actualizar(Nivel1Model modelo)
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
                var listado = (List<Nivel1Model>)Consultar(modelo).datos;
                int intExiste = listado.Where(x => x.descripcion.Trim().ToUpper().Equals(modelo.descripcion.Trim().ToUpper()) && !x.id.Equals(modelo.id)).Count();
                if (intExiste > 0)
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add("El dato que deseas modificar ya se encuentra registrado");
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    List<SqlParameter> parametros = new List<SqlParameter>() {
                    new SqlParameter("@VALOR", modelo.descripcion.Trim()),
                    new SqlParameter("@ACTIVO",modelo.activo),
                    new SqlParameter("@ID", modelo.id) };

                    _qry = "UPDATE " + _nivel.tabla.nombreTabla + " SET " + _nivel.tabla.descripcion + "=@VALOR, ACTIVO=@ACTIVO WHERE " + _nivel.tabla.idNombre + "=@ID";
                    conex.Database.ExecuteSqlCommand(_qry, parametros.ToArray());
                }
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