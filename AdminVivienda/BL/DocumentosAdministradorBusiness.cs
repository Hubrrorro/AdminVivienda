using AdminVivienda.DAL;
using AdminVivienda.DAL.Administrador;
using AdminVivienda.Interface;
using AdminVivienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.BL
{
    public class DocumentosAdministradorBusiness : IGeneralBusiness<Tbl_DocumentosCondominio>
    {
        private RespuestaModel _respuesta;
        private IGeneralManage<Tbl_DocumentosCondominio> _manage;
        public DocumentosAdministradorBusiness()
        {
            _respuesta = new RespuestaModel();
            _manage = new DocuementosAdministradorManage();
        }
        private Tbl_DocumentosCondominio Transformar(DocumentosAdministradorModel model)
        {
            Tbl_DocumentosCondominio docCondominio = new Tbl_DocumentosCondominio();
            docCondominio.Activo = model.Activo.Equals(1) ? true : false;
            docCondominio.Descripcion = model.Descripcion;
            docCondominio.DocumentoCondominio = model.Documento;
            docCondominio.FechaSubida = model.Fecha;
            docCondominio.Id_Condominio = model.Id_Condominio;
            docCondominio.Id_DocumentoCondominio = model.Id_Documento;
            docCondominio.Id_TipoDocumento = model.Id_TipoDocumento;
            docCondominio.Ruta = model.Ruta;
            return docCondominio;
        }
        public RespuestaModel Actualizar(Tbl_DocumentosCondominio modelo)
        {
            throw new NotImplementedException();
        }

        public RespuestaModel Agregar(Tbl_DocumentosCondominio modelo)
        {
            throw new NotImplementedException();
        }

        public RespuestaModel Consultar(Tbl_DocumentosCondominio modelo)
        {
            throw new NotImplementedException();
        }

        public RespuestaModel ConsultarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}