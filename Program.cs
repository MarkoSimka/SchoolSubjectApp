using Microsoft.Extensions.DependencyInjection;
using School_Subjects_Information_system.Repositories;
using School_Subjects_Information_system.Repositories.Implementation;
using School_Subjects_Information_system.Services;
using School_Subjects_Information_system.Services.Implementation;

public class SchoolSubjectsInformationSystemApp
{
    private readonly ISubjectCatalogService subjectCatalog;

    public SchoolSubjectsInformationSystemApp(ISubjectCatalogService subjectCatalog)
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
            .AddSingleton<ISubjectCatalogService, SubjectCatalogService>()
            .AddSingleton<IExternalApiHandlerService, ExternalApiHandlerService>()
            .AddSingleton<ISubjectRepository, SubjectRepository>()
            .BuildServiceProvider();

            var subjectCatalog = serviceProvider.GetService<ISubjectCatalogService>();
            var app = new SchoolSubjectsInformationSystemApp(subjectCatalog);
            await app.Run();
        }
    }
}
