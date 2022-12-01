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
    public class ChucVuRepositories: IChucVuRepositories
    {
        private BanGiayDBContext _dbContext;
        public ChucVuRepositories()
        {
          _dbContext = new BanGiayDBContext();
        }
        public bool Add(ChucVu obj)
        {
            if (obj == null) return false;
            obj.Id= Guid.NewGuid();
            _dbContext.ChucVus.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }


        public List<ChucVu> GetAll()
        {
            return _dbContext.ChucVus.ToList();
        }

          

        public ChucVu GetByID(Guid id)
        {
                if (id == Guid.Empty) return null;
                return _dbContext.ChucVus.FirstOrDefault(c => c.Id == id);
            
        }

        public bool Update(ChucVu obj)
        {
            if (obj == null) return false;
            var tempObj = _dbContext.ChucVus.FirstOrDefault(c => c.Id == obj.Id);
            tempObj.Ten = obj.Ten;
            tempObj.Ma = obj.Ma;
            tempObj.TrangThai = obj.TrangThai;
            _dbContext.Update(tempObj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
