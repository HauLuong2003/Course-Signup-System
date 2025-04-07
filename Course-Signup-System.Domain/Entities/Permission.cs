using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Domain.Entities
{
    public class Permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PermissionId { get; set; }
        [StringLength(150)]
        public string PermissionName { get; set; } = null!;
        public ICollection<RolePermission> RolePermissions { get; set; } = null!;
    }
}
