using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sara.Web.Model
{
    public class Patologia
    {
        public Patologia()
        {
            Areas = new HashSet<Area>();
            Acoes = new HashSet<Acao>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome da patologia")]
        [MaxLength(50)]
        [MinLength(5)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [MaxLength(400)]
        [MinLength(15)]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }


        public ICollection<Area> Areas { get; set; }
        public ICollection<Acao> Acoes { get; set; }
    }
}