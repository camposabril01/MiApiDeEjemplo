using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.Controllers.DTOS;
using MiPrimeraApi2.DTOS;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public List<Venta> GetVentas()
        {
            return VentaHandler.GetVentas();
        }

        [HttpDelete(Name = "DeleteVenta")]
        public bool EliminarUsuario([FromBody] int id)
        {
            return VentaHandler.EliminarVenta(id);
        }

        [HttpPut]
        public void ModificarUsuario([FromBody] PutVenta venta)
        {

        }

        [HttpPost]
        public void CrearUsuario([FromBody] PostVenta venta)
        {

        }
    }
}
