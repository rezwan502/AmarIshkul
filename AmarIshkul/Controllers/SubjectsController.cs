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
using System.IO;

namespace AmarSchool.Controllers
{
    public class SubjectsController : Controller
    {
        private AmarIshkulDBContext db = new AmarIshkulDBContext();

        // GET: Subjects
        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.Class).Include(s => s.Group);
            return View(subjects.ToList().ToList().OrderBy(s => s.ClassId));
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.Invalid = null;
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject, HttpPostedFileBase file)
        {
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", subject.ClassId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", subject.GroupId);
            if (db.Subjects.Where(s => s.Name == subject.Name && s.ClassId == subject.ClassId).Any())
            {
                ViewBag.Invalid = "Subject Already Exists";
                return View(subject);
            }

            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
            }

            var img = Path.GetFileName(subject.FileName);
            if (subject.File != null)
            {
                var extension = Path.GetExtension(Path.GetFileName(subject.File.FileName));
                var fileName = "/Content/SubjectBooks/" + subject.Id.ToString() + subject.Name.ToString() + extension;
                var filePath = Path.Combine(Server.MapPath(fileName));
                file.SaveAs(filePath);
                subject.FileName = fileName;
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.Invalid = null;
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", subject.ClassId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", subject.GroupId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject subject, HttpPostedFileBase file)
        {
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", subject.ClassId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", subject.GroupId);
            if (db.Subjects.Where(s => s.Name == subject.Name && s.ClassId == subject.ClassId && s.Id != subject.Id).Any())
            {
                ViewBag.Invalid = "Subject Already Exists";
                return View(subject);
            }

            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
            }

            var img = Path.GetFileName(subject.FileName);
            if (subject.File != null)
            {
                var extension = Path.GetExtension(Path.GetFileName(subject.File.FileName));
                var fileName = "/Content/SubjectBooks/" + subject.Id.ToString() + subject.Name.ToString() + extension;
                var filePath = Path.Combine(Server.MapPath(fileName));
                file.SaveAs(filePath);
                subject.FileName = fileName;
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(subject);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            db.Subjects.Remove(subject);
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
