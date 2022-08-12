using System;

public class ProductoVendido
{
    private int Id { get; set; }
    private int IdProducto { get; set; }
    private int Stock { get; set; }
    private int IdVenta { get; set; }

    public ProductoVendido(int id, int idProducto, int stock, int idVenta)
    {
        Id = id;
        IdProducto = idProducto;
        Stock = stock;
        IdVenta = idVenta;
    }
}
