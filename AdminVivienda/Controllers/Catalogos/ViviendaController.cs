using AdminVivienda.BL;
using AdminVivienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda.Controllers.Catalogos
{
    public class ViviendaController : Controller
    {
        // GET: Vivienda
        public ActionResult Index()
        {
            CondominioBusiness condominioBusiness = new CondominioBusiness();
            List<CondominioModel> condominios = condominioBusiness.Consultar(new CondominioModel() { Activo = -1 }).datos;
            return View(condominios);
        }

        // GET: Vivienda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vivienda/Create
        public ActionResult Create()
        {
            return View();
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
