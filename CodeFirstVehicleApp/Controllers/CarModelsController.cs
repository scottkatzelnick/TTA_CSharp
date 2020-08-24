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
    public class CarModelsController : Controller
    {
        private VehiclesContext db = new VehiclesContext();

        // GET: CarModels
        public ActionResult Index()
        {
            var car_Models = db.Car_Models.Include(c => c.Make);
            return View(car_Models.ToList());
        }

        // GET: CarModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.Car_Models.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {
            ViewBag.Brand = new SelectList(db.Makes, "Brand", "Brand");
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarModelId,ModelName,Year,Color,Brand")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.Car_Models.Add(carModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Brand = new SelectList(db.Makes, "Brand", "Address", carModel.Brand);
            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.Car_Models.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand = new SelectList(db.Makes, "Brand", "Address", carModel.Brand);
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarModelId,ModelName,Year,Color,Brand")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brand = new SelectList(db.Makes, "Brand", "Address", carModel.Brand);
            return View(carModel);
        }

        // GET: CarModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.Car_Models.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModel carModel = db.Car_Models.Find(id);
            db.Car_Models.Remove(carModel);
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