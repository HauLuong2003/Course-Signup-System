using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Course_Signup_System.Entities
{
    public class Teacher : User
    {
        
        [StringLength(255)]
        public string MainTeachingSubject { get; set; } = null!;
        [StringLength(255)]
        public string PartTimeSubject { get;set; } = null!;
        [StringLength(255)]
        public string TaxCode { get; set; } = null!;
        [StringLength(12)]
        public string IdentityCard { get; set; } = null!;
        public ICollection<TeachSchedule> TeachSchedules { get; set; } = new List<TeachSchedule>();
    }
}
