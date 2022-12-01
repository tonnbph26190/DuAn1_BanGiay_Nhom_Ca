using _1.DAL.Models;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IMauSacService
    {
        string Add(MauSacView obj);
        string Update(MauSacView obj);
        string Delete(MauSacView obj);
        List<MauSacView> GetAll();
        MauSac GetById(Guid id);
        Guid GetIdFromTen(string ten);
    }
}
