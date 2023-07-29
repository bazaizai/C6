using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AppData.Config
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Bills).HasForeignKey(x => x.IdUser);
            builder.Property(x => x.Ma).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.NgayTao).HasColumnType("DateTime");
            builder.Property(x => x.NgayThanhToan).HasColumnType("DateTime");
            builder.Property(x => x.DiaChi).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Sdt).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.TienShip).HasColumnType("int");


        }
    }
}
