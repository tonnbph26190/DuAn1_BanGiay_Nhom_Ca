using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModel
{
    public class KhuyenMaiView
    {
        public Guid Id { get; set; }
        
        public string Ma { get; set; }
       
        public string Ten { get; set; }
        
        public string LoaiGiamGia { get; set; }
        
        public decimal MucGiamGia { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TrangThai { get; set; }
    }
}
