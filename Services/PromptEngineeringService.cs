//using Newtonsoft.Json;
//using PatientManagementSystem.Models;

//namespace PatientManagementSystem.Services
//{
//    public class PromptEngineeringService
//    {
//        public string BuildHealthcarePrompt(
//            string patientQuery,
//            List<HealthKnowledge> knowledge)
//        {
//            var knowledgeJson =
//                JsonConvert.SerializeObject(
//                    knowledge,
//                    Formatting.Indented);

//            return $@"
//You are an advanced AI Healthcare Assistant.

//Your responsibilities:
//- Analyze symptoms intelligently
//- Infer possible conditions
//- Use ONLY the provided knowledge base
//- Do not hallucinate
//- Do not invent diseases
//- Provide structured medical guidance

//PATIENT QUERY:
//{patientQuery}

//RELEVANT MEDICAL KNOWLEDGE:
//{knowledgeJson}

//IMPORTANT:
//- Infer the most likely condition
//- Explain symptom matching
//- Give actionable recommendations
//- Mention doctor consultation warning

//RETURN STRICT JSON ONLY.

//FORMAT:
//{{
//  ""condition"": """",
//  ""reasoning"": """",
//  ""symptoms"": [],
//  ""recommendations"": [],
//  ""seeDoctorIf"": """"
//}}
//";
//        }
//    }
//}