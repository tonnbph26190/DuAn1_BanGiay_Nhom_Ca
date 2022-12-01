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

        public HoaDonServices()
        {
            _iHoaDonRepository = new HoaDonRepository();
            _iKhachhangRepository = new KhachHangReposistories();
            _iQlNhanvienSerivce = new NhanVienService();
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
                NgayThanhToan = DateTime.Now,
                NgayShipHang = DateTime.Now,
                NgayNhanHang = DateTime.Now,
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
                        NgayLap = a.NgayLap,
                        IdNhanVien = c.Id,
                        IdKhachHang = b.Id,
                        NguoiBan = c.TenNhanVien,
                        TrangThai = a.TrangThai,
                        TenKH=b.Ten
                    }
                ).ToList();
            return data;
        }
    }
}
