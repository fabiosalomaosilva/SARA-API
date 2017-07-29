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
        public IQueryable<Patologia> GetPatologias()
        {
            return db.Patologias;
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

        // PUT: api/Patologias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatologia(int id, Patologia patologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patologia.Id)
            {
                return BadRequest();
            }

            db.Entry(patologia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatologiaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Patologias
        [ResponseType(typeof(Patologia))]
        public async Task<IHttpActionResult> PostPatologia(Patologia patologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patologias.Add(patologia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = patologia.Id }, patologia);
        }

        // DELETE: api/Patologias/5
        [ResponseType(typeof(Patologia))]
        public async Task<IHttpActionResult> DeletePatologia(int id)
        {
            Patologia patologia = await db.Patologias.FindAsync(id);
            if (patologia == null)
            {
                return NotFound();
            }

            db.Patologias.Remove(patologia);
            await db.SaveChangesAsync();

            return Ok(patologia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatologiaExists(int id)
        {
            return db.Patologias.Count(e => e.Id == id) > 0;
        }
    }
}