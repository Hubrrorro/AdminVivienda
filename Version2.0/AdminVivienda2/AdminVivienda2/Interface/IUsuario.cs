using AdminVivienda2.DAL;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminVivienda2.Interface
{
    public interface IUsuario : IGeneral<Tbl_Usuarios, UsuarioModel>
    {
        RespuestaModel CambioContraseña(Tbl_Usuarios modelo);
        RespuestaModel CompraraContraseña(Tbl_Usuarios modelo);
    }
}
