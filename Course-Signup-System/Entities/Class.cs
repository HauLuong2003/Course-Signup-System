using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Entities
{
    public class Class
    {
        [Key, StringLength(20)]
        public int ClassId { get; set; }

        [StringLength(100)]
        public string ClassName { get; set; } = null!;

        public bool Status { get; set; }

        public double Tuition { get; set; } //học phi

        public double NumberStudent { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Avatar {  get; set; }

        public string ClassOfId { get; set; }
        [ForeignKey("ClassOfId")]
        public ClassOf ClassOf { get; set; }

        public string FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }

        public ICollection<StudentClass> StudentClasses {  get; set; }
                
    }
}
