using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.DAL.Catalogos
{
    public class PersonalManage : Interface.IGeneralManage<CAT_PERSONAS>
    {
        public void Agregar(CAT_PERSONAS model)
        {
            using (var conex = new AdminEntities1())
            {
                model.Activo = true;
                conex.CAT_PERSONAS.Add(model);
                conex.SaveChanges();
            }
        }
        public void Actualizar(CAT_PERSONAS model)
        {
            using (var conex = new AdminEntities1())
            {
                var objBd = conex.CAT_PERSONAS.Where(x => x.Id_Persona.Equals(model.Id_Persona)).FirstOrDefault();
                objBd = model;
                conex.SaveChanges();
            }
        }
        public List<CAT_PERSONAS> Consultar()
        {
            List<CAT_PERSONAS> listado;
            using (var conex = new AdminEntities1())
            {
                listado = conex.CAT_PERSONAS.ToList();
            }
            return listado;
        }
        public CAT_PERSONAS ConsultarId(int id)
        {
            CAT_PERSONAS objBd;
            using (var conex = new AdminEntities1())
            {
                objBd = conex.CAT_PERSONAS.Where(x => x.Id_Persona.Equals(id)).FirstOrDefault();
            }
            return objBd;
        }
        public bool Existe(string nombre)
        {
            int cantidad = 0;
            using (var conex = new AdminEntities1())
            {
                cantidad = conex.CAT_PERSONAS.Where(x => x.Nombre.Trim().ToUpper().Equals(nombre.Trim().ToUpper())).Count();
            }
            if (cantidad == 0)
                return false;
            else
                return true;
        }
        public bool Existe(CAT_PERSONAS model)
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