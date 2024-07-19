using AcademicRecordsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicRecordsApp.Data.Models
{
    public class Course
    {
        public Course()
        {
            Exams = new HashSet<Exam>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation Properties
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
