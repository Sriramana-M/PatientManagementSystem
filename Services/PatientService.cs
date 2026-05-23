using PatientManagementSystem.DTOs;
using PatientManagementSystem.Models;
using PatientManagementSystem.Repositories.Interfaces;
using PatientManagementSystem.Services.Interfaces;

namespace PatientManagementSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _repository.GetPatientById(id);
        }

        public async Task<string> UpdatePatient(
            int id,
            PatientUpdateDto dto)
        {
            await _repository.UpdatePatient(id, dto);

            return "Patient updated successfully";
        }
    }
}