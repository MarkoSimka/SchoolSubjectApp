using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using School_Subjects_Information_system.Models;

namespace School_Subjects_Information_system.Services
{
    /// <summary>
    /// Handles fetching subjects from an external API.
    /// </summary>
    /// <remarks>
    /// This class encapsulates the logic for making HTTP requests to retrieve subject data.
    /// Error handling ensures robustness against network failures or unexpected API responses.
    /// </remarks>
    internal class ExternalApiHandlerService
    {
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Fetches a list of subjects from an external API.
        /// </summary>
        /// <returns>A list of subjects fetched from the API. Returns an empty list if no subjects are fetched or if an error occurs.</returns>
        public async Task<List<Subject>> FetchSubjects()
        {
            string apiUrl = "http://localhost:5055/SchoolSubject";
            List<Subject> newSubjects = new List<Subject>();
            try
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync(apiUrl);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                JArray data = JArray.Parse(responseBody);

                return JsonConvert.DeserializeObject<List<Subject>>(data.ToString());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return new List<Subject>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
                return new List<Subject>();
            }
        }
    }
}