using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.ApplicationLayer.Service;
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

        [HttpGet("GetByFlexworker/{flexworkerId}")]
        public async Task<IActionResult> GetByFlexworker(int flexworkerId)
        {
            try
            {
                var sanctions = await _service.GetSanctionsByFlexworkerIdAsync(flexworkerId);

                if (sanctions == null || !sanctions.Any())
                    return Ok(new List<SanctionDTO>());

                return Ok(sanctions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Interne fout: {ex.Message}");
            }
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

        [HttpPost("Create")]
        public async Task<ActionResult> Create(CreateSanctionDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.CreateSanctionAsync(dto);

            if (!result.Success)
            {
                return BadRequest(new { error = result.Error });
            }

            return Ok(new { message = "Sanctie succesvol aangemaakt." });
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

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            await _service.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("downloadPdf/{sanctionId}")]
        public async Task<IActionResult> DownloadPdf(int sanctionId)
        {
            var pdfData = await _service.GetSanctionPdfAsync(sanctionId);

            if (pdfData == null)
            {
                return NotFound("Sanctie of PDF niet gevonden.");
            }

            return File(pdfData, "application/pdf", $"Sanctie_{sanctionId}.pdf");
        }
    }
}
