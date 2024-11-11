﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Entities
{
    public class Department// tổ bộ môn
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(150)]
        public string DepartmentName { get; set; }

        public DateTime StartStudy { get; set; }

        public DateTime EndStudy { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
