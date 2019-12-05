using AdminVivienda.BL.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda.Controllers.Catalogos
{
    public class TipoViviendaController : Controller
    {
        // GET: TipoVivienda
        private GeneralNivel1Business _general = new GeneralNivel1Business("Id_Estado", "Estado", "CAT_ESTADOS");
        public ActionResult Index()
        {
            
            var listado = _general.Consultar(new Models.Catalogos.General.Nivel1Model()
            {
                activo = -1,
                descripcion = "",
                id = 0
            });
            ViewBag.Title = "Buscar tipo de vivienda";
            return View();
        }
        public ActionResult Agregar()
        {
            ViewBag.Title = "Agregar tipo de vivienda";
            return View();
        }

        public ActionResult Actualizar()
        {
            ViewBag.Title = "Editar tipo de vivienda";
            return View();
        }
    }
}