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
    public class NsxRepositories: INsxRepositories
    {
        private BanGiayDBContext _dbContext;
        public NsxRepositories()
        {
            _dbContext = new BanGiayDBContext();
        }
        public bool Add(NSX obj)
        {
            if (obj == null) return false;
            _dbContext.NSXes.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(NSX obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.NSXes.FirstOrDefault(c => c.Id == obj.Id);
            _dbContext.Remove(tempObj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<NSX> GetAll()
        {
            return _dbContext.NSXes.ToList();
        }

        public NSX GetById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dbContext.NSXes.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(NSX obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.NSXes.FirstOrDefault(c => c.Id == obj.Id);
            tempObj.Ten = obj.Ten;
            tempObj.Ma = obj.Ma;
            tempObj.TrangThai = obj.TrangThai;
            _dbContext.Update(tempObj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}

