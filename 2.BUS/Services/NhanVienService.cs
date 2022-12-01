using _1.DAL.IRepositories;
using _1.DAL.Models;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class NhanVienService : INhanVienService
    {
        private INhanVienRepository _iNhanVienRepos;
        private IChucVuRepositories _iChucVuRepos;
        public NhanVienService()
        {
            _iNhanVienRepos = new NhanVienRepository();
            _iChucVuRepos = new ChucVuRepositories();
        }
        public string Add(NhanVienView obj)
        {
            if (obj == null) return "Thêm không thành công";
            var nv = new NhanVien()
            {
                MaNhanVien = obj.MaNhanVien,
                TenNhanVien = obj.TenNhanVien,
                GioiTinh = obj.GioiTinh,
                NamSinh = obj.NamSinh,
                Email = obj.Email,
                PassWord = obj.PassWord,
                QueQuan = obj.QueQuan,
                SoCmnd = obj.SoCmnd,
                DienThoai = obj.DienThoai,
                TrangThai = obj.TrangThai,
                Anh = obj.Anh,
                IdChucVu = obj.IdChucVu,
               
            };
            if (_iNhanVienRepos.Add(nv)) return "Thêm thành công òi nè";
            return "Thêm thất bại òi đó";
        }

        public string Delete(NhanVienView obj)
        {
            if (obj == null) return "Xóa không thành công òi";
            var nv = obj.NhanVien;
            //if (_iNhanVienRepos.Delete(nv)) return "Xóa thành công nè";
            _iNhanVienRepos.Delete(nv);
            return "Xóa thành công nè";
            // return "Xóa thất bại công đó";

        }

        public List<NhanVienView> GetAll(string input)
        {
            List<NhanVienView> lstNvView  =
                (from a in _iNhanVienRepos.GetAll()
                 join b in _iChucVuRepos.GetAll() on a.IdChucVu equals b.Id
                 select new NhanVienView()
                 {
                     IdChucVu = a.IdChucVu,
                    
                     MaNhanVien=a.MaNhanVien,
                     TenNhanVien = a.TenNhanVien,
                     GioiTinh=a.GioiTinh,
                     NamSinh=a.NamSinh,
                     Email=a.Email,
                     PassWord=a.PassWord,
                     QueQuan=a.QueQuan,
                     SoCmnd=a.SoCmnd,
                     DienThoai  =a.DienThoai,
                     TrangThai=a.TrangThai,
                     Anh=a.Anh,
                     NhanVien = a,
                     ChucVu = b,
                 }).ToList();
            if (string.IsNullOrEmpty(input))
            {
                return lstNvView;
            }
            return lstNvView.Where(c=>c.TenNhanVien.ToLower().Contains(input.ToLower()) ||c.Email.ToLower().Contains(input.ToLower()) || c.DienThoai.ToLower().Contains(input.ToLower()) ||c.SoCmnd.ToLower().Contains(input.ToLower())).ToList();
        }

        public List<NhanVienView> GetAll()
        {
            List<NhanVienView> lstNvView = new List<NhanVienView>();
            lstNvView =
                (from a in _iNhanVienRepos.GetAll()
                 join b in _iChucVuRepos.GetAll() on a.IdChucVu equals b.Id
                 select new NhanVienView()
                 {
                     Id = a.Id,// Hà Cá gán thiếu ID Nhân viên khi chả ra
                     IdChucVu = a.IdChucVu,
                     
                     MaNhanVien = a.MaNhanVien,
                     TenNhanVien = a.TenNhanVien,
                     GioiTinh = a.GioiTinh,
                     NamSinh = a.NamSinh,
                     Email = a.Email,
                     PassWord = a.PassWord,
                     QueQuan = a.QueQuan,
                     SoCmnd = a.SoCmnd,
                     DienThoai = a.DienThoai,
                     TrangThai = a.TrangThai,
                     Anh = a.Anh,
                     NhanVien = a,
                     ChucVu = b,
                 }).ToList();
            return lstNvView;
        }
        public string GetNameByID(Guid? guid)
        {

            return GetAll().Where(c => c.Id == guid).Select(c => c.MaNhanVien + "_" + c.TenNhanVien).FirstOrDefault();
        }
        public List<NhanVienView> GetAllQuanLi()
        {
            List<NhanVienView> lstNvViews = new List<NhanVienView>();
            lstNvViews =
                (
                    from a in _iNhanVienRepos.GetAll()
                    join b in _iChucVuRepos.GetAll() on a.IdChucVu equals b.Id
                    where b.Id == Guid.Parse("E5EE2A84-93CA-416A-8EE9-6FE7F9707A3B")
                    select new NhanVienView()
                    {
                        IdChucVu = a.IdChucVu,
                      
                        MaNhanVien = a.MaNhanVien,
                        TenNhanVien = a.TenNhanVien,
                        GioiTinh = a.GioiTinh,
                        NamSinh = a.NamSinh,
                        Email = a.Email,
                        PassWord = a.PassWord,
                        QueQuan = a.QueQuan,
                        SoCmnd = a.SoCmnd,
                        DienThoai = a.DienThoai,
                        TrangThai = a.TrangThai,
                        Anh = a.Anh,
                        NhanVien = a,
                        ChucVu = b,
                    }
                ).ToList();
            return lstNvViews;
        }


        public string Update(NhanVienView obj)
        {
            if (obj == null) return "Sửa không thành công òi";
            var nv = _iNhanVienRepos.GetAll().FirstOrDefault(c => c.MaNhanVien == obj.MaNhanVien);
            nv.TenNhanVien = obj.TenNhanVien;
            nv.IdChucVu = obj.IdChucVu;
            nv.MaNhanVien=obj.MaNhanVien;
            nv.Email = obj.Email;
            nv.PassWord = obj.PassWord;
            nv.Anh=obj.Anh;
            nv.QueQuan = obj.QueQuan;
            nv.TrangThai=obj.TrangThai;
            nv.GioiTinh=obj.GioiTinh;
            nv.SoCmnd= obj.SoCmnd;
            nv.DienThoai=obj.DienThoai;
            nv.NamSinh=obj.NamSinh;
            
            if (_iNhanVienRepos.Update(nv)) return "Sửa thành công nè";
            return "Sửa thất bại đó";
        }
    }



}
