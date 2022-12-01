using _1.DAL.Context;
using _1.DAL.IRepositories;
using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class ChatLieuRepositories : IChatLieuRepositories
    {
        private BanGiayDBContext _dBContext;
        public ChatLieuRepositories()
        {
            _dBContext= new BanGiayDBContext();
        }
        public bool Add(ChatLieu obj)
        {
            if (obj == null) return false;
           _dBContext.ChatLieus.Add(obj);
            _dBContext.SaveChanges();
            return true;
        }

        public List<ChatLieu> GetAll()
        {
            return _dBContext.ChatLieus.ToList();
        }

        public ChatLieu GetByID(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _dBContext.ChatLieus.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(ChatLieu obj)
        {
            if (obj == null) return false;
            var tempObj = _dBContext.ChatLieus.FirstOrDefault(c => c.Id == obj.Id);
            tempObj.Ten = obj.Ten;
            tempObj.Ma = obj.Ma;
            tempObj.TrangThai = obj.TrangThai;
            _dBContext.Update(tempObj);
            _dBContext.SaveChanges();
            return true;
        }
    }
}
