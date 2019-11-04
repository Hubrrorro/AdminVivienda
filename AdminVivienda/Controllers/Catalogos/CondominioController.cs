using AdminVivienda.BL;
using AdminVivienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda.Controllers.Catalogos
{
    public class CondominioController : Controller
    {
        private CondominioBusiness _condominioBusiness;
        public CondominioController()
        {
            _condominioBusiness = new CondominioBusiness();
        }
        // GET: Condominio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Condominio/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Accion = "Actualizar";
            var resul = _condominioBusiness.ObtenerPorID(id);
            return View("~/Views/Condominio/Condominio.cshtml",(AdminVivienda.DAL.CAT_CONDOMINIO)resul.datos);
        }

        // GET: Condominio/Create
        public ActionResult Create()
        {
            ViewBag.Accion = "Agregar";
            AdminVivienda.DAL.CAT_CONDOMINIO condominio = new DAL.CAT_CONDOMINIO();
            return View("~/Views/Condominio/Condominio.cshtml", condominio);
        }
        public PartialViewResult Grid(CondominioModel modelo)
        {
            var resul = _condominioBusiness.Obtener(modelo);
            return PartialView("~/Views/Condominio/CondominioGrid.cshtml", (List<AdminVivienda.DAL.CAT_CONDOMINIO>)resul.datos);
        }
        // POST: Condominio/Create
        //[HttpPost]
        //public ActionResult Obtain(CondominioModel modelo)
        //{
        //    var resul = _condominioBusiness.Obtener(modelo);
        //    return Json(resul);
        //}

        // POST: Condominio/Create
        [HttpPost]
        public ActionResult Create(CondominioModel modelo)
        {
            var resul = _condominioBusiness.Agregar(modelo);
            return Json(resul);
        }

        // GET: Condominio/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var resul = _condominioBusiness.ObtenerPorID(id);
        //    return Json(resul);
        //}

        // POST: Condominio/Edit/5
        [HttpPost]
        public ActionResult Edit(CondominioModel modelo)
        {
            var resul = _condominioBusiness.Actualizar(modelo);
            return Json(resul);
        }

        // GET: Condominio/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Condominio/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
