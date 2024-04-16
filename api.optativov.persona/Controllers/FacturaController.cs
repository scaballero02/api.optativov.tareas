using Microsoft.AspNetCore.Mvc;
using Repository.Implementations;
using Repository.Modelos;
using Services;

namespace api.optativov.persona.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : Controller
    {
        private IConfiguration configuration;
        private FacturaService facturaService;

        public FacturaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            facturaService = new FacturaService(new FacturaRepository(configuration.GetConnectionString("postgresDB")));
        }
        // Generate crud controller
        [HttpPost]
        [Route("add")]
        public IActionResult add(FacturaDTO factura)
        {
            try
            {
                if (facturaService.add(factura))
                    return Ok("Factura agregada correctamente");
                else
                    return BadRequest("Error al agregar Factura");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult update(FacturaDTO factura)
        {
            try
            {
                if (facturaService.update(factura))
                    return Ok("Factura actualizada correctamente");
                else
                    return BadRequest("Error al actualizar Factura");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("remove")]
        public IActionResult remove(int id)
        {
            try
            {
                if (facturaService.remove(id))
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
        public IActionResult get(int id)
        {
            try
            {
                var cliente = facturaService.get(id);
                if (cliente != null)
                    return Ok(cliente);
                else
                    return BadRequest("Factura no encontrada");
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
                var facturas = facturaService.list();
                if (facturas != null)
                    return Ok(facturas);
                else
                    return BadRequest("No hay Factura registradas");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
