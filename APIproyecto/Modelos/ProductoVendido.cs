namespace APIproyecto.Modelos
{
    public class ProductoVendido
    {
        public int ID { get; set; }
        public int IDproducto { get; set; }
        public int Stock { get; set; }
        public int IDVenta { get; set; }

        public ProductoVendido(int ID, int IDproducto, int Stock, int IDVenta)

        {
            this.ID = ID;
            this.Stock = Stock;
            this.IDproducto = IDproducto;
            this.IDVenta = IDVenta;
        }
        public ProductoVendido() { }
    }
}
