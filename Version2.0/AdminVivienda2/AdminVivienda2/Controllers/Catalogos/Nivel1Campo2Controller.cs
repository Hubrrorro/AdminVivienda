using AdminVivienda2.BL;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda2.Controllers.Catalogos
{
    public class Nivel1Campo2Controller : Controller
    {
        private Nivel1Campo2Model _nivel;
        private Nivel1Campo2BL _nivel1BL;
        public Nivel1Campo2Controller(Nivel1Campo2Model nivel)
        {
            _nivel = nivel;
            _nivel1BL = new Nivel1Campo2BL(nivel);
        }

        // GET: Nivel1Campo1
        public ActionResult Index()
        {
            return View("~/Views/Nivel1Campo2/Index.cshtml", _nivel);
        }
        public ActionResult Details(int id)
        {
            ViewBag.isActualizar = true;
            var resul = _nivel1BL.Consultar(new Nivel1_2Model() { id = id, activo = -1 });
            _nivel.datosC2 = resul.datos;
            return View("~/Views/Nivel1Campo2/Registro.cshtml", _nivel);
        }
        public ActionResult Create()
        {
            ViewBag.isActualizar = false;
            return View("~/Views/Nivel1Campo2/Registro.cshtml", _nivel);
        }
        public PartialViewResult Grid(Nivel1_2Model modelo)
        {
            var resul = _nivel1BL.Consultar(modelo);
            _nivel.datosC2 = resul.datos;
            return PartialView("~/Views/Nivel1Campo2/Grid.cshtml", _nivel);
        }
        [HttpPost]
        public ActionResult Create(Nivel1_2Model modelo)
        {
            var resul = _nivel1BL.Agregar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Edit(Nivel1_2Model modelo)
        {
            var resul = _nivel1BL.Actualizar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Select()
        {
            var resul = _nivel1BL.Consultar(new Nivel1_2Model() { activo = 1 });
            return Json(resul);
        }

    }
}