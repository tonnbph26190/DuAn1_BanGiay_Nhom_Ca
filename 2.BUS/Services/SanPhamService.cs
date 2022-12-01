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
    public class SanPhamService : ISanPhamService
    {
        private ISanPhamReposistory _iSanPhamRepository;
        List<SanPhamView> _lstSanPham;
        public SanPhamService()
        {
            _iSanPhamRepository = new SanPhamReposistory();
            _lstSanPham = new List<SanPhamView>();

        }

        public string Add(SanPhamView obj)
        {
            if (obj == null) return "thêm thất bại";
            var sanPham = new SanPham()
            {
                Id=Guid.NewGuid(),
                Ma = obj.Ma,
                Ten = obj.Ten,
            };
            if (_iSanPhamRepository.Add(sanPham)) return "thêm thành công";
            return "thêm thất bại";
        }

        public string Delete(SanPhamView obj)
        {

            if (obj == null) return "sửa thất bại";
            var sanPham = _iSanPhamRepository.GetAll().FirstOrDefault(c => c.Id == obj.Id);
            sanPham.Ten = obj.Ten;
            if (_iSanPhamRepository.Update(sanPham)) return "sửa thành công";
            return "sửa thất bại";
        }

        public List<SanPhamView> GetAll()
        {
            List<SanPhamView> lst = new List<SanPhamView>();
            lst =
                (
                    from a in _iSanPhamRepository.GetAll()
                    select new SanPhamView()
                    {
                        Id=a.Id,
                        Ma = a.Ma,
                        Ten = a.Ten,
                        TrangThai = a.TrangThai
                    }
                ).ToList();
            return lst;
        }

        public List<SanPhamView> GetAll(string input)
        {
            throw new NotImplementedException();
        }

        public SanPham GetById(Guid id)
        {
            return _iSanPhamRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdByName(string input)
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Id;
        }

        public string GetMaByName(string input)
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Ma;
        }

        public string Update(SanPhamView obj)
        {
            if (obj == null) return "sửa thất bại";
            var sanPham = _iSanPhamRepository.GetAll().FirstOrDefault(c => c.Id == obj.Id);
            sanPham.Ten = obj.Ten;
            sanPham.Ma = obj.Ma;
            sanPham.TrangThai = obj.TrangThai;
            if (_iSanPhamRepository.Update(sanPham)) return "sửa thành công";
            return "sửa thất bại";
        }
    }
}
