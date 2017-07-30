using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Sara.Web.Api.Models;
using Sara.Web.Model;

namespace Sara.Web.Api.Controllers
{
    public class PatologiasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Patologias
        public IEnumerable<Patologia> GetPatologias()
        {
            return db.Patologias.ToList();
        }

        // GET: api/Patologias/5
        [ResponseType(typeof(Patologia))]
        public async Task<IHttpActionResult> GetPatologia(int id)
        {
            Patologia patologia = await db.Patologias.FindAsync(id);
            if (patologia == null)
            {
                return NotFound();
            }

            return Ok(patologia);
        }


    }
}