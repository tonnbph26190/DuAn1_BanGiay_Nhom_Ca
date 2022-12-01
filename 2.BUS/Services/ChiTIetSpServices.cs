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
    public class ChiTIetSpServices: IChiTietSpServices
    {
        private IChiTIetSpRepositories _iChiTietSpRepository;
        private ISanPhamReposistory _iSanPhamRepository;
        private IDongSpRepositories _iDongSpRepository;
        private INsxRepositories _iNsxRepository;
        private IMauSacRepositories _iMauSacRepository;
        private ISizeRepositories _iSizeRepository;
        private IChatLieuRepositories _iChatLieuRepository;
        public ChiTIetSpServices()
        {
            _iChiTietSpRepository = new ChiTIetSpRepositories();
            _iSanPhamRepository = new SanPhamReposistory();
            _iDongSpRepository = new DongSpRepositories();
            _iNsxRepository = new NsxRepositories();
            _iMauSacRepository = new MauSacRepositories();
            _iSizeRepository = new SizeRepositories();
            _iChatLieuRepository= new ChatLieuRepositories();
        }
        public string ADD(ChiTIetSpView obj)
        {
            if (obj == null) return "thêm thất bại";
            var chiTietSp = new ChiTietSp()
            {
                Id = Guid.Empty,
                IdSp = obj.IdSp,
                IdDongSP = obj.IdDongSP,
                IdNsx = obj.IdNsx,
                IdMauSac = obj.IdMauSac,
                IdchatLieu=obj.IdchatLieu,
                IdSize=obj.IdSize,               
                DonGiaNhap = obj.DonGiaNhap,
                DonGiaBan = obj.DonGiaBan,
                SoLuong = obj.SoLuong,
                MoTa = obj.MoTa,
                Anh=obj.anh,
                Mavach=obj.Mavach,
                TrangThai= obj.TrangThai,
                Ma=obj.Ma,


            };
            if (_iChiTietSpRepository.Add(chiTietSp)) return "thêm thành công";
            return "thêm thất bại";
        }

        public string UPDATE(ChiTIetSpView obj)
        {
            if (obj == null) return "sửa thất bại";
            var chiTietSp = _iChiTietSpRepository.GetAll().FirstOrDefault(c => c.Id == obj.Id);
            chiTietSp.IdSp = obj.IdSp;
            chiTietSp.IdDongSP = obj.IdDongSP;
            chiTietSp.IdMauSac = obj.IdMauSac;
            chiTietSp.IdNsx = obj.IdNsx;           
            chiTietSp.IdSize = obj.IdSize;           
            chiTietSp.IdchatLieu = obj.IdchatLieu;           
            chiTietSp.DonGiaNhap = obj.DonGiaNhap;
            chiTietSp.DonGiaBan = obj.DonGiaBan;
            chiTietSp.SoLuong = obj.SoLuong;
            chiTietSp.MoTa = obj.MoTa;
            chiTietSp.TrangThai = obj.TrangThai;
            chiTietSp.Ma=obj.Ma;
            if (_iChiTietSpRepository.Update(chiTietSp)) return "sửa thành công";
            return "sửa thất bại";
        }

        public string DELETE(ChiTIetSpView obj)
        {
            if (obj == null) return "xóa thất bại";
            var chiTietSp = _iChiTietSpRepository.GetAll().FirstOrDefault(c => c.Id == obj.Id);
            if (_iChiTietSpRepository.Delete(chiTietSp)) return "xóa thành công";
            return "xóa thất bại";
        }

        public List<ChiTIetSpView> GetAll()
        {
            List<ChiTIetSpView> lstSPViews = new List<ChiTIetSpView>();
            lstSPViews =
                (
                    from a in _iChiTietSpRepository.GetAll()
                    join b in _iMauSacRepository.GetAll() on a.IdMauSac equals b.Id
                    join c in _iDongSpRepository.GetAll() on a.IdDongSP equals c.Id
                    join d in _iNsxRepository.GetAll() on a.IdNsx equals d.Id
                    join e in _iSanPhamRepository.GetAll() on a.IdSp equals e.Id
                    join r in _iChatLieuRepository.GetAll() on a.IdchatLieu equals r.Id
                    join t in _iSizeRepository.GetAll() on a.IdSize equals t.Id
                    select new ChiTIetSpView()
                    {
                        Id = a.Id,
                        IdSp = e.Id,
                        IdMauSac = b.Id,
                        IdDongSP = c.Id,
                        IdchatLieu=r.Id,
                        IdSize=t.Id,
                        IdNsx = d.Id,
                        Ma = e.Ma,                    
                        SoLuong = a.SoLuong,
                        DonGiaNhap = a.DonGiaNhap,
                        DonGiaBan = a.DonGiaBan,                      
                        MoTa = a.MoTa,  
                        anh=a.Anh,
                        Mavach=a.Mavach,
                        TrangThai= a.TrangThai,
                        TenChatLieu=r.Ten,
                        LoaiSize=t.SizeGiay,
                        TenDongSp=c.Ten,
                        TenMauSac=b.Ten,
                        TenNsx=d.Ten,
                        TenSp=e.Ten,
                    }
                ).ToList();
            return lstSPViews;
        }

        public ChiTietSp GETMASP(string input)
        {
            return _iChiTietSpRepository.GetAll().FirstOrDefault(c => c.Ma == input);
        }

        public string GETNAME(string input)
        {
            return GetAll().FirstOrDefault(c=>c.Ma == input).TenSp;
        }
    }
}
