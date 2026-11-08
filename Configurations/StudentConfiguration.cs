using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Phone)
                .HasMaxLength(20);

            builder.HasIndex(s => s.Email).IsUnique();
        }
    }
}
