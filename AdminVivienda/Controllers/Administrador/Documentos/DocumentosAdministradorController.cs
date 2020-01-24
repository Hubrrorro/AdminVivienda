using AdminVivienda.BL;
using AdminVivienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda.Controllers.Administrador.Documentos
{
    public class DocumentosAdministradorController : Controller
    {
        // GET: DocumentosAdministrador
        private CondominioBusiness _condominioBusiness;
        public ActionResult Index()
        {
            _condominioBusiness = new CondominioBusiness();
            List<DAL.CAT_CONDOMINIO> condominios = _condominioBusiness.Consultar(new CondominioModel() { Activo = 1 }).datos;
            return View(condominios);
        }
        public PartialViewResult Grid(DocumentosAdministradorModel model)
        {
            //var listVivienda = _condominioBusiness.Consultar(model);
            return PartialView("~/Views/Vivienda/ViviendaGrid.cshtml");
        }
        //public ActionResult Details(int id)
        //{
        //}
        //public ActionResult Create()
        //{ }
        //[HttpPost]
        //public ActionResult Create(ViviendaModel modelo)
        //{
        //}
        //[HttpPost]
        //public ActionResult Edit(ViviendaModel modelo)
        //{
        //}
        //[HttpPost]
        //public ActionResult Select()
        //{
        //}
    }
}