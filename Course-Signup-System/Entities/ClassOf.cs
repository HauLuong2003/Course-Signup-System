using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Entities
{
    public class ClassOf// khóa đào tạo
    {
        [Key,StringLength(20)]
        public string ClassOfId { get; set; }

        [StringLength(150)]
        public string ClassOfName { get; set; }


    }
}
