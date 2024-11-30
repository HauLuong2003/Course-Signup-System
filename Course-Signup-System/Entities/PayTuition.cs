using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Entities
{
    public class PayTuition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PayTuitionId { get; set; }

        public double Tuition { get; set; } // học phí

        public double Discount { get; set; }// giảm giá

        public double Surcharge { set; get; }// phí phụ thu

        public double EffectiveChargeRate {  get; set; }

        public string? Note { get; set; } = null!;
        
        public DateTime CreateAt { get; set; }

        public int TuitionTypeId { get; set; }
        public TuitionType TuitionType { get; set; } = null!;

        public int StudentClassId { get; set; }
        public StudentClass StudentClass { get; set; }= null!;
    }
}
