using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Entities
{
    public class Grade // thêm điểm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradeId {  get; set; }

        public double Score { get; set; }

        public DateTime GradeDate { get; set; }


    }
}
