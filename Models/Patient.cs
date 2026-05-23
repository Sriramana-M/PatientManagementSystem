using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [StringLength(10)]
        public string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        public string? BloodGroup { get; set; }
    }
}