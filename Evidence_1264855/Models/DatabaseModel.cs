using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence_1264855.Models
{
    public class Branch
    {
        public Branch()
        {
            this.Employees = new List<Employee>();
        }
        public int BranchId { get; set; }
        [Required, StringLength(50), Display(Name = "Branches Name")]
        public string BranchName { get; set; }
        [Required, StringLength(100), Display(Name = "Branches Address")]
        public string BranchAddress { get; set; }
        [Required(ErrorMessage = "Enter the Branch valid Email Address."), EmailAddress(ErrorMessage = "E-mail Address is not a valid."), Display(Name = "Email Address")]
        public string BranchEmail { get; set; }
        //Navigation
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required, Display(Name = "Photo")]
        public string EmployeePicture { get; set; }
        [Required, StringLength(50), Display(Name = "Emp. Name")]
        public string EmployeeName { get; set; }
        [Required, StringLength(20), Display(Name = "Phone")]
        public string EmployeePhone { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Salary(TK)")]
        public Decimal EmployeeSalary { get; set; }
        [Required, Display(Name = "Department")]
        public string EmployeeDepartment { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Join Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EmployeeJoinDate { get; set; }
        [Required, Display(Name = "Gender")]
        public String EmployeeGender { get; set; }
        [Display(Name = "Job Running")]
        public bool Continued { get; set; }
        //Foreign Key Set
        [Required, ForeignKey("Branches"), Display(Name = "Branch Name")]
        public int BranchId { get; set; }
        //Navigation
        public virtual Branch Branches { get; set; }
    }

    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
