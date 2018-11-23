using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entities;
using Cooperchip.MedicalManagement.Infra.Data.ORM.EF;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    public class UfController : Controller
    {
        private MMDbContext db = new MMDbContext();

        // GET: Uf
        public async Task<ActionResult> Index()
        {
            return View(await db.Uf.ToListAsync());
        }

        // GET: Uf/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uf uf = await db.Uf.FindAsync(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // GET: Uf/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uf/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sigla,Estado,CodigoEstado")] Uf uf)
        {
            if (ModelState.IsValid)
            {
                db.Uf.Add(uf);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(uf);
        }

        // GET: Uf/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uf uf = await db.Uf.FindAsync(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // POST: Uf/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sigla,Estado,CodigoEstado")] Uf uf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uf).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(uf);
        }

        // GET: Uf/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uf uf = await db.Uf.FindAsync(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // POST: Uf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Uf uf = await db.Uf.FindAsync(id);
            db.Uf.Remove(uf);
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
