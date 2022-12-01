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
    internal class ChiTietSPConfigurations : IEntityTypeConfiguration<ChiTietSp>
    {
        public void Configure(EntityTypeBuilder<ChiTietSp> builder)
        {
            builder.ToTable("ChiTietSP"); // Đặt tên bảng (Nếu ko thì lấy mặc định của class)
            builder.HasKey(x => x.Id); // Set khóa chính
            // Cấu hình dữ liệu
            builder.Property(p => p.SoLuong).HasColumnName("SoLuong").
                HasColumnType("int"); // nvarchar(100) not null
            builder.Property(p => p.DonGiaNhap).HasColumnName("GiaNhap").HasColumnType("float"); // nvarchar(100) not null
            builder.Property(p => p.DonGiaBan).HasColumnName("GiaBan").HasColumnType("float"); // nvarchar(100) not null
            builder.Property(p => p.TrangThai).HasColumnName("TrangThai").HasColumnType("int"); // nvarchar(100) not null
            builder.Property(p => p.MoTa).HasColumnName("Mota").HasColumnType("nvarchar(100)"); // nvarchar(100) not null
            builder.Property(p => p.Mavach).HasColumnName("Mavach").HasColumnType("nvarchar(100)"); // nvarchar(100) not null
            builder.Property(p => p.Ma).HasColumnName("Ma").HasColumnType("varchar(100)"); // nvarchar(100) not null
            builder.Property(p => p.Anh).HasColumnName("Anh").HasColumnType("varchar(100)"); // nvarchar(100) not null
            builder.Property(k => k.IdDongSP);
            builder.Property(k => k.IdSp);
            builder.Property(k => k.IdNsx);
            builder.Property(k => k.IdchatLieu);
            builder.Property(k => k.IdSize);
            builder.Property(k => k.IdMauSac);
            //set khoa phu
            builder.HasOne(x => x.NSX)
            .WithMany().HasForeignKey(p => p.IdNsx);
            builder.HasOne(x => x.SanPham)
            .WithMany().HasForeignKey(p => p.IdSp);
            builder.HasOne(x => x.DongSp)
            .WithMany().HasForeignKey(p => p.IdDongSP);
            builder.HasOne(x => x.ChatLieu)
            .WithMany().HasForeignKey(p => p.IdchatLieu);
            builder.HasOne(x => x.MauSac)
            .WithMany().HasForeignKey(p => p.IdMauSac);
            builder.HasOne(x => x.Size)
           .WithMany().HasForeignKey(p => p.IdSize);
        }
    }
}
