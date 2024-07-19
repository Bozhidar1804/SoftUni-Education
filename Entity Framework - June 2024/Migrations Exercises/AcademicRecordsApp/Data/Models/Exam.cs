using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicRecordsApp.Data.Models
{
    public partial class Exam
    {

        public Exam()
        {
            Grades = new HashSet<Grade>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        // ForeignKey Property
        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        // Navigation Property
        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
