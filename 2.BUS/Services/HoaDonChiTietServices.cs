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
    public class HoaDonChiTietServices : IHoaDonChiTietServices
    {
        private IHoaDonRepository _iHoaDonRepository;
        private IHoaDonChiTIetRepositories _iHoaDonChiTietRepository;
        private IChiTietSpServices _iQlSanphamService;

        public HoaDonChiTietServices()
        {
            _iHoaDonChiTietRepository = new HoaDonChiTIetRepositories();
            _iHoaDonRepository = new HoaDonRepository();
            _iQlSanphamService = new ChiTIetSpServices();

        }

        public string Add(HoaDonChiTIetView obj)
        {
            if (obj == null) return "thêm thất bại";
            var hoaDonChiTiet = new HoaDonChiTiet()
            {
                Id = obj.Id,
                IdhoaDon = obj.IdhoaDon,
                IdChiTIetSp = obj.IdChiTIetSp,
                SoLuong = obj.SoLuong,
                DonGia = obj.DonGia,
                GiamGia = obj.GiamGia,
               
            };
            if (_iHoaDonChiTietRepository.Add(hoaDonChiTiet)) return "thêm thành công";
            return "thêm thất bại";
        }



        public string Update(HoaDonChiTIetView obj)
        {
            if (obj == null) return "sửa thất bại";
            var hoaDonChiTiet = _iHoaDonChiTietRepository.GetAll().FirstOrDefault(c => c.IdhoaDon == obj.IdhoaDon && c.IdChiTIetSp == obj.IdChiTIetSp);
            hoaDonChiTiet.SoLuong = obj.SoLuong;
            hoaDonChiTiet.GiamGia = obj.GiamGia;
            hoaDonChiTiet.DonGia = obj.DonGia;
            if (_iHoaDonChiTietRepository.Update(hoaDonChiTiet)) return "sửa thành công";
            return "sửa thất bại";
        }

        public List<HoaDonChiTIetView> ShowHoadonChitiet(Guid id)
        {
            var data =
                (
                    from a in _iHoaDonChiTietRepository.GetAll()
                    join b in _iHoaDonRepository.GetAll() on a.IdhoaDon equals b.Id
                    join c in _iQlSanphamService.GetAll() on a.IdChiTIetSp equals c.Id
                    where a.IdhoaDon == id||a.IdChiTIetSp==id
                    
                    select new HoaDonChiTIetView()
                    {
                        IdChiTIetSp = c.Id,
                        MaSp = c.Ma,
                        TenSp = c.TenSp,
                        SoLuong = a.SoLuong.Value,
                        DonGia = a.DonGia.Value,
                    }
                ).ToList();
            return data;
        }

        public string Delete(HoaDonChiTIetView obj)
        {
            if (obj == null) return "xóa thất bại";
            var hoaDonChiTiet = _iHoaDonChiTietRepository.GetAll().FirstOrDefault(c => c.IdhoaDon == obj.IdhoaDon && c.IdChiTIetSp == obj.IdChiTIetSp);
            if (_iHoaDonChiTietRepository.Delete(hoaDonChiTiet)) return "xóa thành công";
            return "xóa thất bại";
        }

        public List<HoaDonChiTIetView> ShowHoadonChitiet()
        {
            var data =
                (
                    from a in _iHoaDonChiTietRepository.GetAll()
                    join b in _iHoaDonRepository.GetAll() on a.IdhoaDon equals b.Id
                    join c in _iQlSanphamService.GetAll() on a.IdChiTIetSp equals c.Id
                    
                    select new HoaDonChiTIetView()
                    {
                        IdChiTIetSp = c.Id,
                        MaSp = c.Ma,
                        TenSp = c.TenSp,
                        SoLuong = a.SoLuong.Value,
                        DonGia = a.DonGia.Value,
                        Tong= a.SoLuong.Value* a.DonGia.Value-a.GiamGia.Value,
                        IdhoaDon=b.Id,
                        sdt=b.Sdt,
                        GiamGia=a.GiamGia.Value,
                        ThanhTien = a.SoLuong.Value * a.DonGia.Value - a.GiamGia.Value
                    }
                ).ToList();
            return data;
        }
    }
}
