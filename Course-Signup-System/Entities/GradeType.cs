using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Entities
{
    public class GradeType //Loại điểm số
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradeTypeId { get; set; }

        [StringLength(150)]
        public string GradeTypeName { get; set; }
    }
}
