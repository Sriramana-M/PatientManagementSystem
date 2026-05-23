using Newtonsoft.Json;
using PatientManagementSystem.AI;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Services
{
    public class AIService
    {
        private readonly KnowledgeBaseLoader _loader;
        private readonly OpenAIClient _client;

        public AIService(
            KnowledgeBaseLoader loader,
            OpenAIClient client)
        {
            _loader = loader;
            _client = client;
        }

        public async Task<string> GetRecommendation(string query)
        {
            query = query.ToLower();

            
            var matchedConditions = _loader.KnowledgeBase
                .Where(x =>
                    x.Disease.ToLower().Contains(query)
                    ||
                    x.Symptoms.Any(s =>
                        s.ToLower().Contains(query)))
                .ToList();

            
            if (!matchedConditions.Any())
            {
                return JsonConvert.SerializeObject(new
                {
                    condition = "No matching condition found",
                    symptoms = new List<string>(),
                    recommendations = new List<string>
                    {
                        "Please provide more symptoms for better analysis"
                    },
                    seeDoctorIf =
                        "Symptoms become severe or persistent"
                });
            }

            
            var knowledgeJson =
                JsonConvert.SerializeObject(
                    matchedConditions,
                    Formatting.Indented);

            
            string prompt = $@"
You are an AI healthcare assistant.

Analyze the patient query carefully.

PATIENT QUERY:
{query}

MATCHED KNOWLEDGE BASE:
{knowledgeJson}

IMPORTANT:
- Use only the provided knowledge base
- Do not invent diseases
- Return concise medical guidance
- Response must be JSON only

JSON FORMAT:
{{
  ""condition"": """",
  ""symptoms"": [],
  ""recommendations"": [],
  ""seeDoctorIf"": """"
}}
";

            
            return await _client.AskAI(prompt);
        }
    }
}





//namespace PatientManagementSystem.Services
//{
//    public class AIService
//    {
//        private readonly KnowledgeRetrievalService _retrieval;
//        private readonly PromptEngineeringService _prompt;
//        private readonly OpenAIService _openAI;

//        public AIService(
//            KnowledgeRetrievalService retrieval,
//            PromptEngineeringService prompt,
//            OpenAIService openAI)
//        {
//            _retrieval = retrieval;
//            _prompt = prompt;
//            _openAI = openAI;
//        }

//        public async Task<string> AnalyzeSymptoms(
//            string query)
//        {

//            var knowledge =
//                _retrieval.RetrieveRelevantKnowledge(query);


//            var prompt =
//                _prompt.BuildHealthcarePrompt(
//                    query,
//                    knowledge);


//            var response =
//                await _openAI.AskGPT(prompt);

//            return response;
//        }
//    }
//}