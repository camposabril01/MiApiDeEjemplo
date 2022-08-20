﻿using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.Controllers.DTOS;
using MiPrimeraApi2.DTOS;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductosVendidos")]
        public List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoHandler.GetProductosVendidos();
        }

        [HttpDelete(Name = "DeleteProductoVendido")]
        public bool EliminarProductoVendido([FromBody] int id)
        {
            return ProductoVendidoHandler.EliminarProductoVendido(id);
        }

        [HttpPut]
        public void ModificarProductoVendido([FromBody] PutProductoVendido productoVendido)
        {

        }

        [HttpPost]
        public void CrearProductoVendido([FromBody] PostProductoVendido productoVendido)
        {

        }
    }
}
