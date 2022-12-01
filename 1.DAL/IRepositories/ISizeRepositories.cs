using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface ISizeRepositories
    {
        bool Add(Size obj);
        bool Update(Size obj);
        bool Delete(Size obj);
        List<Size> GetAll();
        Size GetById(Guid id);
    }
}
