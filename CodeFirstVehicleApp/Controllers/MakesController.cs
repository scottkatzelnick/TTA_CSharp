using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstVehicleApp.Data;
using CodeFirstVehicleApp.Models.Vehicles;

namespace CodeFirstVehicleApp.Controllers
{
    public class MakesController : Controller
    {
        private VehiclesContext db = new VehiclesContext();

        // GET: Makes
        public ActionResult Index()
        {
            return View(db.Makes.ToList());
        }

        // GET: Makes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Make make = db.Makes.Find(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        // GET: Makes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Makes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Brand,Address,Circa,CEO")] Make make)
        {
            if (ModelState.IsValid)
            {
                db.Makes.Add(make);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(make);
        }

        // GET: Makes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Make make = db.Makes.Find(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        // POST: Makes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Brand,Address,Circa,CEO")] Make make)
        {
            if (ModelState.IsValid)
            {
                db.Entry(make).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(make);
        }

        // GET: Makes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Make make = db.Makes.Find(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        // POST: Makes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Make make = db.Makes.Find(id);
            db.Makes.Remove(make);
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
