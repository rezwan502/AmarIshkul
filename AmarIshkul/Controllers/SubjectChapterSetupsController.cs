using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmarIshkul.Entity;
using AmarIshkul.Models;

namespace AmarIshkul.Controllers
{
    public class SubjectChapterSetupsController : Controller
    {
        private AmarIshkulDBContext db = new AmarIshkulDBContext();

        // GET: SubjectChapterSetups
        public ActionResult Index()
        {
            var subjectChapterSetups = db.SubjectChapterSetups.Include(s => s.Subject);
            return View(subjectChapterSetups.ToList());
        }

        // GET: SubjectChapterSetups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterSetup subjectChapterSetup = db.SubjectChapterSetups.Find(id);
            if (subjectChapterSetup == null)
            {
                return HttpNotFound();
            }
            return View(subjectChapterSetup);
        }

        // GET: SubjectChapterSetups/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes.ToList().OrderByDescending(s=> s.Id), "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: SubjectChapterSetups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubjectId,Name,IsActive,ClassId")] SubjectChapterSetup subjectChapterSetup)
        {
            ViewBag.ClassId = new SelectList(db.Classes.ToList().OrderByDescending(s => s.Id), "Id","Name",subjectChapterSetup.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", subjectChapterSetup.SubjectId);

            if (ModelState.IsValid)
            {
                db.SubjectChapterSetups.Add(subjectChapterSetup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(subjectChapterSetup);
        }

        // GET: SubjectChapterSetups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterSetup subjectChapterSetup = db.SubjectChapterSetups.Find(id);
            if (subjectChapterSetup == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes.ToList().OrderByDescending(s => s.Id), "Id", "Name", subjectChapterSetup.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", subjectChapterSetup.SubjectId);
            return View(subjectChapterSetup);
        }

        // POST: SubjectChapterSetups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,SubjectId,Name,IsActive")] SubjectChapterSetup subjectChapterSetup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectChapterSetup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes.ToList().OrderByDescending(s => s.Id), "Id", "Name", subjectChapterSetup.ClassId); ;
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", subjectChapterSetup.SubjectId);
            return View(subjectChapterSetup);
        }

        // GET: SubjectChapterSetups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterSetup subjectChapterSetup = db.SubjectChapterSetups.Find(id);
            if (subjectChapterSetup == null)
            {
                return HttpNotFound();
            }
            return View(subjectChapterSetup);
        }

        // POST: SubjectChapterSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectChapterSetup subjectChapterSetup = db.SubjectChapterSetups.Find(id);
            db.SubjectChapterSetups.Remove(subjectChapterSetup);
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
