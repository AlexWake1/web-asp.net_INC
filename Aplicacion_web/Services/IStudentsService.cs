
using Aplicacion_web.Models.DataModels;

namespace Aplicacion_web.Services
{
    public interface IStudentsService
    {
       
        IEnumerable<Student> GetStudentWithCourses();
        IEnumerable<Student> GetStudentWithNoCourses();
    }

}
