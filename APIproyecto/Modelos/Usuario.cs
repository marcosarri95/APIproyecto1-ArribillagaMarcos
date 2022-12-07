namespace APIproyecto.Modelos
{
    public class Usuario
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contrasenia { get; set; }
        public string? Email { get; set; }


        public Usuario(int ID, string Nombre, string Apellido, string NombreUsuario, string
        Contrasenia, string Email)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.NombreUsuario = NombreUsuario;
            this.Contrasenia = Contrasenia;
            this.Email = Email;
        }
        public Usuario()
        {

        }
        public Usuario(string NombreUsuario, string Contrasenia)
        {
            this.NombreUsuario = NombreUsuario;
            this.Contrasenia = Contrasenia;
        }
    }
}
