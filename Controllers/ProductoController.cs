﻿using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.DTOS;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }

        [HttpDelete(Name = "DeleteProducto")]
        public bool EliminarProducto([FromBody] int id)
        {
            return ProductoHandler.EliminarProducto(id);
        }

        [HttpPut]
        public void ModificarProducto([FromBody] PutUsuario usuario)
        {

        }

        [HttpPost]
        public void CrearProducto([FromBody] PostUsuario usuario)
        {

        }
    }
}
