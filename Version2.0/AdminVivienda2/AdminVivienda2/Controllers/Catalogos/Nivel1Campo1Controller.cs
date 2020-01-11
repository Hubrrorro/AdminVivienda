using AdminVivienda2.BL;
using AdminVivienda2.DAL;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda2.Controllers.Catalogos
{
    public class Nivel1Campo1Controller : Controller
    {
        private Nivel1Campo1Model _nivel;
        private Nivel1Campo1BL _nivel1BL;
        public Nivel1Campo1Controller(Nivel1Campo1Model nivel)
        {
            _nivel = nivel;
            _nivel1BL = new Nivel1Campo1BL(nivel);
        }

        // GET: Nivel1Campo1
        public ActionResult Index()
        {
            return View("~/Views/Nivel1Campo1/Index.cshtml", _nivel);
        }
        public ActionResult Details(int id)
        {
            ViewBag.isActualizar = true;
            var resul = _nivel1BL.Consultar(new Nivel1Model() { id = id, activo = -1 });
            _nivel.datos = resul.datos;
            return View("~/Views/Nivel1Campo1/Registro.cshtml", _nivel);
        }
        public ActionResult Create()
        {
            ViewBag.isActualizar = false;
            return View("~/Views/Nivel1Campo1/Registro.cshtml", _nivel);
        }
        public PartialViewResult Grid(Nivel1Model modelo)
        {
            var resul = _nivel1BL.Consultar(modelo);
            _nivel.datos = resul.datos;
            return PartialView("~/Views/Nivel1Campo1/Grid.cshtml", _nivel);
        }
        [HttpPost]
        public ActionResult Create(Nivel1Model modelo)
        {
            var resul = _nivel1BL.Agregar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Edit(Nivel1Model modelo)
        {
            var resul = _nivel1BL.Actualizar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Select()
        {
            var resul = _nivel1BL.Consultar(new Nivel1Model() { activo = 1 });
            return Json(resul);
        }

    }
}