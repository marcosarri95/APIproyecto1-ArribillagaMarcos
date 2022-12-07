using Microsoft.AspNetCore.Mvc;
using APIproyecto.Modelos;

namespace APIproyecto.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductosController : Controller
    {

        
        private SistemaGestion gestion = new SistemaGestion();

        //MUESTRA PRODUCTOS Y PRODUCTOS VENDIDOS

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

        

        
        //Agrega 
        
        [HttpPost]
        public IActionResult AgregarProducto([FromBody] Producto producto)
        {
            try
            {
                if ((producto.Descripcion == "") || (producto.Descripcion == null))
                {
                    return BadRequest("Se debe agregar el comentario al producto cargado");
                }
                else if (producto.Costo <= 0)
                {
                    return BadRequest("El producto debe tener un costo");
                }
                else if (producto.PrecioVenta <= 0){
                    return BadRequest("El producto debe tener un precio de venta");
                }
                else if (producto.Stock <= 0) {
                    return BadRequest("El producto debe tener una cantidad determinada de stock");
                }
                else {

                    if (gestion.AgregaProducto(producto) == 1)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


        //MODIFICA
        [HttpPut]
        public IActionResult ModificaProducto([FromBody] Producto producto)
        {
            try
            {
                
                  if (gestion.ModificaProducto(producto) == 1)
                  {
                      return Ok();
                  }
                  else
                  {
                      return BadRequest();
                  }
               
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        

        //ELIMINA
     
        [HttpDelete]
        public IActionResult EliminaProducto([FromBody] int id)
        {
            try
            {
                if (gestion.EliminaProducto(id) >= 1)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
