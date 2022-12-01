using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class Anh
    {
        public Guid? Id { get; set; }
        [StringLength(50)]
        public string? Ma { get; set; }
        [StringLength(50)]
        public string? Ten { get; set; }
        [Required]
        [StringLength(100)]
        public string? DuongDan { get; set; }
        public int? TrangThai { get; set; }
    }
}
