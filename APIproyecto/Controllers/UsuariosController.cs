using Microsoft.AspNetCore.Mvc;
using APIproyecto.Modelos;

namespace APIproyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuariosController : Controller
    {
        private SistemaGestion gestion = new SistemaGestion();

        //LECTURA USUARIOS
        [HttpGet]
        public IActionResult InicioSesion()
        {
            try
            {
                List<inicio> user = new List<inicio>();
                user = gestion.InicioSesion();
                return Ok(user);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

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

        //MODIFICACION USUARIOS

        [HttpPut]
        public IActionResult ModificaUsuario([FromBody] Usuario usuario)
        {
            try
            {

                if (gestion.ModificaUsuario(usuario) == 1)
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

        //AGREGADO DE USUARIOS

        [HttpPost]
        public IActionResult AgregarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (gestion.AgregaUsuario(usuario) == 1)
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

        //ELIMINADO DE USUARIOS

        [HttpDelete]
        public IActionResult EliminaUsuario([FromBody] int id)
        {
            try
            {
                if (gestion.EliminaUsuario(id) == 1)
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
