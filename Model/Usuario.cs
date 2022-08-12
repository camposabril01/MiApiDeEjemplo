namespace MiPrimeraApi2.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string NombreUsuario { get; set; }
        public string Mail { get; set; }

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contrasena, string mail)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Mail = mail;
        }
    }
}
