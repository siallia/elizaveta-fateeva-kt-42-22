using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Database.Configuration
{
    public class StudyLoadConfiguration : IEntityTypeConfiguration<StudyLoad>
    {
        private const string TableName = "cd_study_load";

        public void Configure(EntityTypeBuilder<StudyLoad> builder)
        {
            builder.HasKey(s => s.StudyLoadId)
                .HasName($"pk_{TableName}_study_load_id");

            builder.Property(s => s.StudyLoadId)
                .ValueGeneratedOnAdd()
                .HasColumnName("study_load_id");

            builder.Property(s => s.TeacherId)
                .HasColumnName("teacher_id");

            builder.Property(s => s.DisciplineId)
                .HasColumnName("discipline_id");

            builder.Property(s => s.hours)
                .HasColumnName("hours");

            builder.ToTable(TableName);

            builder.HasOne(s => s.Teacher)
                .WithMany()
                .HasForeignKey(s => s.TeacherId)
                .HasConstraintName($"fk_{TableName}_teacher_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Discipline)
                .WithMany()
                .HasForeignKey(s => s.DisciplineId)
                .HasConstraintName($"fk_{TableName}_discipline_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
