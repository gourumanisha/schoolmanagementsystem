using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolmanagementsystem.Models;

namespace schoolmanagementsystem.Controllers
{
    public class StudentController : Controller
    {
        StudentdataEntities db = new StudentdataEntities();

        // GET: Student
        public ActionResult Index()
        {
            List<StudentModel> studentlist = new List<StudentModel>();
            List<Student> std = db.Students.ToList();

            foreach (var item in std)
            {
                StudentModel s = new StudentModel();
                s.StudentID = item.StudentId;
                s.FirstName = item.FirstName;
                s.LastName = item.LastName;
                s.DateOfBirth = (DateTime)item.DateOfBirth;
                s.Gender = item.Gender;
                s.ClassID = (int)item.ClassId;
                s.SubjectID = (int)item.SubjectId;
                studentlist.Add(s);
            }
            return View(studentlist);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student std = db.Students.Find(id);
            StudentModel s = new StudentModel();
            s.StudentID = std.StudentId;
            s.FirstName = std.FirstName;
            s.LastName = std.LastName;
            s.DateOfBirth = (DateTime)std.DateOfBirth;
            s.Gender = std.Gender;
            s.ClassID = (int)std.ClassId;
            s.SubjectID = (int)std.SubjectId;
            return View(s);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                StudentModel std = new StudentModel();
                //std.StudentID = Convert.ToInt32(collection["StudentID"]);
                std.FirstName = collection["FirstName"].ToString();
                std.LastName = collection["LastName"].ToString();
                std.DateOfBirth = Convert.ToDateTime(collection["DateOfBirth"]);
                std.Gender = collection["Gender"].ToString();
                std.ClassID = Convert.ToInt32(collection["ClassID"]);
                std.SubjectID = Convert.ToInt32(collection["SubjectID"]);

                Student s = new Student();
                //s.StudentID = std.StudentID;
                s.FirstName = std.FirstName;
                s.LastName = std.LastName;
                s.DateOfBirth = std.DateOfBirth;
                s.Gender = std.Gender;
                s.ClassId = (int)std.ClassID;
                s.SubjectId = std.SubjectID;
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student std = db.Students.Find(id);
            StudentModel s = new StudentModel();
            s.StudentID = std.StudentId;
            s.FirstName = std.FirstName;
            s.LastName = std.LastName;
            s.DateOfBirth = (DateTime)std.DateOfBirth;
            s.Gender = std.Gender;
            s.ClassID = (int)std.ClassId;
            s.SubjectID = (int)std.SubjectId;
            return View(s);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Student std = db.Students.Find(id);
                std.FirstName = collection["FirstName"].ToString();
                std.LastName = collection["LastName"].ToString();
                std.DateOfBirth = Convert.ToDateTime(collection["DateOfBirth"]);
                std.Gender = collection["Gender"].ToString();
                std.ClassId = Convert.ToInt32(collection["ClassID"]);
                std.SubjectId = Convert.ToInt32(collection["SubjectID"]);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student std = db.Students.Find(id);
            StudentModel s = new StudentModel();
            s.StudentID = std.StudentId;
            s.FirstName = std.FirstName;
            s.LastName = std.LastName;
            s.DateOfBirth = (DateTime)std.DateOfBirth;
            s.Gender = std.Gender;
            s.ClassID = (int)std.ClassId;
            s.SubjectID = (int)std.SubjectId;
            return View(s);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Student std = db.Students.Find(id);
                db.Students.Remove(std);
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