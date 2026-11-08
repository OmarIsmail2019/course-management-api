using System.ComponentModel.DataAnnotations;
namespace CourseManagementSystem.DTOs.Instructors;
public class InstructorCreateDto { [Required, MaxLength(150)] public string FullName { get; set; } = string.Empty; [Required, EmailAddress, MaxLength(200)] public string Email { get; set; } = string.Empty; [MaxLength(150)] public string? Specialization { get; set; } }
public class InstructorUpdateDto : InstructorCreateDto { }
public record InstructorResponseDto(int Id, string FullName, string Email, string? Specialization);
