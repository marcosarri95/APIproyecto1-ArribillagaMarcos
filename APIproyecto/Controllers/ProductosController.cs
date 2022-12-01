using Microsoft.AspNetCore.Mvc;
using APIproyecto.Modelos;

namespace APIproyecto.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductosController : Controller
    {
        private SistemaGestion gestion = new SistemaGestion();
        
        [HttpGet]
        public IActionResult MuestraUsuarios()
        {
             //Usuario usuario = new Usuario();
             List<Usuario> user = new List<Usuario>();
            user = gestion.ConsultaUsuarios();
            return Ok(user);
        }

        [HttpGet]
        public IActionResult MuestraProductos()
        {
            //Producto producto = new Producto();
            List<Producto> prod = new List<Producto>();
            prod = gestion.ConsultaProductos();
            return Ok(prod);
        }

        [HttpGet]
        public IActionResult MuestraProductosVendidos()
        {
            //ProductoVendido productov = new ProductoVendido();
            List<ProductoVendido> prodv = new List<ProductoVendido>();
            prodv = gestion.ConsultaProductoVendido();
            return Ok(prodv);
        }

        [HttpGet]
        public IActionResult MuestraVentas()
        {
            //Venta venta = new Venta();
            List<Venta> ventas = new List<Venta>();
            ventas = gestion.ConsultaVenta();
            return Ok(ventas);
        }

        [HttpGet]
        public IActionResult InicioSesion()
        {
          
            List<inicio> user = new List<inicio>();
            user = gestion.InicioSesion();
            return Ok(user);
        }
    }
}
