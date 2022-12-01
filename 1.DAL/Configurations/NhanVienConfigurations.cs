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
    internal class NhanVienConfigurations : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NhanVien"); // Đặt tên bảng (Nếu ko thì lấy mặc định của class)
            builder.HasKey(x => x.Id); // Set khóa chính
            // Cấu hình dữ liệu           
            builder.Property(p => p.MaNhanVien).HasColumnName("Ma").
                HasColumnType("varchar(30)"); // varchar(30) not null
            builder.Property(p => p.TrangThai).HasColumnName("TrangThai").HasColumnType("int"); // varchar(100) not null
            builder.Property(p => p.TenNhanVien).HasColumnName("TenNhanVien").HasColumnType("nvarchar(100)"); // nvarchar(100) not null
            builder.Property(p => p.Anh).HasColumnName("Anh").HasColumnType("nvarchar(100)"); // nvarchar(100) not null
            builder.Property(p => p.QueQuan).HasColumnName("QueQuan").HasColumnType("nvarchar(100)"); // nvarchar(100) not null
            builder.Property(p => p.Email).HasColumnName("Email").HasColumnType("nvarchar(100)"); // nvarchar(100) not null
            builder.Property(p => p.SoCmnd).HasColumnName("SoCmnd").HasColumnType("nvarchar(100)"); // nvarchar(100) not null
            builder.Property(p => p.DienThoai).HasColumnName("DienThoai").HasColumnType("varchar(11)"); // nvarchar(100) not null
            builder.Property(p => p.PassWord).HasColumnName("Pass").HasColumnType("varchar(11)"); // nvarchar(100) not null
            builder.Property(p => p.NamSinh).HasColumnName("NamSinh").HasColumnType("datetime"); // nvarchar(100) not null           
            builder.HasOne(x => x.ChucVu)
          .WithMany().HasForeignKey(p => p.IdChucVu);



        }
    }
}
