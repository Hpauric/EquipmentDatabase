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

namespace EquipmentDatabase.Controllers
{
    public class EquipmentController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Equipment
        public ActionResult Index()
        {
            try
            {
                var equipments = db.Equipments.Include(e => e.Student);
                return View(equipments);

            }
            catch (DataException  dex )
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                System.Diagnostics.Trace.TraceError("If you're seeing this, something bad happened");
                System.Diagnostics.Trace.TraceError(dex.Message);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View("Error");
               // return dex.Message;
            }
        }

        // GET: Equipment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: Equipment/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID");
            return View();
        }

        // POST: Equipment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipmentID,DateAssigned,EquipmentName,StudentID")] Equipment equipment)
        {

            try
            {
                if (ModelState.IsValid)
            {
                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                else {
                        ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", equipment.StudentID);
                        return View(equipment);
                    }
            
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View(equipment);
            }

            
        }

        // GET: Equipment/BulkCreate
        public ActionResult BulkCreate()
        {
            return View();
        }

        // POST: Equipment/BulkCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkCreate(Equipment equipment, int NumberOfUnits)
        {


            System.Diagnostics.Debug.WriteLine("Number of Units: " + NumberOfUnits);

            System.Diagnostics.Debug.WriteLine(equipment);
            try
            {
                if (ModelState.IsValid)
                {
                    for(var i = 0; i < NumberOfUnits; i++)
                    {
                        equipment.EquipmentID = 12 + i;
                        db.Equipments.Add(equipment);
                        db.SaveChanges();
                    }
                    
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View();
        }





        // GET: Equipment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", equipment.StudentID);
            return View(equipment);
        }

        // POST: Equipment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipmentID,DateAssigned,EquipmentName,StudentID")] Equipment equipment)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(equipment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", equipment.StudentID);
            return View(equipment);
        }

        // GET: Equipment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = db.Equipments.Find(id);
            db.Equipments.Remove(equipment);
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
