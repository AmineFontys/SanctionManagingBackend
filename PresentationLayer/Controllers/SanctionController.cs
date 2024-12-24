using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanctionController : ControllerBase
    {
        private readonly ISanctionService _service;

        public SanctionController(ISanctionService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<SanctionDTO>>> GetAll()
        {
            var sanctions = await _service.GetAllAsync();

            if (sanctions == null || !sanctions.Any())
            {
                return NotFound("Geen sancties gevonden.");
            }

            return Ok(sanctions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SanctionDTO>> GetById(int id)
        {
            var sanction = await _service.GetByIdAsync(id);

            if (sanction == null)
            {
                return NotFound($"Geen sanctie gevonden met id: {id}");
            }

            return Ok(sanction);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<SanctionDTO>> Add(SanctionDTO sanction)
        {
            if (sanction == null)
            {
                return BadRequest("Sanctie is leeg.");
            }

            await _service.AddAsync(sanction);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<SanctionDTO>> Update(SanctionDTO sanction)
        {
            if (sanction == null)
            {
                return BadRequest("Sanctie is leeg.");
            }

            await _service.UpdateAsync(sanction);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(SanctionDTO sanction)
        {
            if (sanction == null)
            {
                return BadRequest("Sanctie is leeg.");
            }

            await _service.DeleteAsync(sanction);

            return Ok();
        }
    }
}
