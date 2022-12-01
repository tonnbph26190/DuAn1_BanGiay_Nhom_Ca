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
    public class NsxService: INsxService
    {
        private INsxRepositories _iMauSacRepository;
        public NsxService()
        {
            _iMauSacRepository = new NsxRepositories();
        }

        public string Add(ViewModel.NsxView obj)
        {
            if (obj == null) return "thêm thất bại";
            var mauSac = new NSX()
            {
                Ma = obj.Ma,
                Ten = obj.Ten,
                TrangThai = obj.TrangThai
            };
            if (_iMauSacRepository.Add(mauSac)) return "thêm thành công";
            return "thêm thất bại";
        }

        public string Delete(ViewModel.NsxView obj)
        {
            throw new NotImplementedException();
        }

        public List<ViewModel.NsxView> GetAll()
        {
            List<ViewModel.NsxView> lst = new List<ViewModel.NsxView>();
            lst =
                (
                    from a in _iMauSacRepository.GetAll()
                    select new ViewModel.NsxView()
                    {
                        Id = a.Id,
                        Ma = a.Ma,
                        Ten = a.Ten,
                        TrangThai = a.TrangThai,
                    }
                ).ToList();
            return lst;
        }

        public NSX GetById(Guid id)
        {
            return _iMauSacRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdFromTen(string ten)
        {
            return (Guid)GetAll().FirstOrDefault(c => c.Ten == ten).Id;
        }

        public string Update(ViewModel.NsxView obj)
        {
            if (obj == null) return "sửa thất bại";
            var mauSac = _iMauSacRepository.GetAll().FirstOrDefault(c => c.Ma == obj.Ma);
            mauSac.Ten = obj.Ten;
            mauSac.Ma = obj.Ma;
            mauSac.TrangThai = obj.TrangThai;
            if (_iMauSacRepository.Update(mauSac)) return "sửa thành công";
            return "sửa thất bại";
        }
    }
}
