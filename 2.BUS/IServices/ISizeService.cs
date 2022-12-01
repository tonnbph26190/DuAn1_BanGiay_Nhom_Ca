using _1.DAL.Models;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface ISizeService
    {
        string Add(SizeView obj);
        string Update(SizeView obj);
        string Delete(SizeView obj);
        List<SizeView> GetAll();
        Size GetById(Guid id);
        Guid GetIdFromTen(string ten);
    }
}
