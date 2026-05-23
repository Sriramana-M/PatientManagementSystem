using Microsoft.EntityFrameworkCore;
using PatientManagementSystem.Data;
using PatientManagementSystem.DTOs;
using PatientManagementSystem.Helpers;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;

        public AuthService(ApplicationDbContext context,
                           JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<string> Register(RegisterDto dto)
        {
            var existingUser = await _context.Patients
                .FirstOrDefaultAsync(x => x.EmailId == dto.EmailId);

            if (existingUser != null)
                throw new Exception("Email already exists");

            var patient = new Patient
            {
                PatientName = dto.PatientName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                MobileNumber = dto.MobileNumber,
                EmailId = dto.EmailId,
                Password = PasswordHelper.HashPassword(dto.Password),
                Address = dto.Address,
                BloodGroup = dto.BloodGroup
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return "Registration successful";
        }

        public async Task<string> Login(LoginDto dto)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(x => x.EmailId == dto.EmailId);

            if (patient == null)
                throw new Exception("Invalid credentials");

            bool valid = PasswordHelper.VerifyPassword(
                dto.Password,
                patient.Password);

            if (!valid)
                throw new Exception("Invalid credentials");

            return _jwtService.GenerateToken(patient.EmailId);
        }
    }
}