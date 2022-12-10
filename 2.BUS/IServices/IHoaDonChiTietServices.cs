﻿using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IHoaDonChiTietServices
    {
        string Add(HoaDonChiTIetView obj);
        string Update(HoaDonChiTIetView obj);
        string Delete(HoaDonChiTIetView obj);
        List<HoaDonChiTIetView> ShowHoadonChitiet(Guid id);
        List<HoaDonChiTIetView> ShowHoadonChitiet();
        List<HoaDonChiTIetView> GetAll();
    }
}
