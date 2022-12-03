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
    public class KhachHangService: IKhachHangService
    {
        private IKhachHangReposistories _iKhachHangRepositories;
        public KhachHangService()
        {
            _iKhachHangRepositories = new KhachHangReposistories();
        }

        public string? Add(KhachHangView obj)
        {
            if (obj == null) return "thêm thất bại";
            var khachHang = new KhachHang()
            {
                Ma = obj.Ma,
                Ten = obj.Ten,
                Email = obj.Email,
                DiaChi = obj.DiaChi,
                ThangPho = obj.ThangPho,
                QuocGia = obj.QuocGia,
                SoDienThoai = obj.SoDienThoai,
                TrangThai = obj.TrangThai,
                diemTieuDung = obj.diemTieuDung,

            };
            if (_iKhachHangRepositories.Add(khachHang)) return "thêm thành công";
            return "thêm thất bại";
        }

        public string? Update(KhachHangView obj)
        {
            if (obj == null) return "sửa thất bại";
            var khachHang = _iKhachHangRepositories.GetAll().FirstOrDefault(c => c.Ma == obj.Ma);
            khachHang.Ten = obj.Ten;
            khachHang.Ma = obj.Ma;
            khachHang.Email = obj.Email;
            khachHang.DiaChi = obj.DiaChi;
            khachHang.ThangPho = obj.ThangPho;
            khachHang.SoDienThoai = obj.SoDienThoai;
            khachHang.TrangThai = obj.TrangThai;
            khachHang.diemTieuDung = obj.diemTieuDung;
            if (_iKhachHangRepositories.Update(khachHang)) return "sửa thành công";
            return "sửa thất bại";
        }

        

        public List<KhachHangView>? GetAll()
        {
            List<KhachHangView> lst = new List<KhachHangView>();
            lst =
                (
                    from a in _iKhachHangRepositories.GetAll()
                    select new KhachHangView()
                    {
                        Id = a.Id,
                        Ma = a.Ma,
                        Ten = a.Ten,
                        Email = a.Email,
                        DiaChi = a.DiaChi,
                        ThangPho = a.ThangPho,
                        QuocGia= a.QuocGia,
                        SoDienThoai = a.SoDienThoai,
                        TrangThai = a.TrangThai,
                        diemTieuDung = a.diemTieuDung
                    }
                ).ToList();
            return lst;
        }

        public KhachHang? GetById(Guid? id)
        {
            return _iKhachHangRepositories.GetAll().FirstOrDefault(c => c.Id == id);
        }
        public Guid? GetIdFromTen(string? ten)
        {
            return (Guid)GetAll().FirstOrDefault(c => c.Ten == ten).Id;
        }

        public List<string>? GetAllTP()
        {
            return new List<string>() { "Hà Nội", "Thanh Hóa", "Nghệ An", "Hà Tĩnh", "Huế", "Quảng Trị" };
        }

        public List<string>? GetAllQG()
        {
            return new List<string>() { "Việt Nam", "Thái Lan", "Ấn Độ" };
        }
    }
}
