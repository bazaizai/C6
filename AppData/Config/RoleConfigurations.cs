using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppData.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Ten).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("int").IsRequired();
        }
    }
}
