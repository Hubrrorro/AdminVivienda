using AdminVivienda2.DAL;
using AdminVivienda2.Interface;
using AdminVivienda2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda2.BL
{
    public class UsuarioBL : IUsuario
    {
        private RespuestaModel _respuesta;
        public RespuestaModel Actualizar(Tbl_Usuarios modelo)
        {
            try
            {
                _respuesta = new RespuestaModel();
                List<string> mensajes;
                if (ExisteDB(modelo,false,out mensajes))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje = mensajes;
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    var usuario = conex.Tbl_Usuarios.Where(x => x.Id_Usuario.Equals(modelo.Id_Usuario)).FirstOrDefault();
                    usuario.Nombre = modelo.Nombre;
                    usuario.ApMaterno = modelo.ApMaterno;
                    usuario.ApPaterno = modelo.ApPaterno;
                    usuario.Correo = modelo.Correo;
                    usuario.Usuario = modelo.Usuario;
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
        private bool ExisteDB(Tbl_Usuarios modelo, bool guardar, out List<string> mensajes)
        {
            bool esDuplicado = false;
            mensajes = new List<string>();
            List<UsuarioModel> listUsuarios = new List<UsuarioModel>();
            var modelBusqueda = Consultar(new UsuarioModel() {
                Activo = -1
            });
            if (!guardar)
            {
                listUsuarios = (List<UsuarioModel>)modelBusqueda.datos;
                listUsuarios = listUsuarios.Where(x => !x.Id_Usuario.Equals(modelo.Id_Usuario)).ToList();
            }
            if (listUsuarios.Exists(x => x.Usuario.Equals(modelo.Usuario)))
            {
                esDuplicado = true;
                mensajes.Add("El usuario ya se encuentra asignado.");
            }
            if (listUsuarios.Exists(x => x.Correo.Equals(modelo.Correo)))
            {
                esDuplicado = true;
                mensajes.Add("El correo electrónico ya se encuentra asignado.");
            }
            if (listUsuarios.Exists(x => x.Nombre.Trim().ToUpper().Equals(modelo.Nombre.Trim().ToUpper()) 
            && x.ApPaterno.Trim().ToUpper().Equals(modelo.ApPaterno.Trim().ToUpper()) 
            && x.ApMaterno.Trim().ToUpper().Equals(modelo.ApMaterno.Trim().ToUpper())))
            {
                esDuplicado = true;
                mensajes.Add("El nombre ya se encuentra asignado.");
            }
            return esDuplicado;
        }
        public RespuestaModel Agregar(Tbl_Usuarios modelo)
        {
            try
            {
                _respuesta = new RespuestaModel();
                List<string> mensajes;
                if (!ExisteDB(modelo,true,out mensajes))
                {
                    _respuesta.ejecucion = false;
                    _respuesta.mensaje = mensajes;
                    return _respuesta;
                }
                using (var conex = new DatabaseViviendaEntities())
                {
                    conex.Tbl_Usuarios.Add(modelo);
                    conex.SaveChanges();
                }
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }

        public RespuestaModel Consultar(UsuarioModel modelo)
        {
            try
            {
                _respuesta = new RespuestaModel();
                using (var conex = new DatabaseViviendaEntities())
                {
                    var lstUsuario = conex.Tbl_Usuarios.ToList();
                    if (!modelo.Id_Usuario.Equals(0))
                        lstUsuario = lstUsuario.Where(x=> x.Id_Usuario.Equals(modelo.Id_Usuario)).ToList();
                    if (String.IsNullOrEmpty(modelo.Nombre))
                        lstUsuario = lstUsuario.Where(x => x.Nombre.Equals(modelo.Nombre)).ToList();
                    if (String.IsNullOrEmpty(modelo.ApPaterno))
                        lstUsuario = lstUsuario.Where(x => x.ApPaterno.Equals(modelo.ApPaterno)).ToList();
                    if (String.IsNullOrEmpty(modelo.ApMaterno))
                        lstUsuario = lstUsuario.Where(x => x.ApMaterno.Equals(modelo.ApMaterno)).ToList();
                    if (String.IsNullOrEmpty(modelo.Correo))
                        lstUsuario = lstUsuario.Where(x => x.Correo.Equals(modelo.Correo)).ToList();
                    if (String.IsNullOrEmpty(modelo.Usuario))
                        lstUsuario = lstUsuario.Where(x => x.Usuario.Equals(modelo.Usuario)).ToList();
                    if (String.IsNullOrEmpty(modelo.Contraseña))
                        lstUsuario = lstUsuario.Where(x => x.Password.Equals(modelo.Contraseña)).ToList();
                    if(modelo.Activo.Equals(1))
                        lstUsuario = lstUsuario.Where(x => x.Activo.Equals(true)).ToList();
                    if (modelo.Activo.Equals(0))
                        lstUsuario = lstUsuario.Where(x => x.Activo.Equals(false)).ToList();
                    _respuesta.ejecucion = true;
                    _respuesta.datos = lstUsuario;
                }
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }

        public RespuestaModel ConsultarId(int id)
        {
            try
            {
                _respuesta = new RespuestaModel();
                using (var conex = new DatabaseViviendaEntities())
                {
                    if (!id.Equals(0))
                        _respuesta.datos = conex.Tbl_Usuarios.Where(x => x.Id_Usuario.Equals(id)).FirstOrDefault();
                    _respuesta.ejecucion = true;
                }
            }
            catch
            {
                _respuesta.ejecucion = false;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeError);

            }
            return _respuesta;
        }

        public RespuestaModel Select()
        {
            throw new NotImplementedException();
        }

        public RespuestaModel CambioContraseña(Tbl_Usuarios modelo)
        {
            using (var conex = new DatabaseViviendaEntities())
            {
                var usuario = conex.Tbl_Usuarios.Where(x => x.Id_Usuario.Equals(modelo.Id_Usuario)).FirstOrDefault();
                usuario.Password = modelo.Password;
                conex.SaveChanges();
                _respuesta.ejecucion = true;
                _respuesta.mensaje.Add(Resources.Mensajes.MensajeEditar);
            }
            return _respuesta;
        }
        public RespuestaModel CompraraContraseña(Tbl_Usuarios modelo)
        {
            using (var conex = new DatabaseViviendaEntities())
            {
                var usuario = conex.Tbl_Usuarios.Where(x => x.Id_Usuario.Equals(modelo.Id_Usuario)).FirstOrDefault();
                if (usuario.Password.Equals(modelo.Password))
                    _respuesta.ejecucion = true;
                else
                {
                    _respuesta.ejecucion = true;
                    _respuesta.mensaje.Add("Usuario y/o contraseña incorrecta");
                }
            }
            return _respuesta;
        }
    }
}