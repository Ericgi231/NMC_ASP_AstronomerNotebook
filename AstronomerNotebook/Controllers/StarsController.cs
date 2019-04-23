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
    public class StarsController : Controller
    {
        private UniverseContext db = new UniverseContext();

        // GET: Stars
        public ActionResult Index()
        {
            var stars = db.Stars.Include(s => s.Astronomer);
            return View(stars.ToList());
        }

        // GET: Stars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Star star = db.Stars.Find(id);
            if (star == null)
            {
                return HttpNotFound();
            }
            return View(star);
        }

        // GET: Stars/Create
        public ActionResult Create()
        {
            ViewBag.AstronomerId = new SelectList(db.Astronomers, "Id", "Name");
            return View();
        }

        // POST: Stars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Constellation,ApparentMagnitude,RightAscension,Declination,AstronomerId")] Star star)
        {
            if (ModelState.IsValid)
            {
                db.Stars.Add(star);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AstronomerId = new SelectList(db.Astronomers, "Id", "Name", star.AstronomerId);
            return View(star);
        }

        // GET: Stars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Star star = db.Stars.Find(id);
            if (star == null)
            {
                return HttpNotFound();
            }
            ViewBag.AstronomerId = new SelectList(db.Astronomers, "Id", "Name", star.AstronomerId);
            return View(star);
        }

        // POST: Stars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Constellation,ApparentMagnitude,RightAscension,Declination,AstronomerId")] Star star)
        {
            if (ModelState.IsValid)
            {
                db.Entry(star).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AstronomerId = new SelectList(db.Astronomers, "Id", "Name", star.AstronomerId);
            return View(star);
        }

        // GET: Stars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Star star = db.Stars.Find(id);
            if (star == null)
            {
                return HttpNotFound();
            }
            return View(star);
        }

        // POST: Stars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Star star = db.Stars.Find(id);
            db.Stars.Remove(star);
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
