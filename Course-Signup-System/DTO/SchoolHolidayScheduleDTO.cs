using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTO
{
    public class SchoolHolidayScheduleDTO
    {
        public int? Id { get; set; }

        [StringLength(250)]
        public string NameHoliday { set; get; } = null!;

        [StringLength(250)]
        public string Reason { set; get; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
