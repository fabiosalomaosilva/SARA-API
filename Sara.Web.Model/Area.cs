using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sara.Web.Model
{
    public class Area
    {
        public Area()
        {
            Patologias = new HashSet<Patologia>();
        }
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public virtual ICollection<Patologia> Patologias { get; set; }
    }
}
