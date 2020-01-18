using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda2.Controllers.Administracion
{
    public class ContratoAdminController : Controller
    {
        //IGeneral<CAT_CONDOMINIOS, CondominioModel> condominioBl;
        //public CondominioController()
        //{
        //    condominioBl = new CondominioBL();
        //}
        //// GET: Condominio
        //public ActionResult Index()
        //{
        //    ViewBag.Title = "Buscar condominio";
        //    return View();
        //}
        //public ActionResult Details(int id)
        //{
        //    ViewBag.Accion = "Actualizar";
        //    ViewBag.Title = "Editar condominio";
        //    var resul = condominioBl.ConsultarId(id);
        //    return View("~/Views/Condominio/Condominio.cshtml", (DAL.CAT_CONDOMINIOS)resul.datos);
        //}
        //public ActionResult Create()
        //{
        //    ViewBag.Accion = "Agregar";
        //    ViewBag.Title = "Agregar condominio";
        //    CAT_CONDOMINIOS condominio = new CAT_CONDOMINIOS();
        //    return View("~/Views/Condominio/Condominio.cshtml", condominio);
        //}
        //public PartialViewResult Grid(CondominioModel modelo)
        //{
        //    var resul = condominioBl.Consultar(modelo);
        //    return PartialView("~/Views/Condominio/Grid.cshtml", (List<DAL.CAT_CONDOMINIOS>)resul.datos);
        //}
        //[HttpPost]
        //public ActionResult Create(CAT_CONDOMINIOS modelo)
        //{
        //    var resul = condominioBl.Agregar(modelo);
        //    return Json(resul);
        //}
        //[HttpPost]
        //public ActionResult Edit(CAT_CONDOMINIOS modelo)
        //{
        //    var resul = condominioBl.Actualizar(modelo);
        //    return Json(resul);
        //}
        //[HttpPost]
        //public ActionResult Select()
        //{
        //    var resul = condominioBl.Select();
        //    return Json(resul);
        //}
    }
}