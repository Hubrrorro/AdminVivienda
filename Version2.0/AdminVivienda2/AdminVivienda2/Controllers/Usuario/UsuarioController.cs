using AdminVivienda2.BL;
using AdminVivienda2.DAL;
using AdminVivienda2.Interface;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminVivienda2.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        IUsuario usuarioBl;
        public UsuarioController()
        {
            usuarioBl = new UsuarioBL();
        }
        // GET: Condominio
        public ActionResult Index()
        {
            ViewBag.Title = "Buscar usuario";
            return View();
        }
        public ActionResult Details(int id)
        {
            ViewBag.Accion = "Actualizar";
            ViewBag.Title = "Editar usuario";
            var resul = usuarioBl.ConsultarId(id);
            return View("~/Views/Usuario/Usuario.cshtml", (Tbl_Usuarios)resul.datos);
        }
        public ActionResult Create()
        {
            ViewBag.Accion = "Agregar";
            ViewBag.Title = "Agregar usuario";
            Tbl_Usuarios condominio = new Tbl_Usuarios();
            return View("~/Views/Usuario/Usuario.cshtml", condominio);
        }
        public ActionResult ChangePassword()
        {
            ViewBag.Accion = "Cambio";
            ViewBag.Title = "Cambio de contraseña";
            return View("~/Views/Usuario/ChContraseña.cshtml");
        }
        public PartialViewResult Grid(UsuarioModel modelo)
        {
            var resul = usuarioBl.Consultar(modelo);
            return PartialView("~/Views/Usuario/Grid.cshtml", (List<DAL.CAT_CONDOMINIOS>)resul.datos);
        }
        [HttpPost]
        public ActionResult Create(Tbl_Usuarios modelo)
        {
            var resul = usuarioBl.Agregar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Edit(Tbl_Usuarios modelo)
        {
            var resul = usuarioBl.Actualizar(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult ChangePassword(Tbl_Usuarios modelo)
        {
            var resul = usuarioBl.CambioContraseña(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Select()
        {
            var resul = usuarioBl.Select();
            return Json(resul);
        }
    }
}