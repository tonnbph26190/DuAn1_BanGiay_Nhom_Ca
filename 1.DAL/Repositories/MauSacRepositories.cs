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
    public class MauSacRepositories: IMauSacRepositories
    {
        private BanGiayDBContext _dbContext;
        public MauSacRepositories()
        {
            _dbContext = new BanGiayDBContext();
        }
        public bool Add(MauSac obj)
        {
            if (obj == null) return false;
            _dbContext.MauSacs.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(MauSac obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.MauSacs.FirstOrDefault(c => c.Id == obj.Id);
            _dbContext.Remove(tempObj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<MauSac> GetAll()
        {
            return _dbContext.MauSacs.ToList();
        }

        public MauSac GetById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dbContext.MauSacs.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(MauSac obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.MauSacs.FirstOrDefault(c => c.Id == obj.Id);
            tempObj.Ten = obj.Ten;
            tempObj.Ma = obj.Ma;
            tempObj.TrangThai = obj.TrangThai;
            _dbContext.Update(tempObj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
