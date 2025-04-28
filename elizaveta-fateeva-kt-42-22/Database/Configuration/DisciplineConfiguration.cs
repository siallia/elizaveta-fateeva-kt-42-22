using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Database.Configuration
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.HasKey(d => d.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            builder.Property(d => d.DisciplineId)
                .ValueGeneratedOnAdd()
                .HasColumnName("discipline_id");

            builder.Property(d => d.DisciplineName)
                .IsRequired()
                .HasColumnName("discipline_name")
                .HasMaxLength(150);

            builder.ToTable(TableName);
        }
    }
}
