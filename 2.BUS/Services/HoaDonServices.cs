using _1.DAL.IRepositories;
using _1.DAL.Models;
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
    public class HoaDonServices : IHoaDonService
    {
        private IHoaDonRepository _iHoaDonRepository;
        private IKhachHangReposistories _iKhachhangRepository;
        private INhanVienService _iQlNhanvienSerivce;
        private INhanVienRepository _invRepos;

        DateTime? nullDateTime = null;

        public HoaDonServices()
        {
            _iHoaDonRepository = new HoaDonRepository();
            _iKhachhangRepository = new KhachHangReposistories();
            _iQlNhanvienSerivce = new NhanVienService();
            _invRepos = new NhanVienRepository();
        }

        public string Add(HoaDonView obj)
        {
            if (obj == null) return "thêm thất bại";
            var hoaDon = new HoaDon()
            {
                Id = Guid.Empty,
                MaHoaDon = obj.MaHoaDon,
                IdKhachHang = obj.IdKhachHang,
                IdNhanVien = obj.IdNhanVien,
                NgayLap = obj.NgayLap,
                NgayThanhToan = obj.NgayThanhToan,
                NgayShipHang = obj.NgayShipHang,
                NgayNhanHang = obj.NgayNhanHang,
                TrangThai = obj.TrangThai,
                NguoiBan = obj.NguoiBan,
                Sdt = obj.Sdt,

            };
            if (_iHoaDonRepository.Add(hoaDon)) return "thêm thành công";
            return "thêm thất bại";
        }

        public string Update(HoaDonView obj)
        {
            if (obj == null) return "sửa thất bại";
            var hoaDon = _iHoaDonRepository.GetAll().FirstOrDefault(c => c.Id == obj.Id);
            //hoaDon.Ma = obj.MaHd;
            hoaDon.MaHoaDon = obj.MaHoaDon;
            hoaDon.IdKhachHang = obj.IdKhachHang;
            hoaDon.IdNhanVien = obj.IdNhanVien;
            hoaDon.NgayLap = obj.NgayLap;
            hoaDon.NgayShipHang = obj.NgayShipHang;
            hoaDon.NgayNhanHang= obj.NgayNhanHang;
            obj.NgayThanhToan = obj.NgayThanhToan;
            hoaDon.NgayLap = obj.NgayLap;
            hoaDon.TrangThai = obj.TrangThai;
            hoaDon.NguoiBan = obj.NguoiBan;
            hoaDon.Sdt = obj.Sdt;
            if (_iHoaDonRepository.Update(hoaDon)) return "sửa thành công";
            return "sửa thất bại";
        }

        public string Delete(HoaDonView obj)
        {
            if (obj == null) return "xóa thất bại";
            var hoaDon = _iHoaDonRepository.GetAll().FirstOrDefault(c => c.Id == obj.Id);
            if (_iHoaDonRepository.Delete(hoaDon)) return "xóa thành công";
            return "xóa thất bại";
        }

        public List<string> TrangThai()
        {
            return new List<string>() { "Chưa thanh toán", "Đã thanh toán", "Hủy", "Đang giao", "Đã giao", "Hoàn thành" };
        }

        public List<HoaDonView> ShowHoadon()
        {
            var data =
                (
                    from a in _iHoaDonRepository.GetAll()
                    join b in _iKhachhangRepository.GetAll() on a.IdKhachHang equals b.Id
                    join c in _iQlNhanvienSerivce.GetAll() on a.IdNhanVien equals c.Id
                    select new HoaDonView()
                    {
                        Id = a.Id,
                        MaHoaDon = a.MaHoaDon,
                        NgayLap = a.NgayLap==null?nullDateTime.Value:a.NgayLap,
                        NgayNhanHang=a.NgayNhanHang == null ? nullDateTime.Value : a.NgayNhanHang,
                        NgayShipHang=a.NgayShipHang == null ? nullDateTime.Value : a.NgayShipHang,
                        NgayThanhToan=a.NgayThanhToan == null ? nullDateTime.Value : a.NgayThanhToan,
                        IdNhanVien = c.Id,
                        IdKhachHang = b.Id==null?Guid.Empty:b.Id,
                        NguoiBan = c.TenNhanVien,
                        TrangThai = a.TrangThai,
                        TenKH=b.Ten
                    }
                ).ToList();
            return data;
        }

        public List<HoaDonView> GetAll()
        {
            List<HoaDonView> data = new List<HoaDonView>();
            data =
               (
                   from a in _iHoaDonRepository.GetAll()
                   join b in _iKhachhangRepository.GetAll() on a.IdKhachHang equals b.Id
                   join c in _invRepos.GetAll() on a.IdNhanVien equals c.Id
                   select new HoaDonView()
                   {
                       Id = a.Id,
                       MaHoaDon = a.MaHoaDon,
                       NgayLap = a.NgayLap,
                       NgayNhanHang = a.NgayNhanHang,
                       NgayShipHang = a.NgayShipHang,
                       NgayThanhToan = a.NgayThanhToan,
                       IdNhanVien = c.Id,
                       IdKhachHang = b.Id,
                       NguoiBan = c.TenNhanVien,
                       TrangThai = a.TrangThai,
                       TenKH = b.Ten,
                       hoaDon = a,
                       khachHang = b,
                       nhanVien = c,
                   }
               ).ToList();
            return data;
        }
    }
}
