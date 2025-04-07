using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Domain.Entities
{
    public class SchoolHolidaySchedule// lịch nghỉ học
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string NameHoliday { set; get; } = null!;

        [StringLength(250)]
        public string Reason { set; get; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }   
    }
}
