using System.ComponentModel.DataAnnotations;
namespace CourseManagementSystem.DTOs.Categories;
public class CategoryCreateDto { [Required, MaxLength(100)] public string Name { get; set; } = string.Empty; [MaxLength(500)] public string? Description { get; set; } }
public class CategoryUpdateDto : CategoryCreateDto { }
public record CategoryResponseDto(int Id, string Name, string? Description);
