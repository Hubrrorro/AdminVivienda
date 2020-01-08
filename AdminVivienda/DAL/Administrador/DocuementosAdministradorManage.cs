using AdminVivienda.Interface;
using AdminVivienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.DAL.Administrador
{
    public class DocuementosAdministradorManage : IGeneralManage<Tbl_DocumentosCondominio>
    {
        public void Actualizar(Tbl_DocumentosCondominio modelo)
        {
            using (var conex = new AdminEntities1())
            {
                var documento = conex.Tbl_DocumentosCondominio.Where(x => x.Id_DocumentoCondominio.Equals(modelo.Id_DocumentoCondominio)).FirstOrDefault();
                //condominio = model;
                documento.Activo = modelo.Activo;
                documento.Descripcion = modelo.Descripcion;
                documento.Id_Condominio = modelo.Id_Condominio;
                documento.Id_TipoDocumento = modelo.Id_TipoDocumento;
                documento.Ruta = modelo.Ruta;
                conex.SaveChanges();
            }
        }

        public void Agregar(Tbl_DocumentosCondominio modelo)
        {
            using (var conex = new AdminEntities1())
            {
                modelo.Activo = true;
                conex.Tbl_DocumentosCondominio.Add(modelo);
                conex.SaveChanges();
            }
        }

        public List<Tbl_DocumentosCondominio> Consultar()
        {
            List<Tbl_DocumentosCondominio> listado;
            using (var conex = new AdminEntities1())
            {
                listado = conex.Tbl_DocumentosCondominio.ToList();
            }
            return listado;
        }

        public Tbl_DocumentosCondominio ConsultarId(int id)
        {
            Tbl_DocumentosCondominio documento;
            using (var conex = new AdminEntities1())
            {
                documento = conex.Tbl_DocumentosCondominio.Where(x => x.Id_DocumentoCondominio.Equals(id)).FirstOrDefault();
            }
            return documento;
        }

        public bool Existe(string nombre)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Tbl_DocumentosCondominio modelo)
        {
            throw new NotImplementedException();
        }
    }
}