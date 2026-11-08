using System.Collections.Generic;

namespace CourseManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInHours { get; set; }

        // Foreign keys
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }

        // Navigation properties
        public Category Category { get; set; } = null!;
        public Instructor Instructor { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
