using School_Subjects_Information_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Subjects_Information_system.Services
{
    public interface IExternalApiHandlerService
    {
        Task<List<Subject>> FetchSubjects();
    }
}
