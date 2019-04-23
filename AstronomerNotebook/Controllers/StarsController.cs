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
using PagedList;
using System.Data.Entity.Infrastructure;

namespace AstronomerNotebook.Controllers
{
    [Authorize]
    public class StarsController : Controller
    {
        private UniverseContext db = new UniverseContext();

        [AllowAnonymous]
        // GET: Stars
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.currentFilter = searchString;

            var stars = from s in db.Stars select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                stars = stars.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    stars = stars.OrderByDescending(s => s.Name);
                    break;
                default:
                    stars = stars.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(stars.ToPagedList(pageNumber, pageSize));
        }

        [AllowAnonymous]
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
            ViewBag.ClusterId = new SelectList(db.Clusters, "Id", "Name");
            return View();
        }

        // POST: Stars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Constellation,ApparentMagnitude,RightAscension,Declination,AstronomerId,ClusterId")] Star star)
        {
            if (ModelState.IsValid)
            {
                db.Stars.Add(star);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AstronomerId = new SelectList(db.Astronomers, "Id", "Name", star.AstronomerId);
            ViewBag.ClusterId = new SelectList(db.Clusters, "Id", "Name", star.ClusterId);
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
            ViewBag.ClusterId = new SelectList(db.Clusters, "Id", "Name", star.ClusterId);
            return View(star);
        }

        // POST: Stars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Constellation,ApparentMagnitude,RightAscension,Declination,AstronomerId,ClusterId")] Star star)
        {
            if (ModelState.IsValid)
            {
                db.Entry(star).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AstronomerId = new SelectList(db.Astronomers, "Id", "Name", star.AstronomerId);
            ViewBag.ClusterId = new SelectList(db.Clusters, "Id", "Name", star.ClusterId);
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
