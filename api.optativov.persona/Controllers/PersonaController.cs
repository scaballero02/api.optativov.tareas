using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

namespace api.optativov.persona.Controllers
{
    public class PersonaController : Controller
    {
        private IConfiguration configuration;
        private PersonaService personaService;

        /*public CuentaController()*/
        public PersonaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.personaService = new PersonaService(new PersonaRepository(configuration.GetConnectionString("postgresDB")));
        }
        // Generate crud controller
        [HttpPost]
        [Route("add")]
        public IActionResult add(PersonaDTO persona)
        {
            try
            {
                if (personaService.add(persona))
                    return Ok("Persona agregada correctamente");
                else
                    return BadRequest("Error al agregar persona");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult update(PersonaDTO persona)
        {
            try
            {
                if (personaService.update(persona))
                    return Ok("Persona actualizada correctamente");
                else
                    return BadRequest("Error al actualizar persona");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("remove")]
        public IActionResult remove(string cedula)
        {
            try
            {
                if (personaService.remove(cedula))
                    return Ok("Persona eliminada correctamente");
                else
                    return BadRequest("Error al eliminar persona");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult get(string id)
        {
            try
            {
                var persona = personaService.get(id);
                if (persona != null)
                    return Ok(persona);
                else
                    return BadRequest("Persona no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            try
            {
                var personas = personaService.list();
                if (personas != null)
                    return Ok(personas);
                else
                    return BadRequest("No hay personas registradas");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
