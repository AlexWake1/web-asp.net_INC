using Aplicacion_web.DataAccess;
using Aplicacion_web.Models.DataModels;


namespace Aplicacion_web.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly UniversityDBContext _context;
        public  IEnumerable<Student> GetStudentWithCourses()
        {

            var b = from student in _context.Students
                    where student.Cursos.Count > 0
                    select student;
            
            return b;
            
        }
        public IEnumerable<Student> GetStudentWithNoCourses()
        {
            var b = from student in _context.Students
                    where student.Cursos.Count == 0
                    select student;

            return b;
        }
    }
}
