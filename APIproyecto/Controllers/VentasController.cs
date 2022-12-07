using Microsoft.AspNetCore.Mvc;
using APIproyecto.Modelos;

namespace APIproyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VentasController : Controller
    {
        private SistemaGestion gestion = new SistemaGestion();

        //MUESTRA VENTAS
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
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        
    }
}
