using System.ComponentModel.DataAnnotations;

namespace Sara.Web.Model
{
    public class Acao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(400)]
        [MinLength(10)]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Recomendado")]
        public bool Recomendacao { get; set; }

        [Display(Name = "Área de saúde")]
        public int AreaID { get; set; }
        public Area Area { get; set; }
    }
}