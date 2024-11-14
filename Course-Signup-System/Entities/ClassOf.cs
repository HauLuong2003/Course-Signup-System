using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Entities
{
    public class ClassOf// khóa đào tạo
    {
        [Key, StringLength(20)]
        public string ClassOfId { get; set; } = null!;

        [StringLength(150)]
        public string ClassOfName { get; set; } = null!;

        public ICollection<SubjectGradeType> SubjectGradeTypes { get; set; } = null!;
    }
}
