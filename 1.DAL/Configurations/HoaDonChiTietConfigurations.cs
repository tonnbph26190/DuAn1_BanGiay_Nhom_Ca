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
    internal class HoaDonChiTietConfigurations : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoaDonChiTiet"); // Đặt tên bảng (Nếu ko thì lấy mặc định của class)
            builder.HasKey(x => x.Id); // Set khóa chính

            // Cấu hình dữ liệu
            builder.Property(k => k.IdhoaDon).IsRequired();
            builder.Property(k => k.IdChiTIetSp).IsRequired();

            builder.Property(p => p.TrangThai).HasColumnName("TrangThai").
                HasColumnType("int"); // varchar(100) not nul
            builder.Property(p => p.DonGia).HasColumnName("DonGia").HasColumnType("float"); // nvarchar(100) not null
            builder.Property(p => p.SoLuong).HasColumnName("SoLuong").HasColumnType("int"); // nvarchar(100) not null
            builder.Property(p => p.GiamGia).HasColumnName("GiamGia").HasColumnType("float"); // nvarchar(100) not null
            builder.Property(p => p.ThanhTien).HasColumnName("ThanhTien").HasColumnType("float"); // nvarchar(100) not null
            builder.Property(p => p.GhiChu).HasColumnName("ChiChu").HasColumnType("nvarchar(100)"); // nvarchar(100) not null
            // Set khóa ngoại
            builder.HasOne(x => x.HoaDon)
           .WithMany().HasForeignKey(p => p.IdhoaDon);
            builder.HasOne(x => x.ChiTietSp)
            .WithMany().HasForeignKey(p => p.IdChiTIetSp);





        }
    }
}
