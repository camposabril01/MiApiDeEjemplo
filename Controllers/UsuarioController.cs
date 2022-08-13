using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet("{nombreUsuario}/{contraseña}")]
        //public Usuario GetUsuarioAndContrasena(string nUsuario, string nContrasena)
        //{
        //    Usuario usuario = UsuarioHandler.GetUsuarioAndContrasena(nUsuario, nContrasena);
        //}
    }
}
