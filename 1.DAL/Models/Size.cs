using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    public class Size
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string SizeGiay { get; set; }
        [Required]
        [StringLength(100)]
        public int TrangThai { get; set; }
    }
}
