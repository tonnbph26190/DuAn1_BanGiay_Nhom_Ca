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
    public class DongSpRepositories: IDongSpRepositories
    {
        private BanGiayDBContext _dbContext;
        public DongSpRepositories()
        {
            _dbContext= new BanGiayDBContext();
        }
        public bool Add(DongSP obj)
        {
            if (obj == null) return false;
            _dbContext.DongSPs.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }


        public List<DongSP> GetAll()
        {
            return _dbContext.DongSPs.ToList();
        }

        public DongSP GetByID(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dbContext.DongSPs.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(DongSP obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.DongSPs.FirstOrDefault(c => c.Id == obj.Id);
            tempObj.Ten = obj.Ten;
            tempObj.Ma = obj.Ma;
            tempObj.TrangThai = obj.TrangThai;
            _dbContext.Update(tempObj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
