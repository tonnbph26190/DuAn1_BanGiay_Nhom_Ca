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
    public class NhanVienRepository : INhanVienRepository
    {
        BanGiayDBContext _DbContext;

        public NhanVienRepository()
        {
            _DbContext = new BanGiayDBContext();
        }
        public bool Add(NhanVien obj)
        {
            if (obj == null) return false;
            obj.Id=Guid.NewGuid();
            _DbContext.NhanViens.Add(obj);
            _DbContext.SaveChanges();
            return true;
            
        }

        public bool Delete(NhanVien obj)
        {
            if (obj == null) return false;
            var tempobj=_DbContext.NhanViens.FirstOrDefault(x => x.MaNhanVien == obj.MaNhanVien);
            _DbContext.Remove(tempobj);
            _DbContext.SaveChanges();
            return true;
        }

        public List<NhanVien> GetAll()
        {
            return _DbContext.NhanViens.ToList();
        }

        public bool Update(NhanVien obj)
        {
            if (obj == null) return false;
            var tempobj = _DbContext.NhanViens.FirstOrDefault(x => x.MaNhanVien == obj.MaNhanVien);
            tempobj.MaNhanVien=obj.MaNhanVien;
            tempobj.TenNhanVien=obj.TenNhanVien;
            tempobj.GioiTinh=obj.GioiTinh;
            tempobj.NamSinh=obj.NamSinh;
            tempobj.Email=obj.Email;
            tempobj.PassWord=obj.PassWord;
            tempobj.QueQuan=obj.QueQuan;
            tempobj.SoCmnd=obj.SoCmnd;
            tempobj.DienThoai=obj.DienThoai;
            tempobj.TrangThai=obj.TrangThai;
            tempobj.Anh=obj.Anh;
            tempobj.IdChucVu = obj.IdChucVu;
            
            _DbContext.Update(tempobj);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
