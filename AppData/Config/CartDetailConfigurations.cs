using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppData.Config
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserID).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.DetailProductID).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.IdCombo).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.Soluong).HasColumnType("int");
            builder.Property(x => x.Dongia).HasColumnType("decimal");
            builder.HasOne(x => x.Cart).WithMany(x => x.cartdetail).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.ProductDetail).WithMany(x => x.CartDetail).HasForeignKey(x => x.DetailProductID);
            builder.HasOne(x => x.Combo).WithMany(x => x.CartDetails).HasForeignKey(x => x.IdCombo);
        }
    }
}
