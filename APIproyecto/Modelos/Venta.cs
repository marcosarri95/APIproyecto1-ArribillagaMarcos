namespace APIproyecto.Modelos
{
    public class Venta
    {
        public int ID { get; set; }
        public int IDUsuario { get; set; }
        public string? Comentarios { get; set; }

        public Venta(int ID, int IDUsuario, string Comentarios)
        {
            this.ID = ID;
            this.IDUsuario = IDUsuario;
            this.Comentarios = Comentarios;
        }

        public Venta()
        {
        }
    }
}
