using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Course_Signup_System.Entities
{
    public class Teacher : User
    {
        
        [StringLength(255)]
        public string MainTeachingSubject { get; set; }
        [StringLength(255)]
        public string PartTimeSubject { get;set; }
        [StringLength(255)]
        public string TaxCode { get; set; }
        [StringLength(12)]
        public string IdentityCard { get; set; }
    }
}
