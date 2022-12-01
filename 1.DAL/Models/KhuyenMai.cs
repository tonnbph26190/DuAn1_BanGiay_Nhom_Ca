using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class KhuyenMai
    {
        public Guid? Id { get; set; }
        [StringLength(50)]
        public string? Ma { get; set; }
        [StringLength(50)]
        public string? Ten { get; set; }
        [Required]
        [StringLength(100)]
        public string? LoaiGiamGia { get; set; }
        [StringLength(100)]
        public decimal? MucGiamGia { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? TrangThai { get; set; }
        
    }
}
