using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AstronomerNotebook.DAL;
using AstronomerNotebook.Models;

namespace AstronomerNotebook.Controllers
{
    public class GalaxiesController : Controller
    {
        private UniverseContext db = new UniverseContext();

        // GET: Galaxies
        public ActionResult Index()
        {
            return View(db.Galaxies.ToList());
        }

        // GET: Galaxies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galaxy galaxy = db.Galaxies.Find(id);
            if (galaxy == null)
            {
                return HttpNotFound();
            }
            return View(galaxy);
        }

        // GET: Galaxies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Galaxies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Constellation,GalaxyType,ApparentMagnitude,RightAscension,Declination")] Galaxy galaxy)
        {
            if (ModelState.IsValid)
            {
                db.Galaxies.Add(galaxy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galaxy);
        }

        // GET: Galaxies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galaxy galaxy = db.Galaxies.Find(id);
            if (galaxy == null)
            {
                return HttpNotFound();
            }
            return View(galaxy);
        }

        // POST: Galaxies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Constellation,GalaxyType,ApparentMagnitude,RightAscension,Declination")] Galaxy galaxy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galaxy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galaxy);
        }

        // GET: Galaxies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galaxy galaxy = db.Galaxies.Find(id);
            if (galaxy == null)
            {
                return HttpNotFound();
            }
            return View(galaxy);
        }

        // POST: Galaxies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Galaxy galaxy = db.Galaxies.Find(id);
            db.Galaxies.Remove(galaxy);
            db.SaveChanges();
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
