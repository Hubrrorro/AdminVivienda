using AdminVivienda2.DAL;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminVivienda2.BL
{
    public class Nivel1Campo2BL
    {
        private RespuestaModel _respuesta;
        private Nivel1Campo2Model _nivel;
        private string _qry;
        public Nivel1Campo2BL(Nivel1Campo2Model nivel)
        {
            _respuesta = new RespuestaModel();
            _nivel = nivel;
        }
        public RespuestaModel Consultar(Nivel1_2Model modelo)
        {
            try
            {

                using (var conex = new DatabaseViviendaEntities())
                {
                    List<SqlParameter> parametros = new List<SqlParameter>();
                    _qry = "select " + _nivel.tablaC2.idNombre + " AS ID," + _nivel.tablaC2.descripcion + " AS DESCRIPCION," + _nivel.tablaC2.descripcion2 + " AS DESCRIPCION2,CAST(ACTIVO AS INT) AS ACTIVO from " + _nivel.tablaC2.nombreTabla;

                    if (!String.IsNullOrEmpty(modelo.descripcion))
                    {
                        parametros.Add(new SqlParameter("@DESCRIPCION", modelo.descripcion));
                        _qry += " WHERE " + _nivel.tablaC2.descripcion + " LIKE @DESCRIPCION";
                    }
                    if (!modelo.id.Equals(0))
                    {
                        if (parametros.Count.Equals(0))
                            _qry += " WHERE ";
                        else
                            _qry += " AND ";
                        _qry += _nivel.tablaC2.idNombre + "= @ID";
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
                        _respuesta.datos = conex.Database.SqlQuery<Nivel1_2Model>(_qry).ToList();
                    }
                    else
                    {
                        _respuesta.ejecucion = true;
                        _respuesta.datos = conex.Database.SqlQuery<Nivel1_2Model>(_qry, parametros.ToArray()).ToList();
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
        public RespuestaModel Agregar(Nivel1_2Model modelo)
        {
            try
            {
                if (String.IsNullOrEmpty(modelo.descripcion))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add("Dato requerido");
                    return _respuesta;
                }
                var listado = (List<Nivel1_2Model>)Consultar(new Nivel1_2Model() { activo = -1, id = 0 }).datos;
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

                    _qry = "INSERT INTO " + _nivel.tablaC2.nombreTabla + "(" + _nivel.tablaC2.descripcion + "," + _nivel.tablaC2.descripcion2 + ", ACTIVO) VALUES (@VALOR,@VALOR2,1)";
                    conex.Database.ExecuteSqlCommand(_qry, new SqlParameter("@VALOR", modelo.descripcion.Trim()));
                    conex.Database.ExecuteSqlCommand(_qry, new SqlParameter("@VALOR2", modelo.descripcion2.Trim()));
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
        public RespuestaModel Actualizar(Nivel1_2Model modelo)
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
                var listado = (List<Nivel1_2Model>)Consultar(modelo).datos;
                int intExiste = listado.Where(x => x.descripcion.Trim().ToUpper().Equals(modelo.descripcion.Trim().ToUpper()) && !x.id.Equals(modelo.id) && x.descripcion2.Trim().ToUpper().Equals(modelo.descripcion2.Trim().ToUpper())).Count();
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
                    new SqlParameter("@VALOR2", modelo.descripcion2.Trim()),
                    new SqlParameter("@ACTIVO",modelo.activo),
                    new SqlParameter("@ID", modelo.id) };

                    _qry = "UPDATE " + _nivel.tablaC2.nombreTabla + " SET " + _nivel.tablaC2.descripcion + "=@VALOR," + _nivel.tablaC2.descripcion2 + "=@VALOR2, ACTIVO=@ACTIVO WHERE " + _nivel.tablaC2.idNombre + "=@ID";
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