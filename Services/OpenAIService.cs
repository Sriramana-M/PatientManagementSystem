//using System.Text;
//using Newtonsoft.Json;

//namespace PatientManagementSystem.Services
//{
//    public class OpenAIService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly IConfiguration _configuration;

//        public OpenAIService(
//            HttpClient httpClient,
//            IConfiguration configuration)
//        {
//            _httpClient = httpClient;
//            _configuration = configuration;
//        }

//        public async Task<string> AskGPT(string prompt)
//        {
//            _httpClient.DefaultRequestHeaders.Clear();

//            _httpClient.DefaultRequestHeaders.Authorization =
//                new System.Net.Http.Headers
//                .AuthenticationHeaderValue(
//                    "Bearer",
//                    _configuration["OpenAI:ApiKey"]);

//            var requestBody = new
//            {
//                model = "gpt-4o-mini",

//                messages = new object[]
//                {
//                    new
//                    {
//                        role = "system",
//                        content =
//                            "You are an expert AI healthcare assistant."
//                    },

//                    new
//                    {
//                        role = "user",
//                        content = prompt
//                    }
//                },

//                temperature = 0.3
//            };

//            var json =
//                JsonConvert.SerializeObject(requestBody);

//            var response = await _httpClient.PostAsync(
//                "https://api.openai.com/v1/chat/completions",

//                new StringContent(
//                    json,
//                    Encoding.UTF8,
//                    "application/json"));

//            response.EnsureSuccessStatusCode();

//            var result =
//                await response.Content.ReadAsStringAsync();

//            dynamic data =
//                JsonConvert.DeserializeObject(result)!;

//            return data.choices[0].message.content.ToString();
//        }
//    }
//}