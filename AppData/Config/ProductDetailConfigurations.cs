using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AppData.Config
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Ten).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Anh).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Loai).HasColumnType("nvarchar(100)");
            builder.Property(x => x.GiaBan).HasColumnType("int");
        }
    }
}
