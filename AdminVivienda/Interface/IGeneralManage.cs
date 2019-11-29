using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminVivienda.Interface
{
    public interface IGeneralManage<T> where T : class
    {
        void Agregar(T modelo);
        void Actualizar(T modelo);
        List<T> Consultar();
        T ConsultarId(int id);
        bool Existe(string nombre);
        bool Existe(T modelo);

    }
}
