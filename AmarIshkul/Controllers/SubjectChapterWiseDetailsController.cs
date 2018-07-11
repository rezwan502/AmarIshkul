using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmarIshkul.Entity;
using AmarIshkul.Models;
using AmarIshkul.ViewModel;

namespace AmarIshkul.Controllers
{
    public class SubjectChapterWiseDetailsController : Controller
    {
        private AmarIshkulDBContext db = new AmarIshkulDBContext();

        // GET: SubjectChapterWiseDetails
        public ActionResult Index()
        {
           ViewBag.subjectChapterWiseDetails = db.SubjectChapterWiseDetails.Include(s => s.SubjectchapterSetup);
            ViewBag.Classes = db.Classes.ToList();
            return View();
        }


        [HttpGet]
        public JsonResult GetSubjects(int Id)
        {
            var state = from s in db.Subjects
                        where s.ClassId == Id
                        select s;
            return Json(new SelectList(state.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubjects1(int Id, int groupId)
        {
            var state = from s in db.Subjects
                        where s.ClassId == Id &&
                        s.GroupId==groupId
                        select s;
            return Json(new SelectList(state.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubjectChapter(int Id)
        {
            var state = from s in db.SubjectChapterSetups
                        where s.SubjectId == Id
                        select s;
            return Json(new SelectList(state.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }



        /*
                // GET: SubjectChapterWiseDetails/Details/5
                public ActionResult Details(int? id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    SubjectChapterWiseDetails subjectChapterWiseDetails = db.SubjectChapterWiseDetails.Find(id);
                    if (subjectChapterWiseDetails == null)
                    {
                        return HttpNotFound();
                    }
                    return View(subjectChapterWiseDetails);
                }
        */



        // GET: SubjectChapterWiseDetails/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects.ToList(), "Id", "Name");
            ViewBag.GroupId = new SelectList(db.Groups.ToList(),"Id","Name");
            ViewBag.SubjectChapterSetupId = new SelectList(db.SubjectChapterSetups.ToList().OrderByDescending(s => s.Id), "Id", "Name");
            ViewBag.Message = null;
            return View();
        }

        // POST: SubjectChapterWiseDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create( SubjectChapterWiseDetailsViewModel Viewmodel)
        {
            ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name",Viewmodel.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects.ToList(), "Id", "Name",Viewmodel.SubjectId);
            ViewBag.GroupId = new SelectList(db.Groups.ToList(), "Id", "Name",Viewmodel.GroupId);
            ViewBag.SubjectChapterSetupId = new SelectList(db.SubjectChapterSetups.ToList().OrderByDescending(s => s.Id), "Id", "Name",Viewmodel.SubjectChapterSetupId);

            if (ModelState.IsValid)
            {
                SubjectChapterWiseDetails model = new SubjectChapterWiseDetails();
                model.Title = Viewmodel.Title;
                model.UrlLink = Viewmodel.UrlLink;
                model.Content = Viewmodel.Content;
                model.PublishDate = Viewmodel.PublishDate;
                model.SubjectchapterSetupId = Viewmodel.SubjectChapterSetupId;

                db.SubjectChapterWiseDetails.Add(model);
                db.SaveChanges();
                ViewBag.message = "Save Successful";
             
            
            }
            ViewBag.message = "Error!";
            return View(Viewmodel);
        }

        // GET: SubjectChapterWiseDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterWiseDetails subjectChapterWiseDetails = db.SubjectChapterWiseDetails.Find(id);
            if (subjectChapterWiseDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = null; 

            SubjectChapterWiseDetailsViewModel model = new SubjectChapterWiseDetailsViewModel();
            model.Title = subjectChapterWiseDetails.Title;
            model.UrlLink = subjectChapterWiseDetails.UrlLink;
            model.Content = subjectChapterWiseDetails.Content;
            model.PublishDate = subjectChapterWiseDetails.PublishDate;
            model.Id = subjectChapterWiseDetails.Id;

            ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name", subjectChapterWiseDetails.SubjectchapterSetup.Subject.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects.ToList(), "Id", "Name", subjectChapterWiseDetails.SubjectchapterSetup.SubjectId);
            ViewBag.GroupId = new SelectList(db.Groups.ToList(), "Id", "Name", subjectChapterWiseDetails.SubjectchapterSetup.Subject.GroupId);
            ViewBag.SubjectChapterSetupId = new SelectList(db.SubjectChapterSetups.ToList().OrderByDescending(s => s.Id), "Id", "Name", subjectChapterWiseDetails.SubjectchapterSetupId);

            return View(model);
        }

        // POST: SubjectChapterWiseDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SubjectChapterWiseDetailsViewModel Viewmodel)
        {
            ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name", Viewmodel.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects.ToList(), "Id", "Name", Viewmodel.SubjectId);
            ViewBag.GroupId = new SelectList(db.Groups.ToList(), "Id", "Name", Viewmodel.GroupId);
            ViewBag.SubjectChapterSetupId = new SelectList(db.SubjectChapterSetups.ToList().OrderByDescending(s => s.Id), "Id", "Name", Viewmodel.SubjectChapterSetupId);

            if (ModelState.IsValid)
            {
                SubjectChapterWiseDetails model = db.SubjectChapterWiseDetails.Find(Viewmodel.Id);
                model.Title = Viewmodel.Title;
                model.UrlLink = Viewmodel.UrlLink;
                model.Content = Viewmodel.Content;
                model.PublishDate = Viewmodel.PublishDate;
                model.SubjectchapterSetupId = Viewmodel.SubjectChapterSetupId;

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.message = "Save Successful";
                return RedirectToAction("Index");
            }

            ViewBag.message = "Error!";

            return View(Viewmodel);
        }

        // GET: SubjectChapterWiseDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectChapterWiseDetails subjectChapterWiseDetails = db.SubjectChapterWiseDetails.Find(id);
            if (subjectChapterWiseDetails == null)
            {
                return HttpNotFound();
            }
            return View(subjectChapterWiseDetails);
        }

        // POST: SubjectChapterWiseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectChapterWiseDetails subjectChapterWiseDetails = db.SubjectChapterWiseDetails.Find(id);
            db.SubjectChapterWiseDetails.Remove(subjectChapterWiseDetails);
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
