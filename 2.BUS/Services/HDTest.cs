using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class HDTest : IHdTest
    {
        private IHoaDonRepository _hdRepos;
        private INhanVienRepository _nvRepos;
        private IKhachHangReposistories _khRepos;
        private IHoaDonChiTIetRepositories _hdctRepos;

        public HDTest()
        {
            _hdRepos = new HoaDonRepository();
            _nvRepos = new NhanVienRepository();
            _khRepos = new KhachHangReposistories();
            _hdctRepos = new HoaDonChiTIetRepositories();
        }

        public List<HdTestView> GetlstHDByDay()
        {
            var lst =
                 (
                 from a in _hdRepos.GetAll()
                 join b in _nvRepos.GetAll() on a.IdNhanVien equals b.Id
                 join c in _khRepos.GetAll() on a.IdKhachHang equals c.Id
                 join d in _hdctRepos.GetAll() on a.Id equals d.IdhoaDon
                 select new { a.MaHoaDon, a.TrangThai, a.NgayLap, a.NgayThanhToan, a.NgayNhanHang, b.MaNhanVien, c.Ma, c.Ten, c.Email, c.SoDienThoai, c.DiaChi, d.ThanhTien }
                 ).ToList();

            var final = lst.OrderByDescending(c => c.ThanhTien).GroupBy(c => c.MaHoaDon).Select(g => new HdTestView(g.Key,
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.MaNhanVien).FirstOrDefault(),

                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.Ma).FirstOrDefault(),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.Ten).FirstOrDefault(),
                 g.Where(c => c.MaHoaDon == g.Key).Select(c => c.SoDienThoai).FirstOrDefault(),
                  g.Where(c => c.MaHoaDon == g.Key).Select(c => c.DiaChi).FirstOrDefault(),
                 g.Where(c => c.MaHoaDon == g.Key).Select(c => c.Email).FirstOrDefault(),
                 g.Sum(c => c.ThanhTien),
                g.Where(c => c.MaHoaDon == g.Key).Select(c => c.TrangThai).FirstOrDefault(),
                 g.Where(c => c.MaHoaDon == g.Key).Select(c => c.NgayLap.ToString("MM-dd-yyyy")).FirstOrDefault(),
                 g.Where(c => c.MaHoaDon == g.Key).Select(c => c.NgayThanhToan.ToString("MM-dd-yyyy")).FirstOrDefault(),
                 g.Where(c => c.MaHoaDon == g.Key).Select(c => c.NgayNhanHang.ToString("MM-dd-yyyy")).FirstOrDefault(),


                 g.Count(c => c.TrangThai == 0),//chuwa thanh toasn
                 g.Count(c => c.TrangThai == 1),//đã thanh toán
                 g.Count(c => c.TrangThai == 2)//đã hủy
                )).ToList();

            return final;

        }

        //public List<HdTestView> GetlstHDss()
        //{
        //    var lst =
        //          (
        //          from a in _hdRepos.GetAll()
        //          join b in _nvRepos.GetAll() on a.IdNhanVien equals b.Id
        //          join c in _khRepos.GetAll() on a.IdKhachHang equals c.Id
        //          join d in _hdctRepos.GetAll() on a.Id equals d.IdhoaDon
        //          select new { a.MaHoaDon, a.TrangThai, a.NgayLap, a.NgayThanhToan, a.NgayNhanHang, b.MaNhanVien, c.Ma, c.Ten, c.Email, c.SoDienThoai, c.DiaChi, d.ThanhTien }
        //          ).ToList();

        //    var final = lst.OrderByDescending(c => c.ThanhTien).GroupBy(c => c.NgayThanhToan.Month).Select(g => new HdTestView(g.Key,
        //        g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.MaNhanVien).FirstOrDefault(),

        //        g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.Ma).FirstOrDefault(),
        //        g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.Ten).FirstOrDefault(),
        //         g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.SoDienThoai).FirstOrDefault(),
        //          g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.DiaChi).FirstOrDefault(),
        //         g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.Email).FirstOrDefault(),
        //         g.Sum(c => c.ThanhTien),
        //        g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.TrangThai).FirstOrDefault(),
        //         g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.NgayLap.ToString("MM-dd-yyyy")).FirstOrDefault(),
        //         g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.NgayThanhToan.ToString("MM-dd-yyyy")).FirstOrDefault(),
        //         g.Where(c => c.NgayThanhToan.Month == g.Key).Select(c => c.NgayNhanHang.ToString("MM-dd-yyyy")).FirstOrDefault(),


        //         g.Count(c => c.TrangThai == 0),//chuwa thanh toasn
        //         g.Count(c => c.TrangThai == 1),//đã thanh toán
        //         g.Count(c => c.TrangThai == 2)//đã hủy
        //        )).ToList();

        //    return final;
        //}
    }
}
