namespace APIproyecto.Modelos
{
    public class Producto
    {
        public int ID { get; set; }
        public string? Descripcion { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IDUsuario { get; set; }

        public Producto(int ID, string Descripcion, double Costo, double PrecioVenta, int Stock, int
        IDUsuario)
        {
            this.ID = ID;
            this.Descripcion = Descripcion;
            this.PrecioVenta = PrecioVenta;
            this.Stock = Stock;
            this.Costo = Costo;
            this.IDUsuario = IDUsuario;
        }
        public Producto() { }
    }
}
