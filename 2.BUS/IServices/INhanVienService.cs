using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface INhanVienService
    {
        string Add(NhanVienView obj);
        string Update(NhanVienView obj);
        string Delete(NhanVienView obj);
        List<NhanVienView>? GetAll(string? input);

        List<NhanVienView>? GetAll();
        List<NhanVienView>? GetAllQuanLi();
        string? GetNameByID(Guid? guid);


    }
}
