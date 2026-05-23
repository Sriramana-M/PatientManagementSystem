using Microsoft.EntityFrameworkCore;
using PatientManagementSystem.Data;
using PatientManagementSystem.DTOs;
using PatientManagementSystem.Models;
using PatientManagementSystem.Repositories.Interfaces;

namespace PatientManagementSystem.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(x => x.PatientId == id);
        }

        public async Task UpdatePatient(
            int id,
            PatientUpdateDto dto)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(x => x.PatientId == id);

            if (patient == null)
            {
                throw new Exception("Patient not found");
            }

            patient.PatientName = dto.PatientName;
            patient.DateOfBirth = dto.DateOfBirth;
            patient.Gender = dto.Gender;
            patient.MobileNumber = dto.MobileNumber;
            patient.EmailId = dto.EmailId;
            patient.Address = dto.Address;
            patient.BloodGroup = dto.BloodGroup;

            await _context.SaveChangesAsync();
        }
    }
}