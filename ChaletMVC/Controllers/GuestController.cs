using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ChaletMVC.Models;

namespace ChaletMVC.Controllers
{
    public class GuestController : Controller
    {
        private ChaletDb db = new ChaletDb();

        //
        // GET: /Guest/

        public ActionResult Index()
        {
            var guests = db.Guests.Include(g => g.Chalet);
            return View(guests.ToList());
        }

        //
        // GET: /Guest/Details/5

        public ActionResult Details(int id = 0)
        {
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        //
        // GET: /Guest/Create

        public ActionResult Create()
        {
            ViewBag.ChaletId = new SelectList(db.Chalets, "ChaletId", "ChaletName");
            return View();
        }

        //
        // POST: /Guest/Create

        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChaletId = new SelectList(db.Chalets, "ChaletId", "ChaletName", guest.ChaletId);
            return View(guest);
        }

        //
        // GET: /Guest/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChaletId = new SelectList(db.Chalets, "ChaletId", "ChaletName", guest.ChaletId);
            return View(guest);
        }

        //
        // POST: /Guest/Edit/5

        [HttpPost]
        public ActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChaletId = new SelectList(db.Chalets, "ChaletId", "ChaletName", guest.ChaletId);
            return View(guest);
        }

        //
        // GET: /Guest/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        //
        // POST: /Guest/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}