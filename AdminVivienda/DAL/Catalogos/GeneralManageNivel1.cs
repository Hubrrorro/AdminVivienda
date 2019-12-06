using AdminVivienda.Models.Catalogos.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminVivienda.DAL.Catalogos
{
    public class GeneralManageNivel1
    {
        private string _qry;
        private string _idName;
        private string _columnName;
        private string _tabla;
        public GeneralManageNivel1(string idname, string columnname, string tabla) {
            _idName = idname;
            _columnName = columnname;
            _tabla = tabla;
        }
        public List<Nivel1Model> Consultar(Nivel1Model filtros)
        {
            using (var conex = new AdminEntities1())
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                _qry = "select " + _idName + " AS ID," + _columnName + " AS DESCRIPCION,CAST(ACTIVO AS INT) AS ACTIVO from " + _tabla;

                if (!String.IsNullOrEmpty(filtros.descripcion)) {
                    parametros.Add(new SqlParameter("@DESCRIPCION", filtros.descripcion);
                    _qry += " WHERE " + _columnName + " LIKE %@DESCRIPCION%";
                }
                if (!filtros.id.Equals(0))
                {
                    if (parametros.Count.Equals(0))
                        _qry += " WHERE ";
                    else
                        _qry += " AND ";
                    _qry += _idName + "= @ID";
                    parametros.Add(new SqlParameter("@ID", filtros.id));
                }
                if (!filtros.Equals(-1))
                {
                    if (parametros.Count.Equals(0))
                        _qry += " WHERE ";
                    else
                        _qry += " AND ";
                    _qry +=   "ACTIVO = @ACTIVO";
                    parametros.Add(new SqlParameter("@ACTIVO", filtros.activo));
                }
                if (parametros.Count.Equals(0))
                    return conex.Database.SqlQuery<Nivel1Model>(_qry).ToList();
                else
                    return conex.Database.SqlQuery<Nivel1Model>(_qry, parametros).ToList();
            }
        }
        public void Agregar(Nivel1Model model)
        {
            using (var conex = new AdminEntities1())
            {
                List<SqlParameter> parametros = new List<SqlParameter>() { new SqlParameter("@VALOR", model.descripcion.Trim()) };

                _qry = "INSERT INTO " + _tabla + "(" + _columnName + ", ACTIVO) VALUES (@VALOR,1)"; 
                conex.Database.ExecuteSqlCommand(_qry, parametros);
            }
        }
        public void Editar(Nivel1Model model)
        {
            using (var conex = new AdminEntities1())
            {
                List<SqlParameter> parametros = new List<SqlParameter>() { 
                    new SqlParameter("@VALOR", model.descripcion.Trim()), 
                    new SqlParameter("@ACTIVO",model.activo), 
                    new SqlParameter("@ID", model.id) };

                _qry = "UPDATE " + _tabla + " SET " + _columnName + "=@VALOR, ACTIVO=@ACTIVO WHERE " + _idName + "=@ID";
                conex.Database.ExecuteSqlCommand(_qry, parametros);
            }
        }

    }
}