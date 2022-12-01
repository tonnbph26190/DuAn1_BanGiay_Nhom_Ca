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
    public class ChucVuService : IChucVuService
    {
        private IChucVuRepositories _chucVuRepositories;
        private List<ChucVu> _lstChucVus;

        public ChucVuService()
        {
            _chucVuRepositories = new ChucVuRepositories();
            _lstChucVus = new List<ChucVu>();
        }
        public bool Add(ChucVu obj)
        {
            _chucVuRepositories.Add(obj);
            return true;
        }

        public bool Update(ChucVu obj)
        {
            var temp = _chucVuRepositories.GetAll().FirstOrDefault(c => c.Id == obj.Id);
            _chucVuRepositories.Update(obj);
            return true;
        }

        public List<ChucVu> GetAll()
        {
            _lstChucVus = _chucVuRepositories.GetAll();
            return _lstChucVus;
        }

        public string GetNameByID(Guid? input)
        {
            return GetAll().FirstOrDefault(c => c.Id == input).Ten;
        }

        public Guid GetIDByMa(string input)
        {
            return GetAll().FirstOrDefault(c => string.Equals(input, c.Ma)).Id;
        }
        public ChucVu GetById(Guid id)
        {
            return _chucVuRepositories.GetAll().FirstOrDefault(c => c.Id == id);
        }
    }
}
