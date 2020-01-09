using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminVivienda2.DAL;
using AdminVivienda2.Models;

namespace AdminVivienda2.Controllers.Catalogos
{

    public class CondominioController : Controller
    {
        private RespuestaModel _respuesta;
        // GET: Condominio
        public ActionResult Index()
        {
            ViewBag.Title = "Buscar condominio";
            return View();
        }
        public ActionResult Details(int id)
        {
            ViewBag.Accion = "Actualizar";
            ViewBag.Title = "Editar condominio";
            var resul = ConsultarDBId(id);
            return View("~/Views/Condominio/Condominio.cshtml", (DAL.CAT_CONDOMINIOS)resul.datos);
        }
        public ActionResult Create()
        {
            ViewBag.Accion = "Agregar";
            ViewBag.Title = "Agregar condominio";
            CAT_CONDOMINIOS condominio = new CAT_CONDOMINIOS();
            return View("~/Views/Condominio/Condominio.cshtml", condominio);
        }
        public PartialViewResult Grid(CondominioModel modelo)
        {
            var resul = ConsultarDB(modelo);
            return PartialView("~/Views/Condominio/Grid.cshtml", (List<DAL.CAT_CONDOMINIOS>)resul.datos);
        }
        [HttpPost]
        public ActionResult Create(CAT_CONDOMINIOS modelo)
        {
            var resul = AgregarDB(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Edit(CAT_CONDOMINIOS modelo)
        {
            var resul = ActualizarDB(modelo);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult Select()
        {
            var resul = ConsultarDB(new CondominioModel() { Activo= 1 });
            return Json(resul);
        }
        private RespuestaModel AgregarDB(CAT_CONDOMINIOS model)
        {
            _respuesta = new RespuestaModel();
            try
            {
                if (ExisteDB(model.Condominio))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Resources.Mensajes.MensajeDuplicado);
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    model.Activo = true;
                    conex.CAT_CONDOMINIOS.Add(model);
                    conex.SaveChanges();
                }
                _respuesta.ejecucion = true;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeCorrecto);
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }
        private RespuestaModel ActualizarDB(CAT_CONDOMINIOS model)
        {
            try
            {
                _respuesta = new RespuestaModel();
                if (ExisteDB(model))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje.Add(Resources.Mensajes.MensajeDuplicado);
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    var condominio = conex.CAT_CONDOMINIOS.Where(x => x.Id_Condominio.Equals(model.Id_Condominio)).FirstOrDefault();
                    //condominio = model;
                    condominio.Activo = model.Activo;
                    condominio.Clave = model.Clave;
                    condominio.Colonia = model.Colonia;
                    condominio.Condominio = model.Condominio;
                    condominio.Cp = model.Cp;
                    condominio.DemMun = model.DemMun;
                    condominio.Id_Estado = model.Id_Estado;
                    conex.SaveChanges();
                    _respuesta.ejecucion = true;
                    _respuesta.mensaje.Add(Resources.Mensajes.MensajeEditar);
                }
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }
        private RespuestaModel ConsultarDB(CondominioModel model)
        {
            try
            {

                List<CAT_CONDOMINIOS> listado;
                _respuesta = new RespuestaModel();
                using (var conex = new DatabaseViviendaEntities())
                {
                    listado = conex.CAT_CONDOMINIOS.ToList();
                    if (!String.IsNullOrEmpty(model.Condominio))
                        listado = listado.Where(x => x.Condominio.ToUpper().Contains(model.Condominio.ToUpper())).ToList();
                    if (model.Activo == 1)
                        listado = listado.Where(x => x.Activo.Equals(true)).ToList();
                    if (model.Activo == 0)
                        listado = listado.Where(x => x.Activo.Equals(false)).ToList();
                    _respuesta.ejecucion = true;
                    _respuesta.datos = listado;
                }
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }
        private RespuestaModel ConsultarDBId(int id)
        {
            try
            {
                _respuesta = new RespuestaModel();
                _respuesta.ejecucion = true;
                CAT_CONDOMINIOS condominio;
                using (var conex = new DatabaseViviendaEntities())
                {
                    condominio = conex.CAT_CONDOMINIOS.Where(x => x.Id_Condominio.Equals(id)).FirstOrDefault();
                }
                _respuesta.datos = condominio;
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }
        private bool ExisteDB(string nombre)
        {
            int cantidad = 0;
            using (var conex = new DatabaseViviendaEntities())
            {
                cantidad = conex.CAT_CONDOMINIOS.Where(x => x.Condominio.Trim().ToUpper().Equals(nombre.Trim().ToUpper())).Count();
            }
            if (cantidad == 0)
                return false;
            else
                return true;
        }
        private bool ExisteDB(CAT_CONDOMINIOS model)
        {
            int cantidad = 0;
            using (var conex = new DatabaseViviendaEntities())
            {
                cantidad = conex.CAT_CONDOMINIOS.Where(x => x.Condominio.Trim().ToUpper().Equals(model.Condominio.Trim().ToUpper())
                && x.Id_Condominio != model.Id_Condominio).Count();
            }
            if (cantidad == 0)
                return false;
            else
                return true;
        }
    }
}