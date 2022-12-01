using _1.DAL.Context;
using _1.DAL.IRepositories;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class HoaDonRepository: IHoaDonRepository
    {
        private BanGiayDBContext _dbContext;
        public HoaDonRepository()
        {
            _dbContext = new BanGiayDBContext();
        }
        public bool Add(HoaDon obj)
        {
            if (obj == null) return false;
            obj.Id=Guid.NewGuid();
            _dbContext.HoaDons.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(HoaDon obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.HoaDons.FirstOrDefault(c => c.Id == obj.Id);
            _dbContext.Remove(tempObj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<HoaDon> GetAll()
        {
            return _dbContext.HoaDons.ToList();
        }

        public HoaDon GetById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dbContext.HoaDons.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(HoaDon obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.HoaDons.FirstOrDefault(c => c.Id == obj.Id);
            tempObj.IdKhachHang = obj.IdKhachHang;
            tempObj.IdNhanVien = obj.IdNhanVien;
            tempObj.NgayLap = obj.NgayLap;
            tempObj.NgayThanhToan = obj.NgayThanhToan;
            tempObj.NgayNhanHang = obj.NgayNhanHang;
            tempObj.NgayShipHang = obj.NgayShipHang;
            tempObj.MaHoaDon = obj.MaHoaDon;
            tempObj.NguoiBan = obj.NguoiBan;
            tempObj.Sdt = obj.Sdt;
            tempObj.TrangThai = obj.TrangThai;
            _dbContext.Update(tempObj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
