using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi2.Controllers
{
    public class ProductoController
    {
        [HttpGet(Name = "GetProductos")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
        }
    }
}
