using AdminVivienda.BL;
using AdminVivienda.BL.Catalogos;
using AdminVivienda.Models;
using AdminVivienda.Models.Vivienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda.Controllers.Catalogos
{
    public class ViviendaController : Controller
    {
        ViviendaBusiness _viviendaB;
        // GET: Vivienda
        public ViviendaController()
        {
            _viviendaB = new ViviendaBusiness();
        }
        public ActionResult Index()
        {
            CondominioBusiness condominioBusiness = new CondominioBusiness();
            List<DAL.CAT_CONDOMINIO> condominios = condominioBusiness.Consultar(new CondominioModel() { Activo = 1 }).datos;
            return View(condominios);
        }
        public PartialViewResult Grid(ViviendaModel model)
        {
            
            var listVivienda= _viviendaB.Consultar(model);
            return PartialView("~/Views/Vivienda/ViviendaGrid.cshtml", listVivienda.datos);
        }
        // GET: Vivienda/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Modificar Vivienda";
            var vivienda = _viviendaB.ConsultarId(id);
            return View("~/Views/Vivienda/Vivienda.cshtml", vivienda.datos);
        }

        // GET: Vivienda/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Agregar Vivienda";
            AdminVivienda.DAL.CAT_PERSONAS persona = new DAL.CAT_PERSONAS() {  ApeMat="", ApePat= "", Contacto1= "", Contacto2= "", Correo="", Nombre=""};
            AdminVivienda.DAL.CAT_VIVIENDA vivienda = new DAL.CAT_VIVIENDA() { Calle = "",  Lote= "", NumExt= "", NumInt= "", Vivienda= "", CAT_PERSONAS=persona};
            return View("~/Views/Vivienda/Vivienda.cshtml", vivienda);
        }

        // POST: Vivienda/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vivienda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vivienda/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vivienda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vivienda/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
