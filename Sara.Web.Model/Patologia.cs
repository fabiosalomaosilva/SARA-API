using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sara.Web.Model
{
    public class Patologia
    {
        public Patologia()
        {
            Acoes = new HashSet<Acao>();
        }
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public int IdArea { get; set; }
        public virtual Area Area { get; set; }

        public virtual ICollection<Acao> Acoes { get; set; }
    }
}