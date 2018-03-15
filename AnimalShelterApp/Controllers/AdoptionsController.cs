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
    public class AdoptionsController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: Adoptions
        public ActionResult Index()
        {
            var adoptions = db.Adoptions.Include(a => a.Family).Include(a => a.Pet4);
            return View(adoptions.ToList());
        }

        // GET: Adoptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoption adoption = db.Adoptions.Find(id);
            if (adoption == null)
            {
                return HttpNotFound();
            }
            return View(adoption);
        }

        // GET: Adoptions/Create
        public ActionResult Create()
        {
            ViewBag.FamilyID = new SelectList(db.Families, "FamilyID", "FamilyName");
            ViewBag.PetID = new SelectList(db.Pet4, "PetID", "Type");
            return View();
        }

        // POST: Adoptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdoptionID,PetID,FamilyID,DateAdopted,EmployeeName")] Adoption adoption)
        {
            if (ModelState.IsValid)
            {
                db.Adoptions.Add(adoption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyID = new SelectList(db.Families, "FamilyID", "FamilyName", adoption.FamilyID);
            ViewBag.PetID = new SelectList(db.Pet4, "PetID", "Type", adoption.PetID);
            return View(adoption);
        }

        // GET: Adoptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoption adoption = db.Adoptions.Find(id);
            if (adoption == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyID = new SelectList(db.Families, "FamilyID", "FamilyName", adoption.FamilyID);
            ViewBag.PetID = new SelectList(db.Pet4, "PetID", "Type", adoption.PetID);
            return View(adoption);
        }

        // POST: Adoptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdoptionID,PetID,FamilyID,DateAdopted,EmployeeName")] Adoption adoption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adoption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyID = new SelectList(db.Families, "FamilyID", "FamilyName", adoption.FamilyID);
            ViewBag.PetID = new SelectList(db.Pet4, "PetID", "Type", adoption.PetID);
            return View(adoption);
        }

        // GET: Adoptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoption adoption = db.Adoptions.Find(id);
            if (adoption == null)
            {
                return HttpNotFound();
            }
            return View(adoption);
        }

        // POST: Adoptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adoption adoption = db.Adoptions.Find(id);
            db.Adoptions.Remove(adoption);
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
