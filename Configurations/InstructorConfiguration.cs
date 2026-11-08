using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(i => i.Specialization)
                .HasMaxLength(150);

            builder.HasIndex(i => i.Email).IsUnique();
        }
    }
}
