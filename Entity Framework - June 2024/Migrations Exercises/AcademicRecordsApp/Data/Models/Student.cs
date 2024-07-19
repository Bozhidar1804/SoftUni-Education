using AcademicRecordsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademicRecordsApp.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            Courses = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        // Navigation Properties
        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
