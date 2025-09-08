using Day03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Day03.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("SqlServer:IdentityIncrement", 10)
                .HasAnnotation("SqlServer:IdentitySeed", 10);

            
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasDefaultValue("OurProject");

            builder.Property(p => p.Cost)
                .HasColumnType("money");

            
            builder.ToTable("Projects");
        }
    }
}