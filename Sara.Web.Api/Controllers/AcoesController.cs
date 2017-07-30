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
        public IEnumerable<Acao> GetAcaos()
        {
            return db.Acaos.ToList();
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


    }
}