using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class SanPhamKhuyenMai
    {
        public Guid? Id { get; set; }
        [StringLength(50)]
        public int? TrangThai { get; set; }
        public Guid? IdKhuyenMai { get; set; }
        public Guid? IdSanPham { get; set; }
        public virtual KhuyenMai? KhuyenMai { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
