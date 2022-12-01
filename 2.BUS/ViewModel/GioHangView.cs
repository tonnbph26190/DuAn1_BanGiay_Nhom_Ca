using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModel
{
    public class GioHangView
    {
        public Guid Id { get; set; }
        
        public string Ma { get; set; }
        
        public DateTime NgayTao { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public string TenNguoiNhan { get; set; }
        public string Sdt { get; set; }
        public int TrangThai { get; set; }
        public Guid IdNV { get; set; }
        public Guid IdKH { get; set; }
    }
}
