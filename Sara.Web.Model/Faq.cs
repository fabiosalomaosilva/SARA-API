using System.ComponentModel.DataAnnotations;

namespace Sara.Web.Model
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Pergunta { get; set; }

        [Required]
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Resposta { get; set; }

    }
}