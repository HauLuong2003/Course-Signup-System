using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Entities
{
    public class Faculty
    {
        [Key,StringLength(20)]
        public string FacultyId { get; set; }

        [StringLength(150)] 
        public string FacultyName { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Class> Class { get; set; }
    }
}
