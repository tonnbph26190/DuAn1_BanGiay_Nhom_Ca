using _1.DAL.Context;
using _1.DAL.IRepositories;
using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
   public class ChiTIetSpRepositories : IChiTIetSpRepositories
    {
        private BanGiayDBContext _dBContext;
        public ChiTIetSpRepositories()
        {
            _dBContext = new BanGiayDBContext();
        }
        public bool Add(ChiTietSp obj)
        {
            if (obj == null) return false;
            
            _dBContext.ChiTietSps.Add(obj);
            _dBContext.SaveChanges();
            return true;
        }

        public bool Delete(ChiTietSp obj)
        {
            if (obj == null) return false;
            var temp = _dBContext.ChiTietSps.FirstOrDefault(c => c.Id == obj.Id);
            temp.TrangThai = obj.TrangThai;
            _dBContext.ChiTietSps.Update(temp);
            _dBContext.SaveChanges();
            return true;
        }

        public List<ChiTietSp> GetAll()
        {
            return _dBContext.ChiTietSps.ToList();
        }

        public ChiTietSp GetByID(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dBContext.ChiTietSps.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(ChiTietSp obj)
        {
            if (obj == null) return false;
            var temp = _dBContext.ChiTietSps.FirstOrDefault(c => c.Id == obj.Id);
            temp.TrangThai = obj.TrangThai;
            temp.Ma = obj.Ma;
            temp.SoLuong = obj.SoLuong;
            temp.Mavach = obj.Mavach;
            temp.MoTa = obj.MoTa;
            temp.DonGiaBan = obj.DonGiaBan;
            temp.DonGiaBan = obj.DonGiaBan;
            temp.IdMauSac = obj.IdMauSac;
            temp.IdMauSac = obj.IdMauSac;
            temp.IdDongSP = obj.IdDongSP;
            temp.IdSp = obj.IdSp;
            temp.IdchatLieu = obj.IdchatLieu;
            temp.IdSize = obj.IdSize;
            _dBContext.ChiTietSps.Update(temp);
            _dBContext.SaveChanges();
            return true;
        }
    }
}
