using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanctionTemplateController : ControllerBase
    {
        private readonly ISanctionTemplateService _service;

        public SanctionTemplateController(ISanctionTemplateService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<SanctionTemplateDTO>>> GetAll()
        {
            var sanctionTypes = await _service.GetAllAsync();

            if (sanctionTypes == null || !sanctionTypes.Any())
            {
                return NotFound("Geen sanctietypes gevonden.");
            }

            return Ok(sanctionTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SanctionTemplateDTO>> GetById(int id)
        {
            var sanctionType = await _service.GetByIdAsync(id);

            if (sanctionType == null)
            {
                return NotFound($"Geen sanctietype gevonden met id: {id}");
            }

            return Ok(sanctionType);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<SanctionTemplateDTO>> Add(SanctionTemplateDTO sanctionType)
        {
            if (sanctionType == null)
            {
                return BadRequest("Sanctietype is leeg.");
            }

            await _service.AddAsync(sanctionType);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<SanctionTemplateDTO>> Update(SanctionTemplateDTO sanctionType)
        {
            if (sanctionType == null)
            {
                return BadRequest("Sanctietype is leeg.");
            }

            await _service.UpdateAsync(sanctionType);

            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<SanctionTemplateDTO>> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
