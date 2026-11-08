using System.ComponentModel.DataAnnotations;
namespace CourseManagementSystem.DTOs.Students;
public class StudentCreateDto { [Required, MaxLength(150)] public string FullName { get; set; } = string.Empty; [Required, EmailAddress, MaxLength(200)] public string Email { get; set; } = string.Empty; [MaxLength(20)] public string? Phone { get; set; } }
public class StudentUpdateDto : StudentCreateDto { }
public record StudentResponseDto(int Id, string FullName, string Email, string? Phone);
