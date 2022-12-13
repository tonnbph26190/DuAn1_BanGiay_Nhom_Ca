using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
   public interface IDongSPService
    {
        bool Add(DongSP dsp);
        string Update(DongSP obj);
        DongSP GetById(Guid id);
        Guid GetIdByName(string input);
        List<DongSP> GetAll();
    }
}
