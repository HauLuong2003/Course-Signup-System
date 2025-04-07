using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Domain.Entities
{
    public class RolePermission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

    }
}
