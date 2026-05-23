namespace PatientManagementSystem.DTOs
{
    public class PatientUpdateDto
    {
        public string PatientName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string EmailId { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string? BloodGroup { get; set; }
    }
}