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
   public class GioHangRepositories: IGioHangRepositories
    {
        private BanGiayDBContext _dbContext;
        public GioHangRepositories()
        {
            _dbContext= new BanGiayDBContext();
        }
        public bool Add(GioHang obj)
        {
            if (obj == null) return false;
            _dbContext.GioHangs.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(GioHang obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.GioHangs.FirstOrDefault(c => c.Id == obj.Id);
            _dbContext.Remove(tempObj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<GioHang> GetAll()
        {
            return _dbContext.GioHangs.ToList();
        }

        public GioHang GetByID(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dbContext.GioHangs.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(GioHang obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.GioHangs.FirstOrDefault(c => c.Id == obj.Id);
            tempObj.IdKH = obj.IdKH;
            tempObj.IdNV = obj.IdNV;
            tempObj.NgayTao = obj.NgayTao;
            tempObj.NgayThanhToan = obj.NgayThanhToan;
            tempObj.TenNguoiNhan = obj.TenNguoiNhan;       
            tempObj.Sdt = obj.Sdt;
            tempObj.TrangThai = obj.TrangThai;
            _dbContext.Update(tempObj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
