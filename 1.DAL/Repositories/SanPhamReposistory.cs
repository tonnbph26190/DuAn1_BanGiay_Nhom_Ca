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
    public class SanPhamReposistory: ISanPhamReposistory
    {
        private BanGiayDBContext _dbContext;

        public SanPhamReposistory()
        {
            _dbContext= new BanGiayDBContext();
        }

        public bool Add(SanPham obj)
        {
            if (obj == null) return false;
            obj.Id= Guid.NewGuid();
            _dbContext.SanPhams.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(SanPham obj)
        {
            if (obj == null) return false;
            var temp = _dbContext.SanPhams.FirstOrDefault(c => c.Id == obj.Id);
            _dbContext.SanPhams.Remove(temp);
            _dbContext.SaveChanges();
            return true;
        }

        public List<SanPham> GetAll()
        {
            return _dbContext.SanPhams.ToList();
        }

        public SanPham GetByID(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dbContext.SanPhams.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(SanPham obj)
        {
            if (obj == null) return false;
            var temp = _dbContext.SanPhams.FirstOrDefault(c => c.Id == obj.Id);
            temp.Ten = obj.Ten;
            temp.Ma = obj.Ma;
            temp.TrangThai = obj.TrangThai;
            _dbContext.Update(temp);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
