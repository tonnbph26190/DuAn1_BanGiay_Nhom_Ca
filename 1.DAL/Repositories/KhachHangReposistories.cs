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
    public class KhachHangReposistories: IKhachHangReposistories
    {
        private BanGiayDBContext _dbContext;
        public KhachHangReposistories()
        {
            _dbContext= new BanGiayDBContext();
        }
        public bool Add(KhachHang obj)
        {
            if (obj == null) return false;
            _dbContext.KhachHangs.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

       

        public List<KhachHang> GetAll()
        {
            return _dbContext.KhachHangs.ToList();
        }

        public KhachHang GetByID(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dbContext.KhachHangs.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(KhachHang obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.KhachHangs.FirstOrDefault(c => c.Id == obj.Id);
            tempObj.Ten = obj.Ten;
            tempObj.Email = obj.Email;
            tempObj.SoDienThoai = obj.SoDienThoai;
            tempObj.DiaChi = obj.DiaChi;
            tempObj.ThangPho = obj.ThangPho;
            tempObj.QuocGia = obj.QuocGia;
            tempObj.TrangThai = obj.TrangThai;
            tempObj.diemTieuDung = obj.diemTieuDung;
            _dbContext.Update(tempObj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
