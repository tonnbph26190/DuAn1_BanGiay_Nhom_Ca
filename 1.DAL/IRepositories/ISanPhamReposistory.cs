using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface ISanPhamReposistory
    {
        bool Add(SanPham obj);
        bool Delete(SanPham obj);
        bool Update(SanPham obj);
        SanPham GetByID(Guid id);
        List<SanPham> GetAll();
    }
}
