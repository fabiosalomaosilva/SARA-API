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
    public class PatologiasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patologias
        public async Task<ActionResult> Index()
        {
            return View(await db.Patologias.ToListAsync());
        }

        // GET: Patologias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patologia patologia = await db.Patologias.FindAsync(id);
            if (patologia == null)
            {
                return HttpNotFound();
            }
            return View(patologia);
        }

        // GET: Patologias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patologias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,IdArea,Descricao")] Patologia patologia)
        {
            if (ModelState.IsValid)
            {
                db.Patologias.Add(patologia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(patologia);
        }

        // GET: Patologias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patologia patologia = await db.Patologias.FindAsync(id);
            if (patologia == null)
            {
                return HttpNotFound();
            }
            return View(patologia);
        }

        // POST: Patologias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,IdArea,Descricao")] Patologia patologia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patologia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patologia);
        }

        // GET: Patologias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patologia patologia = await db.Patologias.FindAsync(id);
            if (patologia == null)
            {
                return HttpNotFound();
            }
            return View(patologia);
        }

        // POST: Patologias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Patologia patologia = await db.Patologias.FindAsync(id);
            db.Patologias.Remove(patologia);
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
