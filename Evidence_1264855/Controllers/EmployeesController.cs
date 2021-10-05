using Evidence_1264855.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence_1264855.Controllers
{
    public class EmployeesController : Controller
    {
        //Db Inject Dependency/ db Context
        readonly CompanyDbContext db = null;
        //for IFormFile this service will use
        readonly IWebHostEnvironment env;
        public EmployeesController(CompanyDbContext db, IWebHostEnvironment env) { this.db = db; this.env = env; }

        //Index Action
        public IActionResult Index()
        {
            return View(db.Employees.Include(b => b.Branches).ToList());
        }
        //Create Action
        public IActionResult Create()
        {
            ViewBag.Branches = db.Branches.ToList();
            return View();
        }
        //Create Post Action
        [HttpPost]
        public IActionResult Create(EmployeeCreateModel emp)
        {
            if (ModelState.IsValid)
            {
                var empNew = new Employee
                {
                    EmployeePicture = "no-pic.png",
                    EmployeeName = emp.EmployeeName,
                    EmployeePhone = emp.EmployeePhone,
                    EmployeeSalary = emp.EmployeeSalary,
                    EmployeeDepartment = emp.EmployeeDepartment,
                    EmployeeJoinDate = emp.EmployeeJoinDate,
                    EmployeeGender = emp.EmployeeGender,
                    Continued = emp.Continued,
                    BranchId = emp.BranchId
                };
                if (emp.EmployeePicture != null && emp.EmployeePicture.Length > 0)
                {
                    string dir = Path.Combine(env.WebRootPath, "Uploads");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string fileName = Guid.NewGuid() + Path.GetExtension(emp.EmployeePicture.FileName);
                    string fullPath = Path.Combine(dir, fileName);
                    FileStream fs = new FileStream(fullPath, FileMode.Create);
                    emp.EmployeePicture.CopyTo(fs);
                    fs.Flush();
                    empNew.EmployeePicture = fileName;
                }
                db.Employees.Add(empNew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branches = db.Branches.ToList();
            return View(emp);
        }
        //Update Action
        public IActionResult Update(int Id)
        {
            ViewBag.Branches = db.Branches.ToList();
            var emp = db.Employees.Include(b => b.Branches).First(e => e.EmployeeId == Id);
            ViewBag.CurrentPicture = emp.EmployeePicture;
            return View(new EmployeeUpdateModel
            {
                EmployeeId = emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                EmployeePhone = emp.EmployeePhone,
                EmployeeSalary = emp.EmployeeSalary,
                EmployeeDepartment = emp.EmployeeDepartment,
                EmployeeJoinDate = emp.EmployeeJoinDate,
                EmployeeGender = emp.EmployeeGender,
                Continued = emp.Continued,
                BranchId = emp.BranchId
            });
        }
        //Update Post Action
        [HttpPost]
        public IActionResult Update(EmployeeUpdateModel emp)
        {
            var empExist = db.Employees.First(e => e.EmployeeId == emp.EmployeeId);
            if (ModelState.IsValid)
            {
                empExist.EmployeeName = emp.EmployeeName;
                empExist.EmployeePhone = emp.EmployeePhone;
                empExist.EmployeeSalary = emp.EmployeeSalary;
                empExist.EmployeeDepartment = emp.EmployeeDepartment;
                empExist.EmployeeJoinDate = emp.EmployeeJoinDate;
                empExist.EmployeeGender = emp.EmployeeGender;
                empExist.Continued = emp.Continued;
                empExist.BranchId = emp.BranchId;
                if (emp.EmployeePicture != null && emp.EmployeePicture.Length > 0)
                {
                    string dir = Path.Combine(env.WebRootPath, "Uploads");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string fileName = Guid.NewGuid() + Path.GetExtension(emp.EmployeePicture.FileName);
                    string fullPath = Path.Combine(dir, fileName);
                    FileStream fs = new FileStream(fullPath, FileMode.Create);
                    emp.EmployeePicture.CopyTo(fs);
                    fs.Flush();
                    empExist.EmployeePicture = fileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branches = db.Branches.ToList();
            ViewBag.currentPicture = empExist.EmployeePicture;
            return View(emp);
        }
        //Update Action
        public IActionResult Delete(int Id)
        {
            return View(db.Employees.Include(e => e.Branches).First(e => e.EmployeeId == Id));
        }
        //Delete Post Action
        [HttpPost, ActionName("Delete")]
        public IActionResult DoDelete(int Id)
        {
            var Employee = new Employee { EmployeeId = Id };
            db.Entry(Employee).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Info Action
        public ActionResult Info(int Id)
        {
            ViewBag.Branches = db.Branches.ToList();
            return View(db.Employees.First(e => e.EmployeeId == Id));
        }
        //Info Post Action
        [HttpPost, ActionName("Info")]
        public ActionResult DoInfo(int Id)
        {
            return RedirectToAction("Info");
        }
    }
}
