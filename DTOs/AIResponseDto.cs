namespace PatientManagementSystem.DTOs
{
    public class AIResponseDto
    {
        public string Condition { get; set; }

        public List<string> Symptoms { get; set; }

        public List<string> Recommendations { get; set; }

        public string SeeDoctorIf { get; set; }
    }
}
