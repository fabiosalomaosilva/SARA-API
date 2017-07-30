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
    public class AreasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Areas
        public IEnumerable<Area> GetAreas()
        {
            return db.Areas.ToList();
        }

        // GET: api/Areas/5
        [ResponseType(typeof(Area))]
        public async Task<IHttpActionResult> GetArea(int id)
        {
            Area area = await db.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            return Ok(area);
        }

    }
}