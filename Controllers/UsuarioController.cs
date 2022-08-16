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

        }

        [HttpPost]
        public void CrearUsuario([FromBody] PostUsuario usuario)
        {

        }
    }
}
