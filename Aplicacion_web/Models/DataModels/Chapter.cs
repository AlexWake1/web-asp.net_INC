using System.ComponentModel.DataAnnotations;

namespace Aplicacion_web.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        [Required]
        public string List { get; set; } = string.Empty;

        public int CursoID { get; set; }

        public Curso Curso { get; set; } = new Curso();


    }
}
