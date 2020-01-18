using AdminVivienda2.Models;

namespace AdminVivienda2.Controllers.Catalogos
{
    public class ServiciosController : Nivel1Campo1Controller
    {
        // GET: TipoVivienda
        private static TablaNivel1 _tablaNivel1 = new TablaNivel1()
        {
            descripcion = "Servicios",
            idNombre = "Id_Servicio",
            nombreTabla = "TBL_SERVICIOS"
        };
        private static Nivel1Campo1Model _nivel1 = new Nivel1Campo1Model()
        {
            campo1 = "Servicios",
            maxValue = 100,
            estatus = "Estatus",
            tituloAgregar = "Agregar servicios",
            tituloEditar = "Editar servicios",
            tituloIndex = "Buscar servicios",
            tabla = _tablaNivel1
        };
        public ServiciosController() : base(_nivel1)
        {
        }
    }
}