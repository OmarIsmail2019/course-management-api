using System.ComponentModel.DataAnnotations;
using CourseManagementSystem.Models;
namespace CourseManagementSystem.DTOs.Enrollments;
public class EnrollmentCreateDto { [Range(1, int.MaxValue)] public int StudentId { get; set; } [Range(1, int.MaxValue)] public int CourseId { get; set; } public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow; [EnumDataType(typeof(EnrollmentStatus))] public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending; }
public class EnrollmentUpdateDto : EnrollmentCreateDto { }
public record EnrollmentResponseDto(int Id, int StudentId, string StudentName, int CourseId, string CourseTitle, DateTime EnrollmentDate, EnrollmentStatus Status);
