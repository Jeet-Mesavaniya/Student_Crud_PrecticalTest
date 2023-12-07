using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Crud_PrecticalTest.DataContext;
using Student_Crud_PrecticalTest.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Student_Crud_PrecticalTest.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext context;

        public StudentController(StudentDbContext context)
        {
            this.context = context;
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
