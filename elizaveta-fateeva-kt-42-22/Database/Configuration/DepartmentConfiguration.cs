using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Database.Configuration
{


        public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
        {
            private const string TableName = "cd_department";

            public void Configure(EntityTypeBuilder<Department> builder)
            {
                builder.HasKey(d => d.DepartmentId)
                    .HasName($"pk_{TableName}_department_id");


            builder.Property(d => d.DepartmentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("department_id")
                    .HasComment("Идентификатор кафедры");

                builder.Property(d => d.DepartmentName)
                    .IsRequired()
                    .HasColumnName("department_name")
                    .HasMaxLength(150)
                    .HasComment("Название кафедры");

                builder.Property(d => d.Year)
                    .HasColumnName("foundation_year")
                    .HasComment("Год основания кафедры");

                builder.Property(d => d.HeadOfDepartmentId)
                    .HasColumnName("head_of_department_id")
                    .HasComment("Идентификатор заведующего кафедрой");

                builder.ToTable(TableName);


            builder.HasOne(d => d.HeadOfDepartment)
                .WithOne(t => t.ManagedDepartment) 
                .HasForeignKey<Department>(d => d.HeadOfDepartmentId)
                .HasConstraintName($"fk_{TableName}_head_of_department")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
    }

