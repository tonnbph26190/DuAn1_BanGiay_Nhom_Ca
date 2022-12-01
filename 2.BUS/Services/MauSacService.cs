using _1.DAL.IRepositories;
using _1.DAL.Models;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class MauSacService: IMauSacService
    {
        private IMauSacRepositories _iMauSacRepository;
        public MauSacService()
        {
            _iMauSacRepository = new MauSacRepositories();
        }

        public string Add(MauSacView obj)
        {
            if (obj == null) return "thêm thất bại";
            var mauSac = new MauSac()
            {
                Ma = obj.Ma,
                Ten = obj.Ten,
                TrangThai = obj.TrangThai
            };
            if (_iMauSacRepository.Add(mauSac)) return "thêm thành công";
            return "thêm thất bại";
        }

        public string Update(MauSacView obj)
        {
            if (obj == null) return "sửa thất bại";
            var mauSac = _iMauSacRepository.GetAll().FirstOrDefault(c => c.Ma == obj.Ma);
            mauSac.Ten = obj.Ten;
            mauSac.Ma = obj.Ma;
            mauSac.TrangThai = obj.TrangThai;
            if (_iMauSacRepository.Update(mauSac)) return "sửa thành công";
            return "sửa thất bại";
        }

        public string Delete(MauSacView obj)
        {
            if (obj == null) return "xóa thất bại";
            var mauSac = _iMauSacRepository.GetAll().FirstOrDefault(c => c.Ma == obj.Ma);
            if (_iMauSacRepository.Delete(mauSac)) return "xóa thành công";
            return "xóa thất bại";
        }

        public List<MauSacView> GetAll()
        {
            List<MauSacView> lst = new List<MauSacView>();
            lst =
                (
                    from a in _iMauSacRepository.GetAll()
                    select new MauSacView()
                    {
                        Id = a.Id,
                        Ma = a.Ma,
                        Ten = a.Ten,
                        TrangThai = a.TrangThai,
                    }
                ).ToList();
            return lst;
        }

        public MauSac GetById(Guid id)
        {
            return _iMauSacRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }
        public Guid GetIdFromTen(string ten)
        {
            return (Guid)GetAll().FirstOrDefault(c => c.Ten == ten).Id;
        }
    }
}
