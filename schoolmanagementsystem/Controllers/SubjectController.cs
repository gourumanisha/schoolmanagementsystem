using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolmanagementsystem.Models;

namespace schoolmanagementsystem.Controllers
{
    public class SubjectController : Controller
    {
        StudentdataEntities db = new StudentdataEntities();
        // GET: Subject
        public ActionResult Index()
        {
            List<SubjectModel> classlist = new List<SubjectModel>();
            List<Subject> c = db.Subjects.ToList();

            foreach (var item in c)
            {
                SubjectModel s = new SubjectModel();
                s.SubjectId = item.SubjectId;
                s.SubjectName = item.SubjectName;
                classlist.Add(s);
            }
            return View(classlist);
        }

        // GET: Subject/Details/5
        public ActionResult Details(int id)
        {
            Subject c = db.Subjects.Find(id);
            SubjectModel s = new SubjectModel();
            s.SubjectId = c.SubjectId;
            s.SubjectName = c.SubjectName;
            return View(s);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SubjectModel c = new SubjectModel();
                c.SubjectName = collection["SubjectName"].ToString();

                Subject s = new Subject();
                s.SubjectName = c.SubjectName;
                db.Subjects.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int id)
        {
            Subject c = db.Subjects.Find(id);
            SubjectModel s = new SubjectModel();
            s.SubjectId = c.SubjectId;
            s.SubjectName = c.SubjectName;
            return View(s);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Subject c = db.Subjects.Find(id);
                c.SubjectName = collection["SubjectName"].ToString();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int id)
        {
            Subject c = db.Subjects.Find(id);
            SubjectModel s = new SubjectModel();
            s.SubjectId = c.SubjectId;
            s.SubjectName = c.SubjectName;
            return View(s);
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Subject c = db.Subjects.Find(id);
                db.Subjects.Remove(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}