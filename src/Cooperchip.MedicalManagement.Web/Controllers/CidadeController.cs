using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entities;
using Cooperchip.MedicalManagement.Infra.Data.ORM.EF;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    public class CidadeController : Controller
    {
        private MMDbContext db = new MMDbContext();

        // GET: Cidade
        public async Task<ActionResult> Index()
        {
            var cidade = db.Cidade.Include(c => c.Uf);
            return View(await cidade.ToListAsync());
        }

        // GET: Cidade/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = await db.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            ViewBag.UfId = new SelectList(db.Uf, "Id", "Sigla");
            return View();
        }

        // POST: Cidade/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao,UfId")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidade);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UfId = new SelectList(db.Uf, "Id", "Sigla", cidade.UfId);
            return View(cidade);
        }

        // GET: Cidade/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = await db.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.UfId = new SelectList(db.Uf, "Id", "Sigla", cidade.UfId);
            return View(cidade);
        }

        // POST: Cidade/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao,UfId")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UfId = new SelectList(db.Uf, "Id", "Sigla", cidade.UfId);
            return View(cidade);
        }

        // GET: Cidade/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = await db.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cidade cidade = await db.Cidade.FindAsync(id);
            db.Cidade.Remove(cidade);
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
