using MiPrimeraApi2.Model;
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
    }
}
