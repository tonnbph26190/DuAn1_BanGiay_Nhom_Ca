using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IChiTIetSpRepositories
    {
        bool Add(ChiTietSp obj);
        bool Delete(ChiTietSp obj);
        bool Update(ChiTietSp obj);
        ChiTietSp GetByID(Guid id);
        List<ChiTietSp> GetAll();
    }
}
