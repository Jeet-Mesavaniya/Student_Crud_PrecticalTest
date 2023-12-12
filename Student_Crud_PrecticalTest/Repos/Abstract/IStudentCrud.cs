using Student_Crud_PrecticalTest.Models;

namespace Student_Crud_PrecticalTest.Repos.Abstract
{
    public interface IStudentCrud
    {
        Task<Student> StudentListByAjaxGetData(string searchText);
    }
}
