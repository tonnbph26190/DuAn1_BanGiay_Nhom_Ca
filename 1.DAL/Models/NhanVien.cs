using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class NhanVien
    {
      
        public Guid Id { get; set; }
        [StringLength(50)]
        public string MaNhanVien { get; set; }
        [StringLength(50)]
        public string TenNhanVien { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NamSinh { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string PassWord { get; set; }
        [StringLength(100)]
        public string QueQuan { get; set; }
        
        [StringLength(50)]
        public string SoCmnd { get; set; }
        [StringLength(50)]
        public string DienThoai { get; set; }
        public int TrangThai { get; set; }
        [StringLength(100)]
        public string Anh { get; set; }
        
        public Guid IdChucVu { get; set; }
        
        public virtual ChucVu ChucVu { get; set; }
        

        

    }
}
