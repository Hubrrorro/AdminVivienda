using AdminVivienda2.Models;

namespace AdminVivienda2.Interface
{
    public interface IGeneral<T,Y> where T : class where Y : class
    {
        RespuestaModel ConsultarId(int id);
        RespuestaModel Consultar(Y modelo);
        RespuestaModel Agregar(T modelo);
        RespuestaModel Actualizar(T modelo);
        RespuestaModel Select();
    }
}
