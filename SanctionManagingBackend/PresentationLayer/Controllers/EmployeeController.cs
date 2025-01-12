using Microsoft.AspNetCore.Mvc;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.DTO;

namespace SanctionManagingBackend.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAll()
        {
            var employees = await _service.GetAllAsync();

            if (employees == null || !employees.Any())
            {
                return NotFound("Geen medewerkers gevonden.");
            }

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound($"Geen medewerker gevonden met id: {id}");
            }

            return Ok(employee);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<EmployeeDTO>> Add(EmployeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest("Medewerker is leeg.");
            }

            await _service.AddAsync(employee);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<EmployeeDTO>> Update(int id, EmployeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest("Medewerker is leeg.");
            }

            await _service.UpdateAsync(employee);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}