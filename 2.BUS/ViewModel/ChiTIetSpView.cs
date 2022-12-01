using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModel
{
    public class ChiTIetSpView
    {
        public Guid Id { get; set; }
        
        public  string Ma { get; set; }
        public int SoLuong { get; set; }
        public string Mavach { get; set; }
        public string anh { get; set; }
        public string TenChatLieu { get; set; }
        public string LoaiSize { get; set; }
        public string TenDongSp { get; set; }
        public string TenMauSac { get; set; }
        public string TenNsx { get; set; }
        public string TenSp{ get; set; }
        
        public double DonGiaNhap { get; set; }
        public double DonGiaBan { get; set; }
        public int TrangThai { get; set; }
        public string MoTa { get; set; }

        public Guid IdchatLieu { get; set; }

        public Guid IdNsx { get; set; }

        public Guid IdDongSP { get; set; }

        public Guid IdMauSac { get; set; }

        public Guid IdSp { get; set; }
        public Guid IdSize { get; set; }
    }
}
