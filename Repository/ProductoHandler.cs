using MiPrimeraApi2.Controllers.DTOS;
using MiPrimeraApi2.DTOS;
using MiPrimeraApi2.Model;
using System.Data;
using System.Data.SqlClient; 

namespace MiPrimeraApi2.Repository
{
    public class ProductoHandler
    {
        public const string ConnectionString =
       "Server = UTOPÍA\\SQLEXPRESS; Database = SistemaGestion; Trusted_Connection = True; Persist Security Info=False; Encrypt=False";


        public static List<Producto> GetProductos()
        {
            List<Producto> resultados = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        //chequea si hay filas
                        if (dataReader.HasRows)
                        {
                            while(dataReader.Read())
                            {
                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();
                                producto.Costo = Convert.ToDouble(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dataReader["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);

                                resultados.Add(producto);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return resultados;
        }

        public static bool EliminarProducto(int id)
        {
            bool resultado = false;

            ProductoVendidoHandler.EliminarPVSegunIdProducto(id);
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "DELETE FROM Producto WHERE ID = @id";
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

        public static void ModificarProducto(PutProducto producto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "UPDATE Producto SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioVenta, " +
                    "Stock = @stock, IdUsuario = @idUsuario " +
                    "WHERE ID = @id";
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.BigInt);
                    sqlCommand.Parameters["@id"].Value = producto.Id;
                    sqlCommand.Parameters.Add("@descripciones", SqlDbType.VarChar);
                    sqlCommand.Parameters["@descripciones"].Value = producto.Descripciones;
                    sqlCommand.Parameters.Add("@costo", SqlDbType.Float);
                    sqlCommand.Parameters["@costo"].Value = producto.Costo;
                    sqlCommand.Parameters.Add("@precioVenta", SqlDbType.Float);
                    sqlCommand.Parameters["@precioVenta"].Value = producto.PrecioVenta;
                    sqlCommand.Parameters.Add("@stock", SqlDbType.BigInt);
                    sqlCommand.Parameters["@stock"].Value = producto.Stock;
                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.BigInt);
                    sqlCommand.Parameters["@idUsuario"].Value = producto.IdUsuario;

                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }

        }
        public static bool CrearProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "INSERT INTO [SistemaGestion].[dbo].[Producto] " +
                    "(Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES " +
                    "(@descripciones, @costo, @precioVenta, @stock, @idUsuario)";
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@descripciones", SqlDbType.VarChar);
                    sqlCommand.Parameters["@descripciones"].Value = producto.Descripciones;
                    sqlCommand.Parameters.Add("@costo", SqlDbType.Float);
                    sqlCommand.Parameters["@costo"].Value = producto.Costo;
                    sqlCommand.Parameters.Add("@precioVenta", SqlDbType.Float);
                    sqlCommand.Parameters["@precioVenta"].Value = producto.PrecioVenta;
                    sqlCommand.Parameters.Add("@stock", SqlDbType.BigInt);
                    sqlCommand.Parameters["@stock"].Value = producto.Stock;
                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.BigInt);
                    sqlCommand.Parameters["@idUsuario"].Value = producto.IdUsuario;

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
    }
}
