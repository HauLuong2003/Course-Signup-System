using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Application.DTO
{
    public class SubjectGradeTypeDTO
    {
        public int? Id { get; set; }

        public int GradeColumn { get; set; } // số cột điểm

        public int MandatoryColumnGrade { get; set; }// số cột điểm bắt buộc

        public string ClassOfId { get; set; } = null!;
        public string? ClassOfName { get; set; } = null!;

        public string SubjectId { get; set; } = null!;
        public string? SubjectName { get; set; } = null!;

        public int GradeTypeId { get; set; }
        public string? GradeTypeName { get; set; } = null!;

    }
}
