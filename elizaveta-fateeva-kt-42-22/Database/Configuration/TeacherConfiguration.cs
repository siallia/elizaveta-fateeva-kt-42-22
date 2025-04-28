using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Database.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(t => t.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("teacher_id");

            builder.Property(t => t.TeacherName)
                .IsRequired()
                .HasColumnName("teacher_name")
                .HasMaxLength(150);

            builder.Property(t => t.DepartmentId)
                .HasColumnName("department_id");

            builder.Property(t => t.DegreeId)
                .HasColumnName("degree_id");

            builder.Property(t => t.PositionId)
                .HasColumnName("position_id");

            builder.ToTable(TableName);

            builder.HasOne(t => t.Department)
                .WithMany()
                .HasForeignKey(t => t.DepartmentId)
                .HasConstraintName($"fk_{TableName}_department_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Degree)
                .WithMany()
                .HasForeignKey(t => t.DegreeId)
                .HasConstraintName($"fk_{TableName}_degree_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Position)
                .WithMany()
                .HasForeignKey(t => t.PositionId)
                .HasConstraintName($"fk_{TableName}_position_id")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
