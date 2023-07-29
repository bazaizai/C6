using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Config
{
    public class ComboDetailConfigurations : IEntityTypeConfiguration<ComboDetail>
    {
        void IEntityTypeConfiguration<ComboDetail>.Configure(EntityTypeBuilder<ComboDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdProductDetail).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.IdCombo).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.GiaBan).HasColumnType("decimal");
            builder.HasOne(x => x.Product).WithMany(x => x.ComboDetails).HasForeignKey(x => x.IdProductDetail);
            builder.HasOne(x => x.Combo).WithMany(x => x.ComboDetail).HasForeignKey(x => x.IdCombo);
        }
    }
}
