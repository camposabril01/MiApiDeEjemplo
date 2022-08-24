using MiPrimeraApi2.Controllers.DTOS;
using MiPrimeraApi2.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraApi2.Repository
{
    public class ProductoVendidoHandler
    {
        public const string ConnectionString =
       "Server = UTOPÍA\\SQLEXPRESS; Database = SistemaGestion; Trusted_Connection = True; Persist Security Info=False; Encrypt=False";


        public static List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> resultados = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        //chequea si hay filas
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                resultados.Add(productoVendido);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return resultados;
        }

        public static bool EliminarProductoVendido(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "DELETE FROM ProductoVendido WHERE ID = @id";
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

        public static bool EliminarPVSegunIdProducto(int idProducto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "DELETE FROM ProductoVendido WHERE ID = @idProducto";
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@idProducto", SqlDbType.BigInt);
                    sqlCommand.Parameters["@idProducto"].Value = idProducto;
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

        public static bool CrearProductoVendido(ProductoVendido productoVendido)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido] " +
                    "(IdProducto, Stock, IdVenta) VALUES " +
                    "(@idProducto, @stock, @idVenta)";
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@idProducto", SqlDbType.BigInt);
                    sqlCommand.Parameters["@idProducto"].Value = productoVendido.IdProducto;
                    sqlCommand.Parameters.Add("@stock", SqlDbType.BigInt);
                    sqlCommand.Parameters["@stock"].Value = productoVendido.Stock;
                    sqlCommand.Parameters.Add("@idVenta", SqlDbType.BigInt);
                    sqlCommand.Parameters["@idVenta"].Value = productoVendido.IdVenta;

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
        public static void ModificarProductoVendido(PutProductoVendido productoVendido)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "UPDATE ProductoVendido SET IdProducto = @idProducto, Stock = @stock, IdVenta = @idVenta, " +
                    "WHERE ID = @id";
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.BigInt);
                    sqlCommand.Parameters["@id"].Value = productoVendido.Id;
                    sqlCommand.Parameters.Add("@idProducto", SqlDbType.BigInt);
                    sqlCommand.Parameters["@idProducto"].Value = productoVendido.IdProducto;
                    sqlCommand.Parameters.Add("@stock", SqlDbType.BigInt);
                    sqlCommand.Parameters["@stock"].Value = productoVendido.Stock;
                    sqlCommand.Parameters.Add("@idVenta", SqlDbType.BigInt);
                    sqlCommand.Parameters["@idVenta"].Value = productoVendido.IdVenta;

                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }

        }
    }
}
