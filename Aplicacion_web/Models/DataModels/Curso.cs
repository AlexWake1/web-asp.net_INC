using System.ComponentModel.DataAnnotations;

namespace Aplicacion_web.Models.DataModels
{
    public enum Nivel
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }
    public class Curso : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string Short_Description { get; set; } = string.Empty;
        [Required]
        public string Large_Description { get; set; } = string.Empty;
        [Required]
        public Nivel Level { get; set; } = Nivel.Basic;
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        [Required]
        public Chapter Index { get; set; } = new Chapter();
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();


    }
}
