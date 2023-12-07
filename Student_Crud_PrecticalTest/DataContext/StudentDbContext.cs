using Microsoft.EntityFrameworkCore;
using Student_Crud_PrecticalTest.Models;

namespace Student_Crud_PrecticalTest.DataContext
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
