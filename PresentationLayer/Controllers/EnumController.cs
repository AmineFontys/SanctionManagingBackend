using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanctionManagingBackend.ApplicationLayer.Interface;

namespace SanctionManagingBackend.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        private readonly IEnumService _enumService;
        public EnumController(IEnumService enumService)
        {
            _enumService = enumService;
        }
        [HttpGet("GetEnums")]
        public IActionResult GetEnums()
        {
            return Ok(_enumService.GetEnums());
        }
    }
}
