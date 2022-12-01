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
            try
            {
                //Usuario usuario = new Usuario();
                List<Usuario> user = new List<Usuario>();
                user = gestion.ConsultaUsuarios();
                return Ok(user);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        public IActionResult MuestraProductos()
        {
            try
            {
                //Producto producto = new Producto();
                List<Producto> prod = new List<Producto>();
                prod = gestion.ConsultaProductos();
                return Ok(prod);
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        public IActionResult MuestraProductosVendidos()
        {
            try
            {
                //ProductoVendido productov = new ProductoVendido();
                List<ProductoVendido> prodv = new List<ProductoVendido>();
                prodv = gestion.ConsultaProductoVendido();
                return Ok(prodv);
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        public IActionResult MuestraVentas()
        {
            try
            {
                //Venta venta = new Venta();
                List<Venta> ventas = new List<Venta>();
                ventas = gestion.ConsultaVenta();
                return Ok(ventas);
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
            }

        [HttpGet]
        public IActionResult InicioSesion()
        {
            try
            {
                List<inicio> user = new List<inicio>();
                user = gestion.InicioSesion();
                return Ok(user);
            }
            catch (Exception ex) { return BadRequest(ex.Message);  }
            }
    }
}
