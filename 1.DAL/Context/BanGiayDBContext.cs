using _1.DAL.Configurations;
using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Context
{
    public class BanGiayDBContext:DbContext
    {
        public BanGiayDBContext()
        {

        }
        public BanGiayDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Thực hiện các ràng buộc kết nối
            base.OnConfiguring(optionsBuilder.
                UseSqlServer("Data Source=DESKTOP-OJ4UDNH\\SQLEXPRESS;Initial Catalog=DuanMau_Giay;Persist Security Info=True;User ID=Nbton03;Password=123"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SanPhamConfigurations());
            // Apply cac config cho cac model
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Phương thức này sẽ áp dụng tất cả các config hiện có
        }
        public DbSet<ChatLieu> ChatLieus { get; set; }
        public DbSet<ChiTietSp> ChiTietSps{ get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<DongSP> DongSPs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets{ get; set; }
        public DbSet<MauSac> MauSacs{ get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<KhuyenMai> khuyenMais  { get; set; }
        public DbSet<NhanVien>NhanViens { get; set; }
        public DbSet<NSX> NSXes { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<SanPhamKhuyenMai> sanPhamKhuyenMais { get; set; }
        public DbSet<Size> Sizes { get; set; }
    }
}
