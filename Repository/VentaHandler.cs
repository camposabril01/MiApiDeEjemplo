using MiPrimeraApi2.Controllers;
using MiPrimeraApi2.Controllers.DTOS;
using MiPrimeraApi2.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraApi2.Repository
{
    public class VentaHandler
    {
        public const string ConnectionString =
       "Server = UTOPÍA\\SQLEXPRESS; Database = SistemaGestion; Trusted_Connection = True; Persist Security Info=False; Encrypt=False";


        public static List<VentaProducto> GetVentas()
        {
            List<VentaProducto> resultados = new List<VentaProducto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "SELECT  v.Id AS IdVenta, p.Id AS IdProducto, p.Descripciones, pv.Stock, v.Comentarios FROM Producto AS p " +
                    "INNER JOIN ProductoVendido AS pv ON p.Id = pv.IdProducto " +
                    "INNER JOIN Venta AS v ON pv.IdVenta = v.Id;";
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        //chequea si hay filas
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                VentaProducto ventaProducto = new VentaProducto();

                                ventaProducto.Id = Convert.ToInt32(dataReader["IdVenta"]);
                                ventaProducto.Comentarios = dataReader["Comentarios"].ToString();
                                ventaProducto.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                ventaProducto.Descripciones = dataReader["Descripciones"].ToString();
                                ventaProducto.Stock = Convert.ToInt32(dataReader["Stock"]);

                                resultados.Add(ventaProducto);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return resultados;
        }

        public static bool EliminarVenta(int id)
        {
            bool resultado = false;
            List<ProductoVendido> modificarProducto = new List<ProductoVendido>();
            modificarProducto = ProductoVendidoHandler.GetProductosVendidosSegunId(id);
            foreach (ProductoVendido productoVendido in modificarProducto)
            {
                if(productoVendido.IdVenta == id) 
                {
                    ProductoVendidoHandler.EliminarProductoVendido(productoVendido.Id);
                }
                //((Esto no va acá ni es lo correcto, tendria que estar en ProductoHandler hecho mejor))
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string commandText = "UPDATE Producto SET Stock = Stock + @stock " +
                        "WHERE Id = @idProducto";
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@idProducto", SqlDbType.BigInt);
                        sqlCommand.Parameters["@idProducto"].Value = productoVendido.Id;
                        sqlCommand.Parameters.Add("@stock", SqlDbType.BigInt);
                        sqlCommand.Parameters["@stock"].Value = productoVendido.Stock;

                        sqlConnection.Open();

                        sqlCommand.ExecuteNonQuery();

                        sqlConnection.Close();
                    }
                }
            }
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "DELETE FROM Venta WHERE ID = @id";
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.BigInt);
                    sqlCommand.Parameters["@id"].Value = id;
                    sqlConnection.Open();

                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }

                    sqlConnection.Close();
                }
            }

            return resultado;
        }
        public static bool CrearVenta(Venta venta)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "INSERT INTO [SistemaGestion].[dbo].[Venta] " +
                    "(Comentarios) VALUES " +
                    "(@comentarios)";
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@comentarios", SqlDbType.VarChar);
                    sqlCommand.Parameters["@comentarios"].Value = venta.Comentarios;
                    

                    sqlConnection.Open();

                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }

                    sqlConnection.Close();
                }
            }

            return resultado;
        }
        public static void ModificarVenta(PutVenta venta)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "UPDATE Venta SET Comentarios = @comentarios " +
                    "WHERE ID = @id";
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.BigInt);
                    sqlCommand.Parameters["@id"].Value = venta.Id;
                    sqlCommand.Parameters.Add("@comentarios", SqlDbType.VarChar);
                    sqlCommand.Parameters["@comentarios"].Value = venta.Comentarios;

                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }

        }
    }
}
