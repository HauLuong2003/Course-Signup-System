﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.Domain.Entities
{
    public class StudentClass// đăng kí 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int StudentClassId { get; set; }

        public bool Status { get; set; } = false;

        public string UserId { get; set; } = null!;
        [ForeignKey("UserId")]
        public Student Student { get; set; } = null!;

        public string ClassId { get; set; } = null!;
        [ForeignKey("ClassId")]
        public Class Class { get; set; } = null!;

        public DateTime CreateAt { get; set; }
        public ICollection<PayTuition> PayTuitions { get; set; } = new List<PayTuition>();

    }
}
