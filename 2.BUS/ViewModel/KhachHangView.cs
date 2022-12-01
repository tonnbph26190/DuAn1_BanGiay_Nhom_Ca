using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModel
{
    public class KhachHangView
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(100)]
        public string DiaChi { get; set; }
        [StringLength(50)]
        public string ThangPho { get; set; }
        [StringLength(50)]
        public string QuocGia { get; set; }
        [StringLength(50)]
        public string SoDienThoai { get; set; }
        public int TrangThai { get; set; }

        public double diemTieuDung { get; set; }
    }
}
