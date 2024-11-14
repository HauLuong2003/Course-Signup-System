using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Entities
{
    public class StudentClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),  Key]
        public int StudentClassId {  get; set; }

        public double Tuition { get; set; } // học phí

        public double Discount { get; set; }// giảm giá

        public double Surcharge { set; get; }// phí phụ thu

        public double EffectiveChargeRate =>(Tuition-(Tuition* Discount) /100)+ Surcharge;

        public bool Status { get; set; }

        public string? Note { get; set; } = null!;
        public string UserId { get; set; } = null!;
        [ForeignKey("UserId")]
        public Student Student { get; set; } = null!;

        public string ClassId { get; set; } = null!;
        [ForeignKey("ClassId")]
        public Class Class { get; set; } = null!;
    }
}
