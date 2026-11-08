using System.ComponentModel.DataAnnotations;
namespace CourseManagementSystem.DTOs.Courses;
public class CourseCreateDto { [Required, MaxLength(200)] public string Title { get; set; } = string.Empty; [MaxLength(1000)] public string? Description { get; set; } [Range(0, double.MaxValue)] public decimal Price { get; set; } [Range(1, int.MaxValue)] public int DurationInHours { get; set; } [Range(1, int.MaxValue)] public int CategoryId { get; set; } [Range(1, int.MaxValue)] public int InstructorId { get; set; } }
public class CourseUpdateDto : CourseCreateDto { }
public record CourseResponseDto(int Id, string Title, string? Description, decimal Price, int DurationInHours, int CategoryId, string CategoryName, int InstructorId, string InstructorName);
