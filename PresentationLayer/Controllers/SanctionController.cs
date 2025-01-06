using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.ApplicationLayer.Service;
using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SanctionManagingBackend.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanctionController : ControllerBase
    {
        private readonly ISanctionService _service;
        private readonly WordConverter _wordConverter;


        public SanctionController(ISanctionService service, WordConverter wordConverter)
        {
            _service = service;
            _wordConverter = wordConverter;
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
        public async Task<ActionResult<SanctionDTO>> Create(SanctionDTO sanctionDto)
        {
            if (sanctionDto == null)
            {
                return BadRequest("Ongeldige invoer.");
            }
            
            await _service.AddAsync(sanctionDto);

            return Ok("Sanctie succesvol aangemaakt.");
        }

        [HttpPost("generate")]
        public IActionResult Generate([FromBody] GenerateSanctionRequest request)
        {
            try
            {
                // Validatie van de request
                if (request == null || string.IsNullOrEmpty(request.WordBase64) || request.Placeholders == null)
                {
                    return BadRequest("Invalid request payload.");
                }

                // 1. Base64 -> byte[]
                byte[] docxBytes;
                try
                {
                    docxBytes = Convert.FromBase64String(request.WordBase64);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Format Error: {fe.Message}");
                    return BadRequest("Invalid Base64 string.");
                }
                Console.WriteLine("DOCX bytes gedecodeerd.");

                // 2. Placeholder-vervanging met Open XML SDK
                byte[] updatedDocxBytes = WordTemplateProcessor.ReplacePlaceholders(docxBytes, request.Placeholders);
                Console.WriteLine("Placeholders vervangen.");

                // **Nieuw: Sla het aangepaste DOCX-bestand op voor inspectie (optioneel)**
                var inspectDocxPath = Path.Combine(Path.GetTempPath(), $"inspect-{Guid.NewGuid()}.docx");
                System.IO.File.WriteAllBytes(inspectDocxPath, updatedDocxBytes);
                Console.WriteLine($"Aangepast DOCX voor inspectie opgeslagen op: {inspectDocxPath}");

                // 3. Converteer DOCX naar PDF met Word Interop
                byte[] pdfBytes = _wordConverter.ConvertDocxToPdf(updatedDocxBytes);
                Console.WriteLine("DOCX geconverteerd naar PDF.");

                // **Optioneel: Sla het PDF-bestand ook op voor inspectie**
                var inspectPdfPath = Path.Combine(Path.GetTempPath(), $"inspect-{Guid.NewGuid()}.pdf");
                System.IO.File.WriteAllBytes(inspectPdfPath, pdfBytes);
                Console.WriteLine($"Gegenereerd PDF voor inspectie opgeslagen op: {inspectPdfPath}");

                // 4. Stuur PDF terug
                return File(pdfBytes, "application/pdf", "sanctie.pdf");
            }
            catch (COMException comEx)
            {
                Console.WriteLine($"COM Exception: {comEx.Message}");
                return StatusCode(500, $"Fout bij het starten van Word Interop: {comEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout: {ex.Message}");
                return StatusCode(500, $"Fout bij genereren van de sanctie: {ex.Message}");
            }
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
