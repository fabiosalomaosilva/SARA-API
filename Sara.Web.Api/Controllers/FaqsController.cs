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
    public class FaqsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Faqs
        public IEnumerable<Faq> GetFaqs()
        {
            return db.Faqs.ToList();
        }

        // GET: api/Faqs/5
        [ResponseType(typeof(Faq))]
        public async Task<IHttpActionResult> GetFaq(int id)
        {
            Faq faq = await db.Faqs.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }

            return Ok(faq);
        }

    }
}