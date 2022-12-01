using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface INsxRepositories
    {
        bool Add(NSX obj);
        bool Update(NSX obj);
        bool Delete(NSX obj);
        List<NSX> GetAll();
        NSX GetById(Guid id);
    }
}
