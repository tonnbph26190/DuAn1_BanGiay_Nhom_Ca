using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IHoaDonService
    {
        string Add(HoaDonView obj);
        string Update(HoaDonView obj);
        string Delete(HoaDonView obj);
        List<string> TrangThai();
        List<HoaDonView> ShowHoadon();
        List<HoaDonView> ShowHoadon(string input);
       
        string? GetMabyID(Guid? id);
        Guid GetID(string? id);
        
    }
}
