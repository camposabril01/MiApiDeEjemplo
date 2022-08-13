namespace MiPrimeraApi2.Model
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        //public Producto(int id, string descripcion, float costo, float precioVenta, int stock, int idUsuario)
        //{
        //    Id = id;
        //    Descripciones = descripcion;
        //    Costo = costo;
        //    PrecioVenta = precioVenta;
        //    Stock = stock;
        //    IdUsuario = idUsuario;
        //}
    }

}