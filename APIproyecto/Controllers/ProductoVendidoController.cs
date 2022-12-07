using Microsoft.AspNetCore.Mvc;
using APIproyecto.Modelos;

namespace APIproyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductoVendidoController : Controller
    {

        private SistemaGestion gestion = new SistemaGestion();
        
        //LEE PRODUCTOS VENDIDOS

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
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public IActionResult AgregaVentas([FromBody] List<ProductoVendido> productov, int idUser)
        {
            try
            {
                if (gestion.cargaVenta(productov, idUser) == 1) { 
                    return Ok();
            }
                else
                {
                    return BadRequest("Se intenta adquirir una cantidad de productos de los cuales no hay stock");
                }

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

    }
}
