using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Classwork_16._02._24_auth_authorization__2.Models
{
    public class API
    {
        private static string apiUrl = "https://api.api-ninjas.com/v1/dadjokes?limit=1";
        private static string apiKey = "y3PM2Z4xoTFeng2Cm/UfaQ==3QAFbj4jFAhDqCAs";

        public async static Task<string> Generate()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<Joke>? jokes = JsonConvert.DeserializeObject<List<Joke>>(jsonResponse);

                    return jokes[0].joke;
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
        }
    }
}
