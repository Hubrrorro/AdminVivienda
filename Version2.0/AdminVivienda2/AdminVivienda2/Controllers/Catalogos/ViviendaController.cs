using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda2.Controllers.Catalogos
{
    public class ViviendaController : Controller
    {
        // GET: Vivienda
        public ViviendaController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Grid(ViviendaModel model)
        {

            var listVivienda = _viviendaB.Consultar(model);
            return PartialView("~/Views/Vivienda/ViviendaGrid.cshtml", listVivienda.datos);
        }
        // GET: Vivienda/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Actualizar Vivienda";
            ViewBag.Accion = "Actualizar";
            var viviendaresp = _viviendaB.ConsultarId(id);
            AdminVivienda.DAL.CAT_VIVIENDA vivienda = (DAL.CAT_VIVIENDA)viviendaresp.datos;
            PersonalBusiness personalB = new PersonalBusiness();
            vivienda.CAT_PERSONAS = (AdminVivienda.DAL.CAT_PERSONAS)personalB.ConsultarId(vivienda.id_Propietario.Value).datos;
            return View("~/Views/Vivienda/Vivienda.cshtml", vivienda);
        }

        // GET: Vivienda/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Agregar Vivienda";
            ViewBag.Accion = "Agregar";
            AdminVivienda.DAL.CAT_PERSONAS persona = new DAL.CAT_PERSONAS() { ApeMat = "", ApePat = "", Contacto1 = "", Contacto2 = "", Correo = "", Nombre = "" };
            AdminVivienda.DAL.CAT_VIVIENDA vivienda = new DAL.CAT_VIVIENDA() { Calle = "", Lote = "", NumExt = "", NumInt = "", Vivienda = "", CAT_PERSONAS = persona };
            return View("~/Views/Vivienda/Vivienda.cshtml", vivienda);
        }

        // POST: Vivienda/Create
        [HttpPost]
        public ActionResult Create(ViviendaModel modelo)
        {
            var resul = _viviendaB.Agregar(modelo);
            return Json(resul);
        }

        [HttpPost]
        public ActionResult Edit(ViviendaModel modelo)
        {
            var resul = _viviendaB.Actualizar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Select()
        {
            var resul = _viviendaB.Select();
            return Json(resul);
        }
    }
}