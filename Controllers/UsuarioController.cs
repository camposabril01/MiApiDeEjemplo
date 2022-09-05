using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.DTOS;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]
        public bool GetUsuarioAndContrasena(string nombreUsuario, string contraseña)
        {
            bool permitirLogin;
            permitirLogin = UsuarioHandler.GetUsuarioAndContrasena(nombreUsuario, contraseña);

            if (!permitirLogin)
            {
                Console.WriteLine("¡Datos inválidos!");
            }
            return permitirLogin;
        }

        [HttpDelete(Name = "DeleteUsuario")]
        public bool EliminarUsuario([FromBody] int id)
        {
            return UsuarioHandler.EliminarUsuario(id);
        }

        [HttpPut]
        public void ModificarUsuario([FromBody] PutUsuario usuario)
        {
            UsuarioHandler.ModificarUsuario(usuario);
        }

        [HttpPost]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
            return UsuarioHandler.CrearUsuario(new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail,
                NombreUsuario = usuario.NombreUsuario
            });
        }
    }
}
