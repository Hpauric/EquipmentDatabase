using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EquipmentDatabase.DAL;
using EquipmentDatabase.Models;
using System.Data.Entity.Infrastructure;

//test

namespace EquipmentDatabase.Controllers
{
    public class StudentController : Controller
    {
        private ProjectContext db = new ProjectContext();

        public ActionResult AjaxStudentTable()
        {
            return PartialView(db.Students.ToList());
        }


        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,LastName,FirstMidName")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(student);
        }

        // GET: Student/Delete/5

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);

        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Student student = db.Students
           .Include(i => i.Equipment)
           .Where(i => i.StudentID == id)
            .Single();

                if (student == null)
                {
                    return HttpNotFound();
                }

                db.Students.Remove(student);

                var equipment = db.Equipments
                    .Where(d => d.StudentID == id)
                    .SingleOrDefault();
                if (equipment != null)
                {
                    equipment.StudentID = null;
                }

                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        //// GET: Student/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        // GET: Student/Edit/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "StudentID,LastName,FirstMidName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return View("Index");
            }
            return View(student);
        }

        // GET: Student
        public ActionResult Index()
        {
            return View("AjaxIndex");
        }

        // GET
        public ActionResult Unassign(int equipmentID, int studentID)
        {
            try
            {
                Student student = db.Students
           .Include(i => i.Equipment)
           .Where(i => i.StudentID == studentID)
            .Single();

                if (student == null)
                {
                    return HttpNotFound();
                }

                var equipment = db.Equipments
                    .Where(d => d.StudentID == studentID && d.EquipmentID == equipmentID)
                    .SingleOrDefault();
                if (equipment != null)
                {
                    equipment.StudentID = null;
                    equipment.DateAssigned = null;
                    student.Equipment.Remove(equipment);

                }

                db.SaveChanges();

                return View("Details", student);
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = studentID, saveChangesError = true });
            }
            
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
