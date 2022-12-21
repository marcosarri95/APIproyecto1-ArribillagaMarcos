using Microsoft.AspNetCore.Mvc;
using APIproyecto.Modelos;

namespace APIproyecto.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {

        private SistemaGestion gestion = new SistemaGestion();

        [HttpPost]
        public IActionResult InicioSesion([FromBody] inicio inicio)
        {
            try
            {
                if (gestion.InicioSesion(inicio) == true) { return Ok("Inicio de sesión exitoso"); }
                else { return BadRequest("Fallo al inicio de sesión: usuario inexistente o contraseña incorrecta"); }

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
