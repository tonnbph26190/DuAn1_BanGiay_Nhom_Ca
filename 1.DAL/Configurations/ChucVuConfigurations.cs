using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Configurations
{
    internal class ChucVuConfigurations : IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.ToTable("ChucVu"); // Đặt tên bảng (Nếu ko thì lấy mặc định của class)
            builder.HasKey(x => x.Id); // Set khóa chính
            // Cấu hình dữ liệu
            builder.Property(p => p.Ten).HasColumnName("Ten").
                HasColumnType("nvarchar(100)"); // nvarchar(100) not null
            builder.Property(p => p.Ma).HasColumnName("Ma").HasColumnType("varchar(30)"); // varchar(30) not null
            builder.Property(p => p.TrangThai).HasColumnName("TrangThai").HasColumnType("int"); // varchar(100) not null
             
           

        }
    }
}
