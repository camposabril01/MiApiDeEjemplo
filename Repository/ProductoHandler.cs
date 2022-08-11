using MiPrimeraApi2.Model;
using System.Data;//deletear despues
using System.Data.SqlClient; 

namespace MiPrimeraApi2.Repository
{
    public class ProductoHandler
    {
        public const string ConnectionString =
       "Server = UTOPÍA\\SQLEXPRESS; Database = SistemaGestion; Trusted_Connection = True; Persist Security Info=False; Encrypt=False";

        public static List<Producto> GetProductos()
        {
            List<Producto> resultado = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Productos;";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = sqlCommand;

                    DataTable table = new DataTable();

                    sqlDataAdapter.Fill(table);

                    sqlCommand.Connection.Close();

                    foreach (DataRow row in table.Rows)
                    {
                        Producto producto = new Producto();

                        producto.Id = Convert.ToInt32(row["Id"]);
                    }
                }
            }
        }
    }
}
