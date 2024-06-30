using School_Subjects_Information_system.Models;

namespace School_Subjects_Information_system.Services
{
    public interface ISubjectCatalogService
    {
        List<Subject> LoadSubjects();
        void ListSubjects(List<Subject> subjects);
        void ChooseSubject(List<Subject> subjects);
        void DisplayInformation(Subject subject);
        void DisplayMoreInformation(Subject subject);
    }
}
