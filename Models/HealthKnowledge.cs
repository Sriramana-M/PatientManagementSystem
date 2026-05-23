using Newtonsoft.Json;

namespace PatientManagementSystem.Models
{
    public class HealthKnowledge
    {
        [JsonProperty("disease")]
        public string Disease { get; set; }

        [JsonProperty("symptoms")]
        public List<string> Symptoms { get; set; }

        [JsonProperty("recommendations")]
        public List<string> Recommendations { get; set; }

        [JsonProperty("see_doctor_if")]
        public string SeeDoctorIf { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}