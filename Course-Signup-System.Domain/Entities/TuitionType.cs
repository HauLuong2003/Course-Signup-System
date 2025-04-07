using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Domain.Entities
{
    public class TuitionType // loại học phí 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TuitionTypeId { get; set; }

        public string TuitionName { get; set; } = null!;

        public ICollection<PayTuition> PayTuitions { get; set; } = new List<PayTuition>();
    }
}
