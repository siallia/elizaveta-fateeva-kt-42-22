using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Database.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "cd_position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.PositionId)
                .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.PositionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("position_id");

            builder.Property(p => p.PositionName)
                .IsRequired()
                .HasColumnName("position_name")
                .HasMaxLength(100);

            builder.ToTable(TableName);
        }
    }
}
