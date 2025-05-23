﻿using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.Domain.Entities
{
    public class Faculty // khoa
    {
        [Key,StringLength(20)]
        public string FacultyId { get; set; } = null!;

        [StringLength(150)] 
        public string FacultyName { get; set; } = null!;

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public ICollection<Subject> Subjects { get; set; } = null!;

        public ICollection<Class> Class { get; set; } = null!;
    }
}
