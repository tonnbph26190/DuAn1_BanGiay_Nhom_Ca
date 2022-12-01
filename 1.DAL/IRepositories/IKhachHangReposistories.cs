using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IKhachHangReposistories
    {
        bool Add(KhachHang obj);
        bool Update(KhachHang obj);
        KhachHang GetByID(Guid id);
        List<KhachHang> GetAll();
    }
}
