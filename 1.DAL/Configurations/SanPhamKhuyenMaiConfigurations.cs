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
    internal class SanPhamKhuyenMaiConfigurations : IEntityTypeConfiguration<SanPhamKhuyenMai>
    {
        public void Configure(EntityTypeBuilder<SanPhamKhuyenMai> builder)
        {
            builder.ToTable("SanPhamKhuyenMai"); // Đặt tên bảng (Nếu ko thì lấy mặc định của class)
            builder.HasKey(x => x.Id); // Set khóa chính
            // Cấu hình dữ liệu
            builder.Property(k => k.IdKhuyenMai);
            builder.Property(k => k.IdSanPham);
            builder.Property(p => p.TrangThai).HasColumnName("TrangThai").
                HasColumnType("int"); // varchar(100) not null
            // Set khóa ngoại
             builder.HasOne(x => x.KhuyenMai)
            .WithMany().HasForeignKey(p => p.IdKhuyenMai);
            builder.HasOne(x => x.SanPham)
            .WithMany().HasForeignKey(p => p.IdSanPham);





        }
    }
}
