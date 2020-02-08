using AdminVivienda2.BL;
using AdminVivienda2.DAL;
using AdminVivienda2.Interface;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda2.Controllers.Administracion
{
    public class ContratoAdminController : Controller
    {
        IGeneral<TBL_CONTRATOS, ContratoModel> contratosBL;
        IGeneral<ASOC_CONTRATOS_SERVICIOS, ServiciosContratoModel> contratoServiciosBL;
        public ContratoAdminController()
        {
            contratosBL = new ContratoBL();
            contratoServiciosBL = new ServicioContratoBL();
        }
        //// GET: Condominio
        public ActionResult Index()
        {
            ViewBag.Title = "Buscar contrato";
            ViewBag.Accion = "Agregar";
            return View();
        }
        //public ActionResult Details(int id)
        //{
        //    ViewBag.Accion = "Actualizar";
        //    ViewBag.Title = "Editar condominio";
        //    var resul = condominioBl.ConsultarId(id);
        //    return View("~/Views/Condominio/Condominio.cshtml", (DAL.CAT_CONDOMINIOS)resul.datos);
        //}
        public ActionResult Create()
        {
            ViewBag.Accion = "Agregar";
            ViewBag.Title = "Agregar contrato";
            //CAT_CONDOMINIOS condominio = new CAT_CONDOMINIOS();
            return View("~/Views/ContratoAdmin/Contrato.cshtml");
        }
        //public PartialViewResult Grid(CondominioModel modelo)
        //{
        //    var resul = condominioBl.Consultar(modelo);
        //    return PartialView("~/Views/Condominio/Grid.cshtml", (List<DAL.CAT_CONDOMINIOS>)resul.datos);
        //}
        [HttpPost]
        public ActionResult Create(ContratoModel modelo)
        {
            TBL_CONTRATOS tblContrato = new TBL_CONTRATOS();
            tblContrato.FchFin = DateTime.Parse(modelo.FechaFin);
            tblContrato.FchInicio = DateTime.Parse(modelo.FechaIni);
            tblContrato.Id_Condominio = modelo.Id_Condominio;
            var resul = contratosBL.Agregar(tblContrato);
            if (resul.ejecucion)
            {
                foreach (var serviciosCon in modelo.Servicios)
                {
                    ASOC_CONTRATOS_SERVICIOS contServicios = new ASOC_CONTRATOS_SERVICIOS(){
                    Id_Contrato = (int)resul.datos,
                    Id_Servicio = serviciosCon.Id_Servicio,
                     MesAct = (decimal)serviciosCon.MesCorr,
                     MesAnt = (decimal)serviciosCon.MesAnt,
                     MesVen = (decimal)serviciosCon.MesVen
                    };
                    contratoServiciosBL.Agregar(contServicios);
                }
            }
            return Json(resul);
        }
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