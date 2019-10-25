using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace AdminVivienda.DAL.Catalogos
{
    public class CondominioManage
    {
        public void Agregar(CAT_CONDOMINIO model)
        {
            using (var conex = new AdminEntities1())
            {
                conex.CAT_CONDOMINIO.Add(model);
                conex.SaveChanges();
            }
        }
        public void Actualizar(CAT_CONDOMINIO model)
        {
            using (var conex = new AdminEntities1())
            {
                var condominio = conex.CAT_CONDOMINIO.Where(x => x.Id_Condominio.Equals(model.Id_Condominio)).FirstOrDefault();
                condominio.Activo = model.Activo;
                condominio.Condominio = model.Condominio;
                conex.SaveChanges();
            }
        }
        public List<CAT_CONDOMINIO> ObtenerTodo() {
            List<CAT_CONDOMINIO> listado;
            using (var conex = new AdminEntities1())
            {
                listado = conex.CAT_CONDOMINIO.ToList();
            }
            return listado;
        }
        public CAT_CONDOMINIO ObtenerPorId(int id)
        {
            CAT_CONDOMINIO condominio;
            using (var conex = new AdminEntities1())
            {
                condominio = conex.CAT_CONDOMINIO.Where(x => x.Id_Condominio.Equals(id)).FirstOrDefault();
            }
            return condominio;
        }
        public bool Existe(string nombre)
        {
            int cantidad = 0;
            using (var conex = new AdminEntities1())
            {
                cantidad = conex.CAT_CONDOMINIO.Where(x => x.Condominio.Trim().ToUpper().Equals(nombre.Trim().ToUpper())).Count();
            }
            if (cantidad == 0)
                return false;
            else
                return true;
        }
        public bool Existe(CAT_CONDOMINIO model)
        {
            int cantidad = 0;
            using (var conex = new AdminEntities1())
            {
                cantidad = conex.CAT_CONDOMINIO.Where(x => x.Condominio.Trim().ToUpper().Equals(model.Condominio.Trim().ToUpper()) 
                && x.Id_Condominio != model.Id_Condominio).Count();
            }
            if (cantidad == 0)
                return false;
            else
                return true;
        }
    }
}