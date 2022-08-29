using Aplicacion_web.Models.DataModels;
using Microsoft.EntityFrameworkCore;
namespace Aplicacion_web.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }
        //TODO: add dbsets (tables of our data base)

        public DbSet<User>? Users { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
    }
}
