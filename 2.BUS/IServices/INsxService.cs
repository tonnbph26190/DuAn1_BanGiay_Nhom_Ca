using _1.DAL.Models;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface INsxService
    {
        string Add(NsxView obj);
        string Update(NsxView obj);
        string Delete(NsxView obj);
        List<NsxView> GetAll();
        NSX GetById(Guid id);
        Guid GetIdFromTen(string ten);
    }
}
