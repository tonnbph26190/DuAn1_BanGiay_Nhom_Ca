using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModel
{
    public class HdTestView
    {
        public string MaHoaDon { get; set; }
        public string MaNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public double? TongTien { get; set; }
        public int? soLuong { get; set; }
        public int? TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string NgayLap { get; set; }
        public string NgayThanhToan { get; set; }
        public string NgayNhan { get; set; }
        public int? DonHuy { get; set; }
        public int? DonThanhCong { get; set; }
        public int? DonChuaTT { get; set; }
        public int? DangGiao { get; set; }

        public int Thang { get; set; }
        public HdTestView(string maHD, string maNV, string maKH, string tenKH, string sDT,string diaChi, string email, int? soLuong, double? donGia, int? trangThai, string ngayLap, string ngayThanhToan, string ngayNhan, int? donHuy, int? donThanhCong, int? donChuaTT, int? dangGiao)
        {
            MaHoaDon = maHD;
            MaNhanVien = maNV;
            MaKhachHang = maKH;
            TenKhachHang = tenKH;
            SoDienThoai = sDT;
            DiaChi = diaChi;
            Email = email;
            TongTien = donGia*soLuong;
            TrangThai = trangThai;
            // GhiChu= ghiChu;
            NgayLap = ngayLap;
            NgayThanhToan = ngayThanhToan;
            NgayNhan = ngayNhan;
            DonHuy = donHuy;
            DonThanhCong = donThanhCong;
            DonChuaTT = donChuaTT;
            DangGiao = dangGiao;
            this.soLuong = soLuong;
        }

        public HdTestView(DateTime ngayss, double tongtien)
        {
            Thang = ngayss.Month;
        }
    }
}
