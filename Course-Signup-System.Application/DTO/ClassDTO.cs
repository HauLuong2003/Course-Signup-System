using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Application.DTO
{
    public class ClassDTO
    {
        public string ClassId { get; set; } = null!;

        [StringLength(100)]
        public string ClassName { get; set; } = null!;

        public bool Status { get; set; }

        public double Tuition { get; set; } //học phi

        public int NumberStudent { get; set; }

        public int MaxNumberStudent { get; set; }

        public string? Description { get; set; } = null!;
       
        public string? Avatar { get; set; } = null!;

        public string ClassOfId { get; set; } = null!;
        public string FacultyId { get; set; } = null!;
        //public ICollection<StudentClassDTO> StudentClassesDTO { get; set; } = null!;

    }
}
