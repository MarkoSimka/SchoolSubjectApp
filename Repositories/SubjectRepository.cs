using Newtonsoft.Json;
using School_Subjects_Information_system.Models;

namespace School_Subjects_Information_system.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly string filePath = "Data/Subjects.json";

        /// <summary>
        /// Retrieves a list of subjects from a JSON file.
        /// </summary>
        /// <returns>A list of subjects. If the file does not exist, returns an empty list.</returns>
        public List<Subject> GetAllSubjectsFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Subject>>(json);
            }
            else
            {
                Console.WriteLine("Subjects file not found.");
                return new List<Subject>();
            }
        }
    }
}
