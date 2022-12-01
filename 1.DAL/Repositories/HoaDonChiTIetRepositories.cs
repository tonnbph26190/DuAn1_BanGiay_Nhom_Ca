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
    public class HoaDonChiTIetRepositories: IHoaDonChiTIetRepositories
    {
        private BanGiayDBContext _dbContext;
        public HoaDonChiTIetRepositories()
        {
            _dbContext= new BanGiayDBContext();
        }
        public bool Add(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            obj.Id= Guid.NewGuid(); 
            _dbContext.HoaDonChiTiets.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.HoaDonChiTiets.FirstOrDefault(c => c.IdhoaDon == obj.IdhoaDon);
            _dbContext.Remove(tempObj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<HoaDonChiTiet> GetAll()
        {
            return _dbContext.HoaDonChiTiets.ToList();
        }

        public HoaDonChiTiet GetByID(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dbContext.HoaDonChiTiets.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.HoaDonChiTiets.FirstOrDefault(c => c.IdhoaDon == obj.IdhoaDon);
            tempObj.IdChiTIetSp = obj.IdChiTIetSp;
            tempObj.SoLuong = obj.SoLuong;
            tempObj.DonGia = obj.DonGia;
            tempObj.ThanhTien = obj.ThanhTien;
            tempObj.GiamGia = obj.GiamGia;
            tempObj.TrangThai= obj.TrangThai;
            _dbContext.Update(tempObj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
