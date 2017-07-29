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
    public class AcoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Acoes
        public IQueryable<Acao> GetAcaos()
        {
            return db.Acaos;
        }

        // GET: api/Acoes/5
        [ResponseType(typeof(Acao))]
        public async Task<IHttpActionResult> GetAcao(int id)
        {
            Acao acao = await db.Acaos.FindAsync(id);
            if (acao == null)
            {
                return NotFound();
            }

            return Ok(acao);
        }

        // PUT: api/Acoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAcao(int id, Acao acao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acao.Id)
            {
                return BadRequest();
            }

            db.Entry(acao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcaoExists(id))
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

        // POST: api/Acoes
        [ResponseType(typeof(Acao))]
        public async Task<IHttpActionResult> PostAcao(Acao acao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Acaos.Add(acao);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = acao.Id }, acao);
        }

        // DELETE: api/Acoes/5
        [ResponseType(typeof(Acao))]
        public async Task<IHttpActionResult> DeleteAcao(int id)
        {
            Acao acao = await db.Acaos.FindAsync(id);
            if (acao == null)
            {
                return NotFound();
            }

            db.Acaos.Remove(acao);
            await db.SaveChangesAsync();

            return Ok(acao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AcaoExists(int id)
        {
            return db.Acaos.Count(e => e.Id == id) > 0;
        }
    }
}