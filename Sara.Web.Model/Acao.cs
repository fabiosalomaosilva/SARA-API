using System.ComponentModel.DataAnnotations;

namespace Sara.Web.Model
{
    public class Acao
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public bool Recomendacao { get; set; }

        public int IdPatologia { get; set; }
        public virtual Patologia Patologia { get; set; }
    }
}