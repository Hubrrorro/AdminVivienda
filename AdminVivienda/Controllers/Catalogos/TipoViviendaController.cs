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
        public ActionResult Index()
        {
            GeneralNivel1Business general = new GeneralNivel1Business("Id_Estado","Estado","CAT_ESTADOS");
            var listado = general.Consultar(new Models.Catalogos.General.Nivel1Model()
            {
                activo = -1,
                descripcion = "",
                id = 0
            });
            ViewBag.Title = "Buscar tipo de vivienda";
            return View();
        }

    }
}