using _1.DAL.Models;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface ISanPhamService
    {
        string Add(SanPhamView obj);
        string Update(SanPhamView obj);
        string Delete(SanPhamView obj);
        List<SanPhamView> GetAll();
        List<SanPhamView> GetAll(string input);
        SanPham GetById(Guid id);
        Guid GetIdByName(string input);
        string GetMaByName(string input);

    }
}
