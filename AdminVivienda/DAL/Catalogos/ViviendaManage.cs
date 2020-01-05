using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.DAL.Catalogos
{
    public class ViviendaManage : Interface.IGeneralManage<CAT_VIVIENDA>
    {
        public void Actualizar(CAT_VIVIENDA modelo)
        {
            using (var conex = new AdminEntities1())
            {
                var registro = conex.CAT_VIVIENDA.Where(x => x.Id_Vivienda.Equals(modelo.Id_Vivienda)).FirstOrDefault();
                registro.Activo = modelo.Activo;
                registro.Calle = modelo.Calle;
                registro.id_Condominio = modelo.id_Condominio;
                registro.id_Propietario = modelo.id_Propietario;
                registro.id_TipoVivienda = modelo.id_TipoVivienda;
                registro.Lote = modelo.Lote;
                registro.NumExt = modelo.NumExt;
                registro.NumInt = modelo.NumInt;
                registro.Vivienda = modelo.Vivienda;
                conex.SaveChanges();
            }
        }

        public void Agregar(CAT_VIVIENDA modelo)
        {
            using (var conex = new AdminEntities1())
            {
                modelo.Activo = true;
                conex.CAT_VIVIENDA.Add(modelo);
                conex.SaveChanges();
            }
        }

        public List<CAT_VIVIENDA> Consultar()
        {
            using (var conex = new AdminEntities1())
            {
                
                return conex.CAT_VIVIENDA.ToList();
            }
        }

        public CAT_VIVIENDA ConsultarId(int id)
        {
            using (var conex = new AdminEntities1())
            {
                return conex.CAT_VIVIENDA.Where(x => x.Id_Vivienda.Equals(id)).FirstOrDefault();
            }
        }

        public bool Existe(string nombre)
        {
            bool resultado = false;
            int intExiste = 0;
            using (var conex = new AdminEntities1())
            {
                intExiste = conex.CAT_VIVIENDA.Where(x => x.Vivienda.Equals(nombre)).Count();
            }
            if (intExiste > 0)
                resultado = true;
            return resultado;

        }

        public bool Existe(CAT_VIVIENDA modelo)
        {
            bool resultado = false;
            int intExiste = 0;
            using (var conex = new AdminEntities1())
            {
                intExiste = conex.CAT_VIVIENDA.Where(x => x.Vivienda.Equals(modelo.Vivienda) &&
                x.Id_Vivienda != modelo.Id_Vivienda).Count();
            }
            if (intExiste > 0)
                resultado = true;
            return resultado;
        }
    }
}