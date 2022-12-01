using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModel
{
    public class SanPhamKhuyenMaiView
    {
        public Guid Id { get; set; }
        
        public int TrangThai { get; set; }
        public Guid IdKhuyenMai { get; set; }
        public Guid IdSanPham { get; set; }
        
    }
}
