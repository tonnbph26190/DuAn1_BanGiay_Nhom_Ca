using _1.DAL.IRepositories;
using _1.DAL.Models;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class DongSPService: IDongSPService
    {
        private IDongSpRepositories _dongSpRepositories;
        private List<DongSP> _lstDongSp;

        public DongSPService()
        {
            _dongSpRepositories = new DongSpRepositories();
            _lstDongSp = new List<DongSP>();
        }
        public bool Add(DongSP dsp)
        {
            _dongSpRepositories.Add(dsp);
            return true;
        }

        public string Update(DongSP obj)
        {
            if (obj == null) return "sửa thất bại";
            var size = _dongSpRepositories.GetAll().FirstOrDefault(c => c.Id == obj.Id);
            size.Ten = obj.Ten;
            size.Ma = obj.Ma;
            size.TrangThai = obj.TrangThai;
            if (_dongSpRepositories.Update(size)) return "sửa thành công";
            return "sửa thất bại";
        }

        public List<DongSP> GetAll()
        {
            _lstDongSp = _dongSpRepositories.GetAll();
            return _lstDongSp;
        }

        public DongSP GetById(Guid id)
        {
            return _dongSpRepositories.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdByName(string input)
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Id;
        }
    }
}
