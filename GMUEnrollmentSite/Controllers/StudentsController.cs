using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMUEnrollmentSite.Models;

namespace GMUEnrollmentSite.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private StudentDatabaseEntities db = new StudentDatabaseEntities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
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

        // GET: Students/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,MiddleName,LastName,SSN,EmailAddress,HomePhone,CellPhone,AddressStreet,AddressCity,AddressState,AddressZip,DOB,Gender,HighSchoolName,HighSchoolCity,GraduationDate,CurrentGPA,SATMath,SATVerbal,AreaOfInterest,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                Student matchingStudent = db.Students.Where(cm => string.Compare(cm.SSN, student.SSN, true) == 0).FirstOrDefault();

                if(student == null)
                {
                    return HttpNotFound();
                }

                
                if (matchingStudent != null)
                {
                    ModelState.AddModelError("StudentSSN", "Social Security Number must be unique.");
                    return View(student);
                }
                    
                try
                {
                    int num = Int32.Parse(student.SSN);
                    if ((student.SSN).Length != 9)
                    {
                        ModelState.AddModelError("SSNInvalid", "Social Security Number must be a 9 digit number.");
                        return View(student);
                    }
                } catch
                {
                    ModelState.AddModelError("SSNInvalid", "Social Security Number must be a 9 digit number.");
                    return View(student);
                }


                try
                {
                    long num1 = Int64.Parse(student.HomePhone);
                    long num2 = Int64.Parse(student.CellPhone);
                    if (student.HomePhone.Length != 10 || student.CellPhone.Length != 10)
                    {
                        ModelState.AddModelError("PhoneInvalid", "Phone Numbers must be 10 digit numbers.");
                        return View(student);
                    }

                }
                catch
                {
                    ModelState.AddModelError("PhoneInvalid", "Phone Numbers must be 10 digit numbers.");
                    return View(student);
                }

                
                    try
                {
                    if (Int16.Parse(student.SATMath) > 800 
                    || Int16.Parse(student.SATMath) < 100
                    || Int16.Parse(student.SATVerbal) > 800
                    || Int16.Parse(student.SATVerbal) < 100)
                    {
                        ModelState.AddModelError("SATerror", "SAT scores must be numberse between 100 and 800.");
                        return View(student);
                    }

                    int totalSAT = Int16.Parse(student.SATMath) + Int16.Parse(student.SATVerbal);
                    if (totalSAT <= 1000)
                    {
                        ModelState.AddModelError("LowSAT", "Sorry, your combined SAT scores were not high enough.");
                        return View(student);
                    }
                    
                }
                catch
                {
                    ModelState.AddModelError("SATerror", "SAT scores must be numbers between 100 and 800");
                    return View(student);
                }


                decimal gpa = student.CurrentGPA ?? 0;
                decimal badgpa = 3;

                if (gpa < badgpa)
                {
                    ModelState.AddModelError("BadGPAError", "Sorry, your GPA is too low.");
                    return View(student);
                }

                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("About", "Home");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,MiddleName,LastName,SSN,EmailAddress,HomePhone,CellPhone,AddressStreet,AddressCity,AddressState,AddressZip,DOB,Gender,HighSchoolName,HighSchoolCity,GraduationDate,CurrentGPA,SATMath,SATVerbal,AreaOfInterest,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
