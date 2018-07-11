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
    public class SubjectChapterQuestionDetailsController : Controller
    {
        private AmarIshkulDBContext db = new AmarIshkulDBContext();

        // GET: SubjectChapterQuestionDetails
        public ActionResult Index()
        {
            var subjectChapterQuestionDetails = db.SubjectChapterQuestionDetails.Include(s => s.SubjectChapterQuestionSetup);
            return View(subjectChapterQuestionDetails.ToList());
        }

        // GET: SubjectChapterQuestionDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterQuestionDetails subjectChapterQuestionDetails = db.SubjectChapterQuestionDetails.Find(id);
            if (subjectChapterQuestionDetails == null)
            {
                return HttpNotFound();
            }
            return View(subjectChapterQuestionDetails);
        }

        // GET: SubjectChapterQuestionDetails/Create
        public ActionResult Create()
        {
            ViewBag.SubjectChapterQuestionSetupId = new SelectList(db.SubjectChapterQuestionSetups, "Id", "Id");
            return View();
        }

        // POST: SubjectChapterQuestionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubjectChapterQuestionSetupId,QuestionNumber,QuestionName,AnswerName1,IsAnswerName1,AnswerName2,IsAnswerName2,AnswerName3,IsAnswerName3,AnswerName4,IsAnswerName4,Answer")] SubjectChapterQuestionDetails subjectChapterQuestionDetails)
        {
            if (ModelState.IsValid)
            {
                db.SubjectChapterQuestionDetails.Add(subjectChapterQuestionDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectChapterQuestionSetupId = new SelectList(db.SubjectChapterQuestionSetups, "Id", "Id", subjectChapterQuestionDetails.SubjectChapterQuestionSetupId);
            return View(subjectChapterQuestionDetails);
        }

        // GET: SubjectChapterQuestionDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterQuestionDetails subjectChapterQuestionDetails = db.SubjectChapterQuestionDetails.Find(id);
            if (subjectChapterQuestionDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectChapterQuestionSetupId = new SelectList(db.SubjectChapterQuestionSetups, "Id", "Id", subjectChapterQuestionDetails.SubjectChapterQuestionSetupId);
            return View(subjectChapterQuestionDetails);
        }

        // POST: SubjectChapterQuestionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubjectChapterQuestionSetupId,QuestionNumber,QuestionName,AnswerName1,IsAnswerName1,AnswerName2,IsAnswerName2,AnswerName3,IsAnswerName3,AnswerName4,IsAnswerName4,Answer")] SubjectChapterQuestionDetails subjectChapterQuestionDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectChapterQuestionDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectChapterQuestionSetupId = new SelectList(db.SubjectChapterQuestionSetups, "Id", "Id", subjectChapterQuestionDetails.SubjectChapterQuestionSetupId);
            return View(subjectChapterQuestionDetails);
        }

        // GET: SubjectChapterQuestionDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterQuestionDetails subjectChapterQuestionDetails = db.SubjectChapterQuestionDetails.Find(id);
            if (subjectChapterQuestionDetails == null)
            {
                return HttpNotFound();
            }
            return View(subjectChapterQuestionDetails);
        }

        // POST: SubjectChapterQuestionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectChapterQuestionDetails subjectChapterQuestionDetails = db.SubjectChapterQuestionDetails.Find(id);
            db.SubjectChapterQuestionDetails.Remove(subjectChapterQuestionDetails);
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
