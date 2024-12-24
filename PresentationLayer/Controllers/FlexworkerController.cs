using Microsoft.AspNetCore.Mvc;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlexworkerController : ControllerBase
    {
        private readonly IFlexworkerService _service;
        public FlexworkerController(IFlexworkerService service)
        {
            _service = service;
        }

        [HttpGet("fullname")]
        public async Task<ActionResult<IEnumerable<FlexworkerDTO>>> GetByFullName([FromQuery] string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return BadRequest("De parameter 'fullName' mag niet leeg zijn.");
            }

            var flexworkers = await _service.GetByFullNameAsync(fullName);

            if (flexworkers == null || !flexworkers.Any())
            {
                return NotFound($"Geen flexworkers gevonden met de naam: {fullName}");
            }

            return Ok(flexworkers);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<FlexworkerDTO>>> GetAll()
        {
            var flexworkers = await _service.GetAllAsync();

            // Controleer of er flexworkers beschikbaar zijn
            if (flexworkers == null || !flexworkers.Any())
            {
                return NotFound("Geen flexworkers gevonden.");
            }

            // Retourneer de lijst van flexworkers
            return Ok(flexworkers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlexworkerDTO>> GetById(int id)
        {
            var flexworker = await _service.GetByIdAsync(id);

            if (flexworker == null)
            {
                return NotFound($"Geen flexworker gevonden met id: {id}");
            }

            return Ok(flexworker);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] FlexworkerDTO flexworker)
        {
            if (flexworker == null)
            {
                return BadRequest("Flexworker mag niet leeg zijn.");
            }

            await _service.AddAsync(flexworker);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] FlexworkerDTO flexworker)
        {
            if (flexworker == null)
            {
                return BadRequest("Flexworker mag niet leeg zijn.");
            }

            await _service.UpdateAsync(flexworker);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody] FlexworkerDTO flexworker)
        {
            if (flexworker == null)
            {
                return BadRequest("Flexworker mag niet leeg zijn.");
            }

            await _service.DeleteAsync(flexworker);

            return Ok();
        }

    }
}

