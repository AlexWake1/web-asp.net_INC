using System.ComponentModel.DataAnnotations;
namespace Aplicacion_web.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string FistName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime FNAC { get; set; }
        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();


    }
}
