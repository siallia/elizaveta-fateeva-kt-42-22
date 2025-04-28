using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Database.Configuration
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        private const string TableName = "cd_degree";

        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder.HasKey(d => d.DegreeId)
                .HasName($"pk_{TableName}_degree_id");

            builder.Property(d => d.DegreeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("degree_id");

            builder.Property(d => d.DegreeName)
                .IsRequired()
                .HasColumnName("degree_name")
                .HasMaxLength(100);

            builder.ToTable(TableName);
        }
    }
}
