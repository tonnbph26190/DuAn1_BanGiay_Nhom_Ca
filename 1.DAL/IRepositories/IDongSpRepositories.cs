using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IDongSpRepositories
    {
        bool Add(DongSP obj);
        bool Update(DongSP obj);
        DongSP GetByID(Guid id);
        List<DongSP> GetAll();
    }
}
