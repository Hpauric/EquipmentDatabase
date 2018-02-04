using EquipmentDatabase.DAL;
using EquipmentDatabase.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Linq;
using System;

namespace EquipmentDatabase.Controllers
{
    public class EquipmentController : Controller
    {
        private ProjectContext db = new ProjectContext();

        public ActionResult AjaxEquipmentTable()
        {
            var equipments = db.Equipments.Include(e => e.Student);
            return PartialView(equipments);
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
                    for (var i = 0; i < NumberOfUnits; i++)
                    {
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
        public ActionResult Create([Bind(Include = "DatePurchased,DateAssigned,EquipmentType,StudentID,ModelName,Location,Status,ServiceTag,Software,Notes")] Equipment equipment)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Equipments.Add(equipment);
                    db.SaveChanges();

                    if (equipment.StudentID != null)
                    {
                        var transaction = new Transaction
                        {
                            StudentID = equipment.StudentID,
                            EquipmentID = equipment.EquipmentID,
                            TransactionDate = DateTime.Today,
                            TransactionType = TransactionType.Assigned
                        };
                        db.Transactions.Add(transaction);
                        db.SaveChanges();
                    }



                    return RedirectToAction("Index");
                }
                else
                {
                    return View(equipment);
                }

            }
            catch (DataException dex)
            {

                System.Diagnostics.Debug.WriteLine(dex.ToString());
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                ModelState.AddModelError("", dex.ToString() + dex.Message + dex.Source + dex.TargetSite + dex.HelpLink + dex.InnerException);

                return View(equipment);
            }

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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
        public ActionResult Edit([Bind(Include = "EquipmentID,DatePurchased,DateAssigned,EquipmentType,StudentID,ModelName,Location,Status,ServiceTag,Software,Notes")] Equipment equipment)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(equipment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException dex)
                {

                    ModelState.AddModelError("", dex.ToString() + '\n' +
                        dex.Message + '\n' + dex.Source + '\n' +
                        dex.TargetSite + '\n' + dex.HelpLink + '\n' +
                        dex.InnerException);
                }
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", equipment.StudentID);
            return View(equipment);
        }


        // GET: Equipment
        public ActionResult Index()
        {
            try
            {
                return View("AjaxIndex");

            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                System.Diagnostics.Trace.TraceError("If you're seeing this, something bad happened");
                System.Diagnostics.Trace.TraceError(dex.Message);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View("Error");
                // return dex.Message;
            }
        }

        public ActionResult Save(int ID, int StudentID)
        {

            Equipment equipment = db.Equipments.Find(ID);
            try
            {
                equipment.StudentID = StudentID;
                equipment.DateAssigned = DateTime.Today;
                equipment.Location = "With Student";
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Student", new { id = StudentID });
            }
            catch (DataException dex)
            {

                ModelState.AddModelError("", dex.ToString() + '\n' +
                    dex.Message + '\n' + dex.Source + '\n' +
                    dex.TargetSite + '\n' + dex.HelpLink + '\n' +
                    dex.InnerException);
            }

            return View("Error");
        }


        // GET: Select
        public ActionResult Select(int? StudentID)
        {
            ViewBag.StudentID = StudentID;

            try
            {

                var query = from e in db.Equipments
                            where e.StudentID == null
                            select e;



                //var equipments = db.Equipments.Include(e => e.StudentID == null);
                return View(query);

            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                System.Diagnostics.Trace.TraceError("If you're seeing this, something bad happened");
                System.Diagnostics.Trace.TraceError(dex.Message);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return View("Error");
                // return dex.Message;
            }
        }




    }
}
