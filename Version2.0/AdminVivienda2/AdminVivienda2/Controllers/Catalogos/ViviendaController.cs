using AdminVivienda2.BL;
using AdminVivienda2.DAL;
using AdminVivienda2.Interface;
using AdminVivienda2.Models;
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
        private IGeneral<CAT_VIVIENDAS, ViviendaModel> viviendaBL;
        public ViviendaController()
        {
            viviendaBL = new ViviendaBL();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Buscar Vivienda";
            return View();
        }
        public PartialViewResult Grid(ViviendaModel model)
        {

            var listVivienda = viviendaBL.Consultar(model);
            return PartialView("~/Views/Vivienda/ViviendaGrid.cshtml", listVivienda.datos);
        }
        // GET: Vivienda/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Actualizar Vivienda";
            ViewBag.Accion = "Actualizar";
            var viviendaresp = viviendaBL.ConsultarId(id);
            CAT_VIVIENDAS vivienda = (CAT_VIVIENDAS)viviendaresp.datos;
            //PersonalBusiness personalB = new PersonalBusiness();
            //vivienda.CAT_PERSONAS = (AdminVivienda.DAL.CAT_PERSONAS)personalB.ConsultarId(vivienda.id_Propietario.Value).datos;
            return View("~/Views/Vivienda/Vivienda.cshtml", vivienda);
        }

        // GET: Vivienda/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Agregar Vivienda";
            ViewBag.Accion = "Agregar";
            CAT_PERSONAS persona = new CAT_PERSONAS() { ApeMat = "", ApePat = "", Contacto1 = "", Contacto2 = "", Correo = "", Nombre = "" };
            CAT_VIVIENDAS vivienda = new CAT_VIVIENDAS() { Calle = "", Lote = "", NumExt = "", NumInt = "", Vivienda = "", CAT_PERSONAS = persona };
            return View("~/Views/Vivienda/Vivienda.cshtml", vivienda);
        }

        // POST: Vivienda/Create
        [HttpPost]
        public ActionResult Create(CAT_VIVIENDAS modelo)
        {
            var resul = viviendaBL.Agregar(modelo);
            return Json(resul);
        }

        [HttpPost]
        public ActionResult Edit(CAT_VIVIENDAS modelo)
        {
            var resul = viviendaBL.Actualizar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Select()
        {
            var resul = viviendaBL.Consultar(new ViviendaModel() { Activo = 1 });
            return Json(resul);
        }
    }
}