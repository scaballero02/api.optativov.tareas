using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Modelos;
using Services;
using System.Threading.Tasks;

namespace api.optativov.persona.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(FacturaDTO factura)
        {
            try
            {
                if (await _facturaService.Add(factura))
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
        public async Task<IActionResult> Update(FacturaDTO factura)
        {
            try
            {
                if (await _facturaService.Update(factura))
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
        [Route("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                if (await _facturaService.Remove(id))
                    return Ok("Factura eliminada correctamente");
                else
                    return BadRequest("Error al eliminar Factura");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var factura = await _facturaService.Get(id);
                if (factura != null)
                    return Ok(factura);
                else
                    return NotFound("Factura no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                var facturas = await _facturaService.List();
                if (facturas != null)
                    return Ok(facturas);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
