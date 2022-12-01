using _1.DAL.Models;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IChucVuService
    {
        bool Add(ChucVu cv);
        bool Update(ChucVu cv);

        List<ChucVu> GetAll();

        string GetNameByID(Guid? input);
        Guid GetIDByMa(string input);
        ChucVu GetById(Guid id);
    }
}
