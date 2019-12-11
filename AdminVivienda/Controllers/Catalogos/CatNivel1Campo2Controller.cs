using AdminVivienda.BL.Catalogos;
using AdminVivienda.Models.Catalogos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda.Controllers.Catalogos
{
    public class CatNivel1Campo2Controller : Controller
    {
        private Nivel1Campo2RecursosModel _nivel1;
        private GeneralNivel1Business _negocio;
        public CatNivel1Campo2Controller(Nivel1Campo2RecursosModel nivel)
        {
            _nivel1 = nivel;
            _negocio = new GeneralNivel1Business("Id_TipoVivienda", "TipoVivienda", "CAT_TIPOVIVIENDA");
        }
        public ActionResult Index()
        {
            return View("~/Views/CatalogosGenerico/Nivel1/Index.cshtml", _nivel1);
        }
        public ActionResult Details(int id)
        {
            ViewBag.isActualizar = true;
            var resul = _negocio.Consultar(new Nivel1Model() { id = id, activo = -1 });
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
    }
}