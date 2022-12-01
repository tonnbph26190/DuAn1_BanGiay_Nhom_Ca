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
    internal class GioHangConfigurations :IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHang"); // Đặt tên bảng (Nếu ko thì lấy mặc định của class)
            builder.HasKey(x => x.Id); // Set khóa chính
             // Cấu hình dữ liệu
            builder.Property(p => p.Ma).HasColumnName("Ma").HasColumnType("varchar(30)"); // varchar(30) not null
            builder.Property(p => p.NgayThanhToan).HasColumnName("NgayThanhToan").
                 HasColumnType("varchar(30)"); // varchar(30) not null
            builder.Property(p => p.NgayTao).HasColumnName("NgayTao").HasColumnType("varchar(30)"); // varchar(30) not null
            builder.Property(p => p.TenNguoiNhan).HasColumnName("TenNguoiNhan").HasColumnType("varchar(30)"); // varchar(30) not null
            builder.Property(p => p.Sdt).HasColumnName("SdtKhanh").HasColumnType("varchar(30)"); // varchar(30) not null
            builder.Property(p => p.TrangThai).HasColumnName("TrangThai").HasColumnType("int"); // varchar(30) not null
            builder.Property(k => k.IdNV).IsRequired();
            builder.Property(k => k.IdKH).IsRequired();
            // Set khóa ngoại
            builder.HasOne(x => x.NhanVien)
           .WithMany().HasForeignKey(p => p.IdNV);
            builder.HasOne(x => x.KhachHang)
            .WithMany().HasForeignKey(p => p.IdKH);

        }
    }
}
