using _1.DAL.Context;
using _1.DAL.IRepositories;
using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class SizeRepositories: ISizeRepositories
    {
        private BanGiayDBContext _dbContext;
        public SizeRepositories()
        {
            _dbContext = new BanGiayDBContext();
        }
        public bool Add(Size obj)
        {
            if (obj == null) return false;
            _dbContext.Sizes.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Size obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.Sizes.FirstOrDefault(c => c.Id == obj.Id);
            _dbContext.Remove(tempObj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Size> GetAll()
        {
            return _dbContext.Sizes.ToList();
        }

        public Size GetById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dbContext.Sizes.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(Size obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.Sizes.FirstOrDefault(c => c.Id == obj.Id);
            tempObj.SizeGiay = obj.SizeGiay;
            tempObj.Ma = obj.Ma;
            tempObj.TrangThai = obj.TrangThai;
            _dbContext.Update(tempObj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
