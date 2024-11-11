using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Entities
{
    public class Student : User
    {
       
        [StringLength(50)]
        public string? Parents { get; set; }
        
        public ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();
    }
}
