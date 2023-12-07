using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Student_Crud_PrecticalTest.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
     
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        public string ? Gender { get; set; }
        public DateTime ? BirthDate { get; set; }

        [Required]
        [Phone]
        public string ContactNo { get; set; }
        [Required]
        public string EmailId { get; set; }

        public string ? City { get; set; }
        public string ? Hobbies { get; set; }
        public int ? Standard { get; set; }



    }
}
