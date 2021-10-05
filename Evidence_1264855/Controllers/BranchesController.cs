using Evidence_1264855.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence_1264855.Controllers
{
    public class BranchesController : Controller
    {
        //Db Inject Dependency/ db Context
        readonly CompanyDbContext db = null;
        public BranchesController(CompanyDbContext db) { this.db = db; }

        //Index Action
        public IActionResult Index()
        {
            return View(db.Branches.ToList());
        }
        //Create Action
        public IActionResult Create()
        {
            return View();
        }
        //Create Post Action
        [HttpPost]
        public IActionResult Create(Branch Branch)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Add(Branch);
                db.SaveChanges();
                return PartialView("_MessegeCreatePartial", true);
            }
            return PartialView("_MessegeCreatePartial", false);
        }
        //Update Action
        public IActionResult Update(int Id)
        {
            return View(db.Branches.First(b => b.BranchId == Id));
        }
        //Update Post Action
        [HttpPost]
        public IActionResult Update(Branch Branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Branch).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return PartialView("_MessegeUpdatePartial", true);
            }
            return PartialView("_MessegeUpdatePartial", false);
        }
        //Delete Action
        public IActionResult Delete(int Id)
        {
            return View(db.Branches.First(b => b.BranchId == Id));
        }
        //Delete Post Action
        [HttpPost, ActionName("Delete")]
        public IActionResult DoDelete(int Id)
        {
            Branch bran = new Branch { BranchId = Id };
            if (!db.Employees.Any(p => p.BranchId == Id))
            {
                db.Entry(bran).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return PartialView("_MessegeDeletePartial", true);
            }
            //ModelState.AddModelError("", "You Cann't Delete the Project because it relatated to Employees.");
            //return View(db.Branches.First(b => b.BranchId == Id));
            return PartialView("_MessegeDeletePartial", false);
        }
    }
}
