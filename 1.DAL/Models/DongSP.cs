using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class DongSP
    {
        public Guid Id { get; set; }
        
        public string Ma { get; set; }
        
        public string Ten { get; set; }
        [Required]
        [StringLength(100)]
        public int? TrangThai { get; set; }
    }
}
