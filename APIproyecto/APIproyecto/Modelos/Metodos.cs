using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class inicio
    {
        public string? NombreUser { get; set; }
        public string? pass { get; set; }

        public inicio()
        {

        }
    }

 
}
