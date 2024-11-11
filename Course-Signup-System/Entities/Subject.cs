using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Entities
{
    public class Subject
    {
        [Key,StringLength(20)]
        public string SubjectId { get; set; }

        [StringLength(100)]
        public string SubjectName { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public string FacultyId {  get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }
    }
}
