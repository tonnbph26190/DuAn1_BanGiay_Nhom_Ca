using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModel
{
    public class HoaDonChiTIetView
    {
        public Guid Id { get; set; }

        public string MaSp { get; set; }
        public string TenSp { get; set; }

        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double GiamGia { get; set; }
        public double ThanhTien { get; set; }
        public Guid IdhoaDon { get; set; }
        public int TrangThai { get; set; }
        public Guid IdChiTIetSp { get; set; }
        public double Tong { get; set; }
        public string GhiChu { get; set; }
    }
}
