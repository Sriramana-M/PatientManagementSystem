using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientManagementSystem.DTOs;
using PatientManagementSystem.Services.Interfaces;

namespace PatientManagementSystem.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/patient/1
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient =
                await _patientService.GetPatientById(id);

            return Ok(patient);
        }

        // PUT: api/patient/update/1
        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePatient(
            int id,
            PatientUpdateDto dto)
        {
            var result =
                await _patientService.UpdatePatient(id, dto);

            return Ok(new
            {
                message = result
            });
        }
    }
}