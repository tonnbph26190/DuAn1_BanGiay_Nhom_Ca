using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModel
{
    public class NhanVienView
    {
        public NhanVien NhanVien { get; set; }
        public ChucVu ChucVu { get; set; }
        public Guid Id { get; set; }
        
        public string MaNhanVien { get; set; }
       
        public string TenNhanVien { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NamSinh { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }          
        public string QueQuan { get; set; }

        public string SoCmnd { get; set; }
        public string DienThoai { get; set; }
        public int TrangThai { get; set; }
        public string Anh { get; set; }

        public Guid IdChucVu { get; set; }
        public Guid? IdBc { get; set; }
    }
}
