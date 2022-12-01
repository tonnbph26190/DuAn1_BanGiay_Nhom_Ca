using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IChatLieuRepositories
    {
        bool Add(ChatLieu obj);    
        bool Update(ChatLieu obj);
        ChatLieu GetByID(Guid id);
        List<ChatLieu> GetAll();
    }
}
