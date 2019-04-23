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
using AstronomerNotebook.ViewModels;
using System.Data.Entity.Infrastructure;

namespace AstronomerNotebook.Controllers
{
    [Authorize]
    public class AstronomersController : Controller
    {
        private UniverseContext db = new UniverseContext();

        [AllowAnonymous]
        // GET: Astronomers
        public ActionResult Index(int? id, int? ClusterId)
        {
            var viewModel = new AstronomerIndexData();
            viewModel.Astronomers = db.Astronomers
                .Include(i => i.Galaxies)
                .Include(i => i.Clusters)
                .Include(i => i.Stars);

            if (id != null)
            {
                ViewBag.AstronomerID = id.Value;
                viewModel.Clusters = viewModel.Astronomers.Where(
                    i => i.Id == id.Value).Single().Clusters;
            }

            if (ClusterId != null)
            {
                ViewBag.ClusterID = ClusterId.Value;
                viewModel.Stars = viewModel.Clusters.Where(
                    x => x.Id == ClusterId).Single().Stars;
            }

            return View(viewModel);
        }

        [AllowAnonymous]
        // GET: Astronomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Astronomer astronomer = db.Astronomers.Find(id);
            if (astronomer == null)
            {
                return HttpNotFound();
            }
            return View(astronomer);
        }

        // GET: Astronomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Astronomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Astronomer astronomer)
        {
            if (ModelState.IsValid)
            {
                db.Astronomers.Add(astronomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(astronomer);
        }

        // GET: Astronomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Astronomer astronomer = db.Astronomers.Find(id);
            if (astronomer == null)
            {
                return HttpNotFound();
            }
            return View(astronomer);
        }

        // POST: Astronomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Astronomer astronomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(astronomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(astronomer);
        }

        // GET: Astronomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Astronomer astronomer = db.Astronomers.Find(id);
            if (astronomer == null)
            {
                return HttpNotFound();
            }
            return View(astronomer);
        }

        // POST: Astronomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Astronomer astronomer = db.Astronomers.Find(id);
            db.Astronomers.Remove(astronomer);
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
