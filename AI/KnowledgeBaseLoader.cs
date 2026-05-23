using Newtonsoft.Json;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.AI
{
    public class KnowledgeBaseLoader
    {
        public List<HealthKnowledge> KnowledgeBase { get; set; }

        public KnowledgeBaseLoader()
        {
            var json = File.ReadAllText("health_knowledge.json");

            KnowledgeBase =
                JsonConvert.DeserializeObject<List<HealthKnowledge>>(json);
        }
    }
}


//using Newtonsoft.Json;
//using PatientManagementSystem.Models;

//namespace PatientManagementSystem.AI
//{
//    public class KnowledgeBaseLoader
//    {
//        public List<HealthKnowledge> KnowledgeBase { get; set; }

//        public KnowledgeBaseLoader()
//        {
//            var path = Path.Combine(
//                Directory.GetCurrentDirectory(),
//                "AI",
//                "KnowledgeBase",
//                "health_knowledge.json");

//            var json = File.ReadAllText(path);

//            KnowledgeBase =
//                JsonConvert.DeserializeObject<
//                    List<HealthKnowledge>>(json)!;
//        }
//    }
//}