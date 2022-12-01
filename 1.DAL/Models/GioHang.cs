using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class GioHang
    {
        public Guid? Id { get; set; }
        [StringLength(50)]
        public string? Ma { get; set; }
        [StringLength(50)]
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string? TenNguoiNhan { get; set; }
        public string? Sdt { get; set; }
        public int? TrangThai { get; set; }
        public Guid? IdNV { get; set; }
        public Guid? IdKH { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public virtual KhachHang? KhachHang { get; set; }

    }
}
