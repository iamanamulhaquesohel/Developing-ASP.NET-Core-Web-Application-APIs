using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence_1264855.Models
{
    //Employee Create Model
    public class EmployeeCreateModel
    {
        public int EmployeeId { get; set; }
        [Required, Display(Name = "New Photo")]
        //IForm File for picture upload
        public IFormFile EmployeePicture { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
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
        public string EmployeeGender { get; set; }
        [Display(Name = "Job Running?")]
        public bool Continued { get; set; }
        [Required, ForeignKey("Branches"), Display(Name = "Branch Name")]
        public int BranchId { get; set; }
    }
    //Employee Update Model
    public class EmployeeUpdateModel
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Select New Photo")]
        //IForm File for picture upload
        public IFormFile EmployeePicture { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
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
        public string EmployeeGender { get; set; }
        [Display(Name = "Check it if Job Running.")]
        public bool Continued { get; set; }
        [Required, ForeignKey("Branches"), Display(Name = "Branch Name")]
        public int BranchId { get; set; }
    }
}
