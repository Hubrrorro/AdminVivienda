using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminVivienda.BL.Catalogos;
using AdminVivienda.Models.Catalogos.General;
namespace AdminVivienda.Controllers.Catalogos
{
    public class CatalogoNivel1Controller : Controller
    {
        // GET: CatalogoNivel1
        private Nivel1RecursosModel _nivel1;
        private GeneralNivel1Business _negocio;
        public CatalogoNivel1Controller(Nivel1RecursosModel nivel)
        {
            _nivel1 = nivel;
            _negocio = new GeneralNivel1Business(nivel.tabla.idNombre,nivel.tabla.descripcion,nivel.tabla.nombreTabla);
            
        }
        public ActionResult Index()
        {
            return View("~/Views/CatalogosGenerico/Nivel1/Index.cshtml", _nivel1);
        }
        public ActionResult Details(int id)
        {
            ViewBag.isActualizar = true;
            var resul = _negocio.Consultar(new Nivel1Model() { id = id, activo= -1 });
            _nivel1.datos = resul.datos;
            return View("~/Views/CatalogosGenerico/Nivel1/Registro.cshtml", _nivel1);
        }
        public ActionResult Create()
        {
            ViewBag.isActualizar = false;
            return View("~/Views/CatalogosGenerico/Nivel1/Registro.cshtml", _nivel1);
        }
        public PartialViewResult Grid(Nivel1Model modelo)
        {
            var resul = _negocio.Consultar(modelo);
            _nivel1.datos = resul.datos;
            return PartialView("~/Views/CatalogosGenerico/Nivel1/Grid.cshtml", _nivel1);
        }
        [HttpPost]
        public ActionResult Create(Nivel1Model modelo)
        {
            var resul = _negocio.Agregar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Edit(Nivel1Model modelo)
        {
            var resul = _negocio.Actualizar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Select()
        {
            var resul = _negocio.Consultar(new Nivel1Model() { activo = 1 });
            return Json(resul);
        }
    }
}