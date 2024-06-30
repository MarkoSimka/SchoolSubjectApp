using School_Subjects_Information_system.Models;

namespace School_Subjects_Information_system.Repositories
{
    public interface ISubjectRepository
    {
        public List<Subject> GetAllSubjectsFromFile();
    }
}
