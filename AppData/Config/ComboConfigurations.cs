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
    public class ComboConfigurations : IEntityTypeConfiguration<Combo>
    {
        void IEntityTypeConfiguration<Combo>.Configure(EntityTypeBuilder<Combo> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Ma).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(c => c.Ten).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
