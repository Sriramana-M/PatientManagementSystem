using System.Text;
using Newtonsoft.Json;

namespace PatientManagementSystem.AI
{
    public class OpenAIClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OpenAIClient(HttpClient httpClient,
                            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> AskAI(string prompt)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    _configuration["OpenAI:ApiKey"]);

            var request = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
                    new {
                        role = "user",
                        content = prompt
                    }
                }
            };

            var json = JsonConvert.SerializeObject(request);

            var response = await _httpClient.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                new StringContent(json, Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(result);

            return data.choices[0].message.content.ToString();
        }
    }
}