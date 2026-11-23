using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhysiotherapyApp.Application.DTOs;
using PhysiotherapyApp.Application.Services;

namespace PhysiotherapyApp.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(
            IPatientService service)
        {
            _service = service;
        }

        // GET: api/clients
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var estudiantes = await _service.ObtenerTodosAsync();

            return Ok(estudiantes);
        }

        // GET: api/clients/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var client = await _service.ObtenerPorIdAsync(id);

            if (client is null)
                return NotFound();

            return Ok(client);
        }

        // POST: api/clients
        [HttpPost]
        public async Task<IActionResult> Crear(
            [FromBody] PatientCrearDto dto)
        {
            try
            {
                var client = await _service.CrearAsync(dto);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = client.Id },
                    client);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
        }

        // PUT: api/clients/1
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(
            int id,
            [FromBody] PatientActualizarDto dto)
        {
            try
            {
                var actualizado = await _service
                    .ActualizarAsync(id, dto);

                if (!actualizado)
                    return NotFound();

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
        }

        // DELETE: api/clients/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _service.EliminarAsync(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}