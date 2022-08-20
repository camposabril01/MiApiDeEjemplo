using MiPrimeraApi2.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraApi2.Repository
{
    public class VentaHandler
    {
        public const string ConnectionString =
       "Server = UTOPÍA\\SQLEXPRESS; Database = SistemaGestion; Trusted_Connection = True; Persist Security Info=False; Encrypt=False";


        public static List<Venta> GetVentas()
        {
            List<Venta> resultados = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        //chequea si hay filas
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();

                                resultados.Add(venta);
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
    }
}
