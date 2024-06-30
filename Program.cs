using Microsoft.Extensions.DependencyInjection;
using School_Subjects_Information_system.Controller;
using School_Subjects_Information_system.Repositories;

public class SchoolSubjectsInformationSystemApp
{
    private readonly SubjectCatalogService subjectCatalog;

    public SchoolSubjectsInformationSystemApp(SubjectCatalogService subjectCatalog)
    {
        this.subjectCatalog = subjectCatalog;
    }

    public Task Run()
    {
        while (true)
        {
            var subjects = subjectCatalog.LoadSubjects();
            subjectCatalog.ListSubjects(subjects);
            subjectCatalog.ChooseSubject(subjects);
        }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<SubjectCatalogService>()
            .AddSingleton<ISubjectRepository, SubjectRepository>()
            .BuildServiceProvider();

            var subjectCatalog = serviceProvider.GetService<SubjectCatalogService>();
            var app = new SchoolSubjectsInformationSystemApp(subjectCatalog);
            await app.Run();
        }
    }
}
