using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Entities
{
    public class Subject
    {
        [Key, StringLength(20)]
        public string SubjectId { get; set; } = null!;

        [StringLength(100)]
        public string SubjectName { get; set; } = null!;

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } = null!;

        public string FacultyId {  get; set; } = null!;
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; } = null!;

        public ICollection<SubjectClass> SubjectClasses { get; set; } = null!;
        public ICollection<TeachSchedule> TeachSchedules { set; get; } = null!;
        public ICollection<SubjectGradeType> SubjectGradeTypes { get; set;} = null!;

    }
}
