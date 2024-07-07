using School_Subjects_Information_system.Models;
using School_Subjects_Information_system.Repositories;
using School_Subjects_Information_system.Services;

namespace School_Subjects_Information_system.Services.Implementation
{
    public class SubjectCatalogService : ISubjectCatalogService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectCatalogService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository ?? throw new ArgumentNullException(nameof(subjectRepository));
        }

        /// <summary>
        /// Loads the list of subjects from the local file and API.
        /// </summary>
        /// <returns>A list of subjects.</returns>
        public List<Subject> LoadSubjects()
        {
            var subjects = new List<Subject>();

            var subjectsFromFile = _subjectRepository.GetAllSubjectsFromFile();
            var subjectsFromApi = new ExternalApiHandlerService().FetchSubjects().Result;

            if (subjectsFromFile != null)
            {
                subjects.AddRange(subjectsFromFile);
            }

            if (subjectsFromApi != null)
            {
                subjects.AddRange(subjectsFromApi);
            }

            return subjects;
        }

        /// <summary>
        /// Displays a list of subjects to the console.
        /// </summary>
        /// <param name="subjects">The list of subjects to display.</param>
        public void ListSubjects(List<Subject> subjects)
        {
            Console.WriteLine("\nSelect a subject to view details:");
            if (subjects?.Count > 0)
            {
                subjects
                    .Select((subject, index) => $"{index + 1}. {subject.Name}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("No subjects available.");
            }
        }

        /// <summary>
        /// Allows the user to choose a subject from the list and view its details.
        /// </summary>
        /// <param name="subjects">The list of subjects to choose from.</param>
        public void ChooseSubject(List<Subject> subjects)
        {
            if (subjects == null || subjects.Count == 0)
            {
                Console.WriteLine("No subjects available to choose from.");
                return;
            }

            Console.WriteLine("Choose a subject: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            if (choice > 0 && choice <= subjects.Count)
            {
                Subject selectedSubject = subjects[choice - 1];
                DisplayInformation(selectedSubject);

                Console.WriteLine("Would you like to see more details about this subject? (y/n)");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    DisplayMoreInformation(selectedSubject);
                }
            }
            else if (choice == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a number from the menu.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays basic information about a subject.
        /// </summary>
        /// <param name="subject">The subject to display information about.</param>
        public void DisplayInformation(Subject subject)
        {
            if (subject == null)
            {
                Console.WriteLine("No subject selected.");
                return;
            }

            Console.WriteLine($"Subject ID: {subject.Id}");
            Console.WriteLine($"Subject: {subject.Name}");
            Console.WriteLine($"Description: {subject.Description}");
            Console.WriteLine($"Weekly Classes: {subject.WeeklyClasses}");
            Console.WriteLine("Literature used: ");
            if (subject.LiteratureUsed?.Count > 0)
            {
                subject.LiteratureUsed
                    .Select((literature, index) => $"- {literature}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("No information about the used literature.");
            }
        }

        /// <summary>
        /// Displays additional information about a subject.
        /// </summary>
        /// <param name="subject">The subject to display more information about.</param>
        public void DisplayMoreInformation(Subject subject)
        {
            if (subject == null)
            {
                Console.WriteLine("No subject selected.");
                return;
            }

            Console.WriteLine($"More details about {subject.Name} (ID: {subject.Id}):");
            Console.WriteLine("Additional properties: ");
            Console.WriteLine($"Teacher - {subject.AdditionalProperties?.Teacher}");
            Console.WriteLine($"Room - {subject.AdditionalProperties?.Room}");
            Console.WriteLine($"Grade level - {subject.AdditionalProperties?.GradeLevel}");

        }

    }
}
