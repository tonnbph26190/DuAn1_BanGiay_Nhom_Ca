using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class GioHangChiTiet
    {
        public Guid? ID { get; set; }
        public Guid? IdChiTietSp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? DonGiaKhiGiam { get; set; }
        public Guid? IdGioHang { get; set; }
        public virtual ChiTietSp? ChiTietSp{ get; set; }
        public virtual GioHang? GioHang { get; set; }
    }
}
