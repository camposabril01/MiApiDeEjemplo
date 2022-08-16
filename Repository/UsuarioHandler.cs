using MiPrimeraApi2.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraApi2.Repository
{
    public class UsuarioHandler
    {
        public const string ConnectionString =
       "Server = UTOPÍA\\SQLEXPRESS; Database = SistemaGestion; Trusted_Connection = True; Persist Security Info=False; Encrypt=False";


        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> resultados = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        //chequea si hay filas
                        if (dataReader.HasRows)
                        {
                            while(dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["NombreUsuario"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                resultados.Add(usuario);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return resultados;
        }

        public static bool GetUsuarioAndContrasena(string nUsuario, string nContrasena)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "SELECT Usuario.NombreUsuario, Usuario.Contraseña FROM Usuario WHERE NombreUsuario = @nUsuario AND Contraseña = @nContrasena;";
                
                using (SqlCommand sqlCommand = new SqlCommand
                                (commandText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@nUsuario", SqlDbType.VarChar);
                    sqlCommand.Parameters["@nUsuario"].Value = nUsuario;
                    sqlCommand.Parameters.Add("@nContrasena", SqlDbType.VarChar);
                    sqlCommand.Parameters["@nContrasena"].Value = nContrasena;

                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        SqlCommand command = new SqlCommand(commandText, sqlConnection);
                        //chequea si hay filas
                        if (dataReader.HasRows)
                        {
                            resultado = true;
                        }
                    }
                    sqlConnection.Close();
                }
            }

            return resultado;
        }

        public static bool EliminarUsuario(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string commandText = "DELETE FROM Usuario WHERE ID = @id";
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
    }
}
