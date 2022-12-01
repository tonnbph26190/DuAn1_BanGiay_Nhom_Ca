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
    public class SizeService: ISizeService
    {
        private ISizeRepositories _iSizeRepository;
        public SizeService()
        {
            _iSizeRepository = new SizeRepositories();
        }

        public string Add(SizeView obj)
        {
            if (obj == null) return "thêm thất bại";
            var size = new Size()
            {
                Ma = obj.Ma,
                SizeGiay = obj.SizeGiay,
                TrangThai = obj.TrangThai,
            };
            if (_iSizeRepository.Add(size)) return "thêm thành công";
            return "thêm thất bại";
        }

        public string Update(SizeView obj)
        {
            if (obj == null) return "sửa thất bại";
            var size = _iSizeRepository.GetAll().FirstOrDefault(c => c.Id == obj.Id);
            size.SizeGiay = obj.SizeGiay;
            size.Ma=obj.Ma;
            size.TrangThai= obj.TrangThai;
            if (_iSizeRepository.Update(size)) return "sửa thành công";
            return "sửa thất bại";
        }

        public string Delete(SizeView obj)
        {
            if (obj == null) return "xóa thất bại";
            var size = _iSizeRepository.GetAll().FirstOrDefault(c => c.Ma == obj.Ma);
            if (_iSizeRepository.Delete(size)) return "xóa thành công";
            return "xóa thất bại";
        }

        public List<SizeView> GetAll()
        {
            List<SizeView> lst = new List<SizeView>();
            lst =
                (
                    from a in _iSizeRepository.GetAll()
                    select new SizeView()
                    {
                        Id = a.Id,
                        Ma = a.Ma,
                        SizeGiay = a.SizeGiay,
                        TrangThai = a.TrangThai,
                    }
                ).ToList();
            return lst;
        }

        public Size GetById(Guid id)
        {
            return _iSizeRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }
        public Guid GetIdFromTen(string sizegiay)
        {
            return (Guid)GetAll().FirstOrDefault(c => c.SizeGiay == sizegiay).Id;
        }
    }
}
