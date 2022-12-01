using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IGioHangRepositories
    {
        bool Add(GioHang obj);
        bool Delete(GioHang obj);
        bool Update(GioHang obj);
       GioHang GetByID(Guid id);
        List<GioHang> GetAll();
    }
}
