using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalShelterApp.Models;

namespace AnimalShelterApp.Controllers
{
    public class Pet4Controller : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: Pet4
        public ActionResult Index()
        {
            return View(db.Pet4.ToList());
        }

        // GET: Pet4/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet4 pet4 = db.Pet4.Find(id);
            if (pet4 == null)
            {
                return HttpNotFound();
            }
            return View(pet4);
        }

        // GET: Pet4/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet4/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetID,Type,Breed,Age,Gender,PetName,Photo")] Pet4 pet4)
        {
            if (ModelState.IsValid)
            {
                db.Pet4.Add(pet4);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pet4);
        }

        // GET: Pet4/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet4 pet4 = db.Pet4.Find(id);
            if (pet4 == null)
            {
                return HttpNotFound();
            }
            return View(pet4);
        }

        // POST: Pet4/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetID,Type,Breed,Age,Gender,PetName,Photo")] Pet4 pet4)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet4).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet4);
        }

        // GET: Pet4/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet4 pet4 = db.Pet4.Find(id);
            if (pet4 == null)
            {
                return HttpNotFound();
            }
            return View(pet4);
        }

        // POST: Pet4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet4 pet4 = db.Pet4.Find(id);
            db.Pet4.Remove(pet4);
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
