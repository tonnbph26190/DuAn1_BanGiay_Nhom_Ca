using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class HoaDonChiTiet
    {
        public Guid Id { get; set; }
       
       
       
        public double? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public double? GiamGia { get; set; }
        public double? ThanhTien { get; set; }       
        public Guid? IdhoaDon { get; set; }
        public int? TrangThai { get; set; }      
        public Guid? IdChiTIetSp { get; set; }
       
        public string GhiChu { get; set; }
        public virtual ChiTietSp? ChiTietSp { get; set; }
        public virtual HoaDon? HoaDon { get; set; }
    }
}
