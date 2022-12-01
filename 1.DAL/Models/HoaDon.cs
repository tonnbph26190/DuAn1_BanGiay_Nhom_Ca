using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string MaHoaDon { get; set; }
       
        public DateTime NgayLap { get; set; }
        
        public DateTime NgayNhanHang { get; set; }
        public DateTime NgayThanhToan { get; set; }
            
       
        public Guid IdNhanVien { get; set; }
        public Guid IdKhachHang { get; set; }
        public int TrangThai { get; set; }        
        public DateTime NgayShipHang { get; set; }
        public string NguoiBan { get; set; }
        public string Sdt { get; set; }
        public virtual KhachHang? KhachHang { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
    }
}
