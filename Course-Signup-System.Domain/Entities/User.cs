﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Domain.Entities
{
    public class User
    {
        [Key]
        [StringLength(13)]
        public string UserId { get; set; } = null!;
        [StringLength(50)]
        public string FirstName { get; set; } = null!; // Ten 

        [StringLength(50)]
        public string LastName { get; set; } = null!; // Ho

        [StringLength(255)]
        public string Email { get; set; } = null!;
      
        [StringLength(255)]
        public string PasswordHash { get; set; } = null!;

        [StringLength(255)]
        public string PasswordSalt { get; set; } = null!;

        [StringLength(255)]
        public string? Avatar {  get; set; }
        [StringLength(6)]
        public string? VerificationCode { get; set; } = null!;

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; } = null!;

    }
}
