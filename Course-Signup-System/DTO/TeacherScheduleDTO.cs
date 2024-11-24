﻿using Course_Signup_System.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Signup_System.DTO
{
    public class TeacherScheduleDTO
    {
        public int Id { get; set; }

        public TimeOnly StudyTime { get; set; }

        public DayOfWeek StudyDay { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string UserId { get; set; } = null!;

        public string ClassId { get; set; } = null!;

        public string SubjectId { get; set; } = null!;

    }
}