using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sara.Web.Ef
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("conexao") {}



    }
}
