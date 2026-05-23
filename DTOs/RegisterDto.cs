namespace PatientManagementSystem.DTOs
{
    public class RegisterDto
    {
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string? BloodGroup { get; set; }
    }
}