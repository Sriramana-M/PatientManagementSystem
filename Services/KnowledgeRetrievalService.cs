//using PatientManagementSystem.AI;
//using PatientManagementSystem.Models;

//namespace PatientManagementSystem.Services
//{
//    public class KnowledgeRetrievalService
//    {
//        private readonly KnowledgeBaseLoader _loader;

//        public KnowledgeRetrievalService(
//            KnowledgeBaseLoader loader)
//        {
//            _loader = loader;
//        }

//        public List<HealthKnowledge> RetrieveRelevantKnowledge(
//            string query)
//        {
//            query = query.ToLower();

//            var words = query.Split(' ');

//            var results = _loader.KnowledgeBase
//                .Where(d =>
//                    words.Any(w =>
//                        d.Disease.ToLower().Contains(w)
//                        ||
//                        d.Symptoms.Any(s =>
//                            s.ToLower().Contains(w))))
//                .Take(5)
//                .ToList();

//            // fallback
//            if (!results.Any())
//            {
//                results = _loader.KnowledgeBase
//                    .Take(3)
//                    .ToList();
//            }

//            return results;
//        }
//    }
//}