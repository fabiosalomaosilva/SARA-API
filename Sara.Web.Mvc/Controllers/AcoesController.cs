using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sara.Web.Model;
using Sara.Web.Mvc.Models;

namespace Sara.Web.Mvc.Controllers
{
    [Authorize]
    public class AcoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Acoes
        public async Task<ActionResult> Index()
        {
            var acoes = db.Acoes.Include(a => a.Area);
            return View(await acoes.ToListAsync());
        }

        // GET: Acoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acao acao = await db.Acoes.FindAsync(id);
            if (acao == null)
            {
                return HttpNotFound();
            }
            return View(acao);
        }

        // GET: Acoes/Create
        public ActionResult Create()
        {
            var listaAreas = db.Areas.ToList();
            var listaPatologia = db.Patologias.ToList();
            var lista = new List<Area>();
            foreach (var i in listaAreas)
            {
                var nome = $"{i.Nome} - {listaPatologia.FirstOrDefault(p => p.Id == i.PatologiaID).Nome}";
                lista.Add(new Area{ Nome = nome, Id = i.Id, PatologiaID = i.PatologiaID});
            }
            ViewBag.AreaID = new SelectList(lista, "Id", "Nome");
            ViewBag.PatologiaID = new SelectList(listaPatologia, "Id", "Nome");
            return View();
        }

        // POST: Acoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Recomendacao,PatologiaID,AreaID")] Acao acao)
        {
            if (ModelState.IsValid)
            {
                db.Acoes.Add(acao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AreaID = new SelectList(db.Areas, "Id", "Nome", acao.AreaID);
            return View(acao);
        }

        // GET: Acoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acao acao = await db.Acoes.FindAsync(id);
            if (acao == null)
            {
                return HttpNotFound();
            }
            var listaAreas = db.Areas.ToList();
            var listaPatologia = db.Patologias.ToList();
            var lista = new List<Area>();
            foreach (var i in listaAreas)
            {
                var nome = $"{i.Nome} - {listaPatologia.FirstOrDefault(p => p.Id == i.PatologiaID).Nome}";
                lista.Add(new Area { Nome = nome, Id = i.Id, PatologiaID = i.PatologiaID });
            }

            ViewBag.AreaID = new SelectList(lista, "Id", "Nome", acao.AreaID);
            return View(acao);
        }

        // POST: Acoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Recomendacao,PatologiaID,AreaID")] Acao acao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var listaAreas = db.Areas.ToList();
            var listaPatologia = db.Patologias.ToList();
            var lista = new List<Area>();
            foreach (var i in listaAreas)
            {
                var nome = $"{i.Nome} - {listaPatologia.FirstOrDefault(p => p.Id == i.PatologiaID).Nome}";
                lista.Add(new Area { Nome = nome, Id = i.Id, PatologiaID = i.PatologiaID });
            }

            ViewBag.AreaID = new SelectList(lista, "Id", "Nome", acao.AreaID);
            return View(acao);
        }

        // GET: Acoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acao acao = await db.Acoes.FindAsync(id);
            if (acao == null)
            {
                return HttpNotFound();
            }
            return View(acao);
        }

        // POST: Acoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Acao acao = await db.Acoes.FindAsync(id);
            db.Acoes.Remove(acao);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
