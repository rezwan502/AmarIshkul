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
    public class SubjectChapterQuestionSetupsController : Controller
    {
        private AmarIshkulDBContext db = new AmarIshkulDBContext();

        // GET: SubjectChapterQuestionSetups
        public ActionResult Index()
        {
            var subjectChapterQuestionSetups = db.SubjectChapterQuestionSetups.Include(s => s.SubjectChapterWiseDetails);
            return View(subjectChapterQuestionSetups.ToList());
        }

        // GET: SubjectChapterQuestionSetups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterQuestionSetup subjectChapterQuestionSetup = db.SubjectChapterQuestionSetups.Find(id);
            if (subjectChapterQuestionSetup == null)
            {
                return HttpNotFound();
            }
            return View(subjectChapterQuestionSetup);
        }

        // GET: SubjectChapterQuestionSetups/Create
        public ActionResult Create()
        {
            ViewBag.SubjectChapterWiseDetailsId = new SelectList(db.SubjectChapterWiseDetails, "Id", "Title");
            return View();
        }

        // POST: SubjectChapterQuestionSetups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubjectChapterWiseDetailsId,NumberOfQuestion,PerQuestionMark,TotalMarks,HighestMarks")] SubjectChapterQuestionSetup subjectChapterQuestionSetup)
        {
            if (ModelState.IsValid)
            {
                db.SubjectChapterQuestionSetups.Add(subjectChapterQuestionSetup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectChapterWiseDetailsId = new SelectList(db.SubjectChapterWiseDetails, "Id", "Title", subjectChapterQuestionSetup.SubjectChapterWiseDetailsId);
            return View(subjectChapterQuestionSetup);
        }

        // GET: SubjectChapterQuestionSetups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterQuestionSetup subjectChapterQuestionSetup = db.SubjectChapterQuestionSetups.Find(id);
            if (subjectChapterQuestionSetup == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectChapterWiseDetailsId = new SelectList(db.SubjectChapterWiseDetails, "Id", "Title", subjectChapterQuestionSetup.SubjectChapterWiseDetailsId);
            return View(subjectChapterQuestionSetup);
        }

        // POST: SubjectChapterQuestionSetups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubjectChapterWiseDetailsId,NumberOfQuestion,PerQuestionMark,TotalMarks,HighestMarks")] SubjectChapterQuestionSetup subjectChapterQuestionSetup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectChapterQuestionSetup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectChapterWiseDetailsId = new SelectList(db.SubjectChapterWiseDetails, "Id", "Title", subjectChapterQuestionSetup.SubjectChapterWiseDetailsId);
            return View(subjectChapterQuestionSetup);
        }

        // GET: SubjectChapterQuestionSetups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterQuestionSetup subjectChapterQuestionSetup = db.SubjectChapterQuestionSetups.Find(id);
            if (subjectChapterQuestionSetup == null)
            {
                return HttpNotFound();
            }
            return View(subjectChapterQuestionSetup);
        }

        // POST: SubjectChapterQuestionSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectChapterQuestionSetup subjectChapterQuestionSetup = db.SubjectChapterQuestionSetups.Find(id);
            db.SubjectChapterQuestionSetups.Remove(subjectChapterQuestionSetup);
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
