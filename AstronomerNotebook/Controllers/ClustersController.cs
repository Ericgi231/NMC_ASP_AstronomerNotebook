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
    public class ClustersController : Controller
    {
        private UniverseContext db = new UniverseContext();

        // GET: Clusters
        public ActionResult Index()
        {
            return View(db.Clusters.ToList());
        }

        // GET: Clusters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cluster cluster = db.Clusters.Find(id);
            if (cluster == null)
            {
                return HttpNotFound();
            }
            return View(cluster);
        }

        // GET: Clusters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clusters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Constellation,ClusterType,ApparentMagnitude,RightAscension,Declination")] Cluster cluster)
        {
            if (ModelState.IsValid)
            {
                db.Clusters.Add(cluster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cluster);
        }

        // GET: Clusters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cluster cluster = db.Clusters.Find(id);
            if (cluster == null)
            {
                return HttpNotFound();
            }
            return View(cluster);
        }

        // POST: Clusters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Constellation,ClusterType,ApparentMagnitude,RightAscension,Declination")] Cluster cluster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cluster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cluster);
        }

        // GET: Clusters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cluster cluster = db.Clusters.Find(id);
            if (cluster == null)
            {
                return HttpNotFound();
            }
            return View(cluster);
        }

        // POST: Clusters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cluster cluster = db.Clusters.Find(id);
            db.Clusters.Remove(cluster);
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
