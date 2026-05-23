using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientManagementSystem.DTOs;
using PatientManagementSystem.Services;

namespace PatientManagementSystem.Controllers
{
    [ApiController]
    [Route("api/ai")]
    public class AIController : ControllerBase
    {
        private readonly AIService _aiService;

        public AIController(AIService aiService)
        {
            _aiService = aiService;
        }

        [Authorize]
        [HttpPost("recommend")]
        public async Task<IActionResult> Recommend(AIRequestDto dto)
        {
            var result =
                await _aiService.GetRecommendation(dto.Query);

            return Ok(result);
        }
    }
}