using AdminVivienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminVivienda.Interface
{
    public interface IGeneralBusiness<T> where T : class
    {
        RespuestaModel ConsultarId(int id);
        RespuestaModel Consultar(T modelo);
        RespuestaModel Agregar(T modelo);
        RespuestaModel Actualizar(T modelo);
    }
}
