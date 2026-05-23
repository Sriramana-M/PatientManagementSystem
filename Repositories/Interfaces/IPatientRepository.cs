using PatientManagementSystem.DTOs;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientById(int id);

        Task UpdatePatient(int id, PatientUpdateDto dto);
    }
}