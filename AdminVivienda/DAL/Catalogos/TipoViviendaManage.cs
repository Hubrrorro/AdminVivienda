using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.DAL.Catalogos
{
    public class TipoViviendaManage : Interface.IGeneralManage<CAT_TIPOVIVIENDA>
    {
        public void Actualizar(CAT_TIPOVIVIENDA modelo)
        {
            using (var conex = new AdminEntities1())
            {
                var condominio = conex.CAT_TIPOVIVIENDA.Where(x => x.Id_TipoVivienda.Equals(modelo.Id_TipoVivienda)).FirstOrDefault();
                condominio.Activo = modelo.Activo;
                condominio.TipoVivienda = modelo.TipoVivienda;
                conex.SaveChanges();
            }
        }

        public void Agregar(CAT_TIPOVIVIENDA modelo)
        {
            using (var conex = new AdminEntities1())
            {
                conex.CAT_TIPOVIVIENDA.Add(modelo);
                conex.SaveChanges();
            }
        }

        public List<CAT_TIPOVIVIENDA> Consultar()
        {
            using (var conex = new AdminEntities1())
            {
                return conex.CAT_TIPOVIVIENDA.ToList();
            }
        }

        public CAT_TIPOVIVIENDA ConsultarId(int id)
        {
            using (var conex = new AdminEntities1())
            {
                return conex.CAT_TIPOVIVIENDA.Where(x => x.Id_TipoVivienda.Equals(id)).FirstOrDefault();
            }
        }

        public bool Existe(string nombre)
        {
            bool resultado = false;
            int intExiste = 0;
            using (var conex = new AdminEntities1()) {
                intExiste = conex.CAT_TIPOVIVIENDA.Where(x => x.TipoVivienda.Equals(nombre)).Count();
            }
            if (intExiste > 0)
                resultado = true;
            return resultado;

        }

        public bool Existe(CAT_TIPOVIVIENDA modelo)
        {
            bool resultado = false;
            int intExiste = 0;
            using (var conex = new AdminEntities1())
            {
                intExiste = conex.CAT_TIPOVIVIENDA.Where(x => x.TipoVivienda.Equals(modelo.TipoVivienda) && 
                x.Id_TipoVivienda != modelo.Id_TipoVivienda).Count();
            }
            if (intExiste > 0)
                resultado = true;
            return resultado;
        }
    }
}