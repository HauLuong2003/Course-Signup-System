﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Entities
{
    public class Grade // thêm điểm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradeId {  get; set; }

        public double Score { get; set; }

        public string UserId { get; set; } = null!;
        [ForeignKey("UserId")]
        public Student Student { get; set; } = null!;

        public string SubjectId { get; set; } = null!;
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; } = null!;

        public int GradeTypeId { get; set; }
        [ForeignKey("GradeTypeId")]
        public GradeType GradeType { get; set; } = null!;
    }
}
