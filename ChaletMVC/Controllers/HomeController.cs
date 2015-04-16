using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChaletMVC.Models;

namespace ChaletMVC.Controllers
{
    public class HomeController : Controller
    {
        private ChaletDb db = new ChaletDb();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            //return View(db.Chalets.Include("Guests"));
            return View(db.Chalets.Include(g => g.Guests));
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Chalet chalet = db.Chalets.Find(id);
            if (chalet == null)
            {
                return HttpNotFound();
            }
            return View(chalet);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Chalet chalet)
        {
            if (ModelState.IsValid)
            {
                db.Chalets.Add(chalet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chalet);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Chalet chalet = db.Chalets.Find(id);
            if (chalet == null)
            {
                return HttpNotFound();
            }
            return View(chalet);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Chalet chalet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chalet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chalet);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Chalet chalet = db.Chalets.Find(id);
            if (chalet == null)
            {
                return HttpNotFound();
            }
            return View(chalet);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Chalet chalet = db.Chalets.Find(id);
            db.Chalets.Remove(chalet);
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