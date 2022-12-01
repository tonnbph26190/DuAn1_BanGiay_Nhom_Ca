using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModel
{
    public class GioHangChiTIetView
    {
        public Guid ID { get; set; }
        public Guid IdChiTietSp { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal DonGiaKhiGiam { get; set; }
        public Guid IdGioHang { get; set; }
    }
}
