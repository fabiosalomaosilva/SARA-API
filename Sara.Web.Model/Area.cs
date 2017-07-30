using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sara.Web.Model
{
    public class Area
    {
        public Area()
        {
            Acoes = new HashSet<Acao>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        [Display(Name = "Área da saúde")]
        public string Nome { get; set; }

        [Display(Name = "Patologia")]
        public int PatologiaID { get; set; }
        public Patologia Patologia { get; set; }


        public ICollection<Acao> Acoes { get; set; }
    }
}
