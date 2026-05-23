using PatientManagementSystem.DTOs;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> GetPatientById(int id);

        Task<string> UpdatePatient(int id, PatientUpdateDto dto);
    }
}