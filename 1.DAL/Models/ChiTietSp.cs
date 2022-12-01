using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class ChiTietSp
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public int SoLuong { get; set; }
        
        public string Mavach { get; set; }
        public string Anh { get; set; }
        public string Ma { get; set; }
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

        public virtual ChatLieu? ChatLieu { get; set; }
        public virtual SanPham? SanPham { get; set; }
        public virtual DongSP? DongSp { get; set; }
        public virtual NSX? NSX { get; set; }
        public virtual MauSac? MauSac { get; set; }
        public virtual Size? Size { get; set; }


    }
}
