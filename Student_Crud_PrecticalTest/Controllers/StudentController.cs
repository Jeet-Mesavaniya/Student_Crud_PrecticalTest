using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Crud_PrecticalTest.DataContext;
using Student_Crud_PrecticalTest.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Student_Crud_PrecticalTest.Repos.Implementation;
using Student_Crud_PrecticalTest.Migrations;
using System.Text.RegularExpressions;

namespace Student_Crud_PrecticalTest.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext context;

        public StudentController(StudentDbContext context)
        {
            this.context = context;
        }

        public IActionResult StudentListByAjax()
        {
            return View();
        }
        [HttpGet]
        public JsonResult StudentListByAjaxGetData(string searchtext, StudentCrud ssb)
        {
            //StudentCrud ab = new StudentCrud();
            return ssb.StudentListByAjaxGetData_b(searchtext, context);




            //if (searchtext != null  && searchtext != "")
            //{
            //    var adata = from a in context.Students
            //                where a.FirstName.Contains(searchtext) || a.LastName.Contains(searchtext)
            //                select new Student
            //                {
            //                    FirstName = a.FirstName,
            //                    LastName = a.LastName,
            //                    Gender = a.Gender,
            //                };
            //    return new JsonResult(adata);
            //}
            //var data = context.Students.ToList();
            //return new JsonResult(data);
        }
        public IActionResult Index(string search)
        {
            try
            {
                if (search != "" && search != null)
                {
                    var datas = context.Students.FirstOrDefault(e => e.FirstName.Contains(search));
                    return View(datas);
                }
                var data = context.Students.ToList();
                return View(data);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public IActionResult AddStudent() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student model)
        {
          
           
            if(model.Id == 0) 
            {
                string pattern = @"^ (\+\d{ 1, 2 } \s)?\(?\d{ 3 } \)?[\s.-]\d{ 3 } [\s.-]\d{ 4 } $";
                string pattern2 = "^\\d{10}$";
                var contact = model.ContactNo;
                Match match = Regex.Match(contact, pattern2, RegexOptions.IgnoreCase);
                if (!match.Success) 
                {
                    return View("AddStudent");
                }
                context.Students.Add(model);
                await context.SaveChangesAsync();   
            }
            return RedirectToAction("Index");
            
        }

        public IActionResult Delete(int id)
        {
            var data = context.Students.SingleOrDefault(e =>e.Id == id);
            if(data != null)
            {
                context.Students.Remove(data);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = context.Students.SingleOrDefault(e => e.Id == id);
            var result = new Student()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Gender = data.Gender,
                BirthDate = data.BirthDate,
                City = data.City,
                ContactNo = data.ContactNo,
                EmailId = data.EmailId,
                Hobbies = data.Hobbies,
                Standard = data.Standard,
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if(model.Id != 0)
            {
                context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //private void LoadDDL()
        //{
        //    List<string> Gender = new List<string>();
        //  
        //}
    }
}
