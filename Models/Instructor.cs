using System.Collections.Generic;

namespace CourseManagementSystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Specialization { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
