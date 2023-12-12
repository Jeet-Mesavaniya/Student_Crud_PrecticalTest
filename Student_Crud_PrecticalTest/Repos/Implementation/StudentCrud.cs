using Microsoft.AspNetCore.Mvc;
using Student_Crud_PrecticalTest.DataContext;
using Student_Crud_PrecticalTest.Models;
using Student_Crud_PrecticalTest.Repos.Abstract;

namespace Student_Crud_PrecticalTest.Repos.Implementation
{

    public class StudentCrud 
        //: IStudentCrud
    {
        public StudentCrud()
        {
        }
        public JsonResult StudentListByAjaxGetData_b(string searchtext, StudentDbContext context)
        {
            if (searchtext != null && searchtext != "")
            {
                var adata = from a in context.Students
                            where a.FirstName.Contains(searchtext) || a.LastName.Contains(searchtext)
                            select new Student
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                Gender = a.Gender,
                            };
                return new JsonResult(adata);
            }
            var data = context.Students.ToList();
            return new JsonResult(data);
        }
        //public Task<Student> StudentListByAjaxGetData(string searchText)
        //{
        //    var Student = new Student();


        //    //if (searchText != null && searchText != "")
        //    //{
        //    //     var adata = from a in context.Students
        //    //                where a.FirstName.Contains(searchText) || a.LastName.Contains(searchText)
        //    //                select new Student
        //    //                {
        //    //                    FirstName = a.FirstName,
        //    //                    LastName = a.LastName,
        //    //                    Gender = a.Gender,
        //    //                };

        //    //}
        //    //data = context.Students.ToList();
        //    return Student;
        //}
    }
}
