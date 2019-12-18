using AdminVivienda.Models.Catalogos.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminVivienda.DAL.Catalogos
{
    public class GeneralManageNivel1Campo2
    {
        private string _qry;
        private string _idName;
        private string _columnName;
        private string _column2Name;
        private string _tabla;
        public GeneralManageNivel1Campo2(string idname, string columnname,string column2name, string tabla)
        {
            _idName = idname;
            _columnName = columnname;
            _tabla = tabla;
            _column2Name = column2name;
        }
        public List<Nivel1Campo2Model> Consultar(Nivel1Campo2Model filtros)
        {
            using (var conex = new AdminEntities1())
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                _qry = "select " + _idName + " AS ID," + _columnName + " AS DESCRIPCION,CAST(ACTIVO AS INT) AS ACTIVO from " + _tabla;

                if (!String.IsNullOrEmpty(filtros.descripcion))
                {
                    parametros.Add(new SqlParameter("@DESCRIPCION", filtros.descripcion));
                    _qry += " WHERE " + _columnName + " LIKE @DESCRIPCION";
                }
                if (!String.IsNullOrEmpty(filtros.campo2))
                {
                    if (parametros.Count.Equals(0))
                        _qry += " WHERE ";
                    else
                        _qry += " AND ";
                    parametros.Add(new SqlParameter("@CAMPO2", filtros.descripcion));
                    _qry +=  _columnName + " LIKE @CAMPO2";
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
                if (!filtros.activo.Equals(-1))
                {
                    if (parametros.Count.Equals(0))
                        _qry += " WHERE ";
                    else
                        _qry += " AND ";
                    _qry += "ACTIVO = @ACTIVO";
                    parametros.Add(new SqlParameter("@ACTIVO", filtros.activo));
                }
                if (parametros.Count.Equals(0))
                    return conex.Database.SqlQuery<Nivel1Campo2Model>(_qry).ToList();
                else
                    return conex.Database.SqlQuery<Nivel1Campo2Model>(_qry, parametros.ToArray()).ToList();
            }
        }
        public void Agregar(Nivel1Campo2Model model)
        {
            using (var conex = new AdminEntities1())
            {
                List<SqlParameter> parametros = new List<SqlParameter>() {
                    new SqlParameter("@VALOR", model.descripcion.Trim()),
                    new SqlParameter("@CAMPO2", model.campo2.Trim())
                };

                _qry = "INSERT INTO " + _tabla + "(" + _columnName + "," + _column2Name + ", ACTIVO) VALUES (@VALOR,@CAMPO2,1)";
                conex.Database.ExecuteSqlCommand(_qry, parametros.ToArray());
            }
        }
        public void Editar(Nivel1Campo2Model model)
        {
            using (var conex = new AdminEntities1())
            {
                List<SqlParameter> parametros = new List<SqlParameter>() {
                    new SqlParameter("@VALOR", model.descripcion.Trim()),
                    new SqlParameter("@CAMPO2", model.descripcion.Trim()),
                    new SqlParameter("@ACTIVO",model.activo),
                    new SqlParameter("@ID", model.id) };

                _qry = "UPDATE " + _tabla + " SET " + _columnName + "=@VALOR," + _column2Name + "=@CAMPO2, ACTIVO=@ACTIVO WHERE " + _idName + "=@ID";
                conex.Database.ExecuteSqlCommand(_qry, parametros.ToArray());
            }
        }

    }
}