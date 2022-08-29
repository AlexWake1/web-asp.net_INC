using System.ComponentModel.DataAnnotations;

namespace Aplicacion_web.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    }
}
