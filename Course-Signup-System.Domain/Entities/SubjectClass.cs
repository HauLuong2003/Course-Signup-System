﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Domain.Entities
{
    public class SubjectClass// môn học trong lớp và tổ bộ môn // danh sach mon hoc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id {  get; set; }

        public bool IsClose { get; set; } = false;
        
        public string SubjectId { get; set; } = null!;
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; } = null!;
        
        public string ClassId { get; set; } = null!;
        [ForeignKey("ClassId")]
        public Class Class { get; set; } = null!;
        
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } = null!;
       

    }
}
